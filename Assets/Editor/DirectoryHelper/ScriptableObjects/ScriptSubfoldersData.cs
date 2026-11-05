using UnityEngine;

[CreateAssetMenu(fileName = "ScriptSubfoldersData", menuName = "Scriptable Objects/ScriptSubfoldersData")]
public class ScriptSubfoldersData : ScriptableObject
{
    public string[] foldersToCreate =
    {
        "Scripts",
        "Prefabs"
    };
}