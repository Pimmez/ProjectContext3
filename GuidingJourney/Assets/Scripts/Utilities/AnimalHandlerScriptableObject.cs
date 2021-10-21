using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/AnimalScriptableObjects", order = 1)]
public class AnimalHandlerScriptableObject : ScriptableObject
{
    public string prefabName;
    public Image prefabImage;
    public Image prefabIcon;
    public string PrefabSkill;
}