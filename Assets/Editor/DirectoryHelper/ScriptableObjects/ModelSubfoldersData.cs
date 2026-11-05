using UnityEngine;

[CreateAssetMenu(fileName = "ModelSubfoldersData", menuName = "Scriptable Objects/ModelSubfoldersData")]
public class ModelSubfoldersData : ScriptableObject
{
    public string[] foldersToCreate =
    {
        "Materials",
        "MaterialVariants",
        "ShaderGraphs",
        "Textures",
        "Meshes",
        "Prefabs"
    };
}
