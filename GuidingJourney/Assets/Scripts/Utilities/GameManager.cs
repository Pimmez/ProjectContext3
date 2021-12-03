using Extensions.Generics.Singleton;
using UnityEngine;

public class GameManager : GenericSingleton<GameManager, GameManager>
{
    [Header("Settings")]
    public float test;

       
}