using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritPlayer : MonoBehaviour
{

    private void Start()
    {
        Mesh playerMesh = this.gameObject.GetComponent<MeshFilter>().mesh;
    }

    private void switchAnimal(Mesh _animalMesh)
    {
        Debug.Log(_animalMesh.name);

        Mesh othermesh = _animalMesh;
        this.gameObject.GetComponent<MeshFilter>().mesh = othermesh;
    }

    
    private void OnEnable()
    {
        AnimalSwitchBehaviour.animalMeshEvent += switchAnimal;
    }

    private void OnDisable()
    {
        AnimalSwitchBehaviour.animalMeshEvent -= switchAnimal;
    }
}