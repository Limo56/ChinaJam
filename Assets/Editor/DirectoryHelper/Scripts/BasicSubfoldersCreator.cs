using UnityEditor;
using UnityEngine;
using System.IO;

public class DefaultFolderCreator
{
    private static ModelSubfoldersData _modelSubfoldersData;
    private static ScriptSubfoldersData _scriptSubfoldersData;
    
    [MenuItem("Assets/Create/ModelSubfolders")]
    public static void CreateModelSubfolders()
    {
        if (_modelSubfoldersData == null)
        {
            string[] guids = AssetDatabase.FindAssets("t:ModelSubfoldersData");
            if (guids.Length > 0)
            {
                string path = AssetDatabase.GUIDToAssetPath(guids[0]);
                _modelSubfoldersData = AssetDatabase.LoadAssetAtPath<ModelSubfoldersData>(path);
            }
            else
            {
                _modelSubfoldersData = ScriptableObject.CreateInstance<ModelSubfoldersData>();
            }
        }
        
        CreateSubfolders(_modelSubfoldersData.foldersToCreate);
    }

    [MenuItem("Assets/Create/ScriptsSubfolders")]
    public static void CreateScriptSubfolders()
    {
        if (_scriptSubfoldersData == null)
        {
            string[] guids = AssetDatabase.FindAssets("t:ScriptSubfoldersData");
            if (guids.Length > 0)
            {
                string path = AssetDatabase.GUIDToAssetPath(guids[0]);
                _scriptSubfoldersData = AssetDatabase.LoadAssetAtPath<ScriptSubfoldersData>(path);
            }
            else
            {
                _scriptSubfoldersData = ScriptableObject.CreateInstance<ScriptSubfoldersData>();
            }
        }

        CreateSubfolders(_scriptSubfoldersData.foldersToCreate);
    }
    
    private static void CreateSubfolders(string[] foldersToCreate)
    {
        string selectedPath = "Assets";
        Object[] selectedObjects = Selection.GetFiltered<Object>(SelectionMode.Assets);

        if (selectedObjects.Length > 0)
        {
            selectedPath = AssetDatabase.GetAssetPath(selectedObjects[0]);

            if (!Directory.Exists(selectedPath))
            {
                selectedPath = Path.GetDirectoryName(selectedPath);
            }
        }

        foreach (string folder in foldersToCreate)
        {
            string fullPath = Path.Combine(selectedPath, folder);

            if (!Directory.Exists(fullPath))
            {
                AssetDatabase.CreateFolder(selectedPath, folder);
            }
        }

        AssetDatabase.Refresh();
    }
}
