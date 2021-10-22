using System.Collections.Generic;
using UnityEngine;


/*
 * 
 * Idee om het met scriptable objects te regelen dat je daarin aangeeft hoe het object heet, welk model er wordt meegegeven en de bijbehorende icons.
 * 
 */

public class ClickChosenAnimal : MonoBehaviour
{
    private GameObject currentAnimal = null;
    private GameObject newAnimal = null;
    [SerializeField] private List<GameObject> animals = new List<GameObject>();

    public void OnAnimalIconClick(GameObject _thisAnimal)
    {
        for (int i = 0; i < animals.Count; i++)
        {
            if (animals[i].activeSelf == true)
            {
                currentAnimal = animals[i];

                newAnimal = _thisAnimal;

                SwitchAnimal();
                return;
            }
        }
    }

    private void SwitchAnimal()
    {
        currentAnimal.SetActive(false);
        newAnimal.SetActive(true);
    }
}