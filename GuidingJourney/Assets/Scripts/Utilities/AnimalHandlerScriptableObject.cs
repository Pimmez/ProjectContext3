using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/AnimalScriptableObjects", order = 1)]
public class AnimalHandlerScriptableObject : ScriptableObject
{
    public string prefabName;

    public Mesh animalMesh;
    public Material animalMat;
    public string strength;  
}