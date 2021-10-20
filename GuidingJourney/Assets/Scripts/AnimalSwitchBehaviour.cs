using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AnimalSwitchBehaviour : MonoBehaviour
{
    public static Action<Mesh> animalMeshEvent;
    public List<AnimalHandlerScriptableObject> animalsSO = new List<AnimalHandlerScriptableObject>();
    public void FoxHandler()
    {
        if (animalMeshEvent != null) animalMeshEvent(animalsSO[0].animalMesh);
    }

    public void ElephantHandler()
    {
        if (animalMeshEvent != null) animalMeshEvent(animalsSO[1].animalMesh);
    }
}