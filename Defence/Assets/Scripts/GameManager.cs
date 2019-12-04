using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Create the game manager and make it visible from other scripts
    private static GameManager _Instance = null;
    public static GameManager Instance
    {
        get
        {
            if (_Instance == null)
            {
                GameObject go = new GameObject("GameManager");
                go.AddComponent<GameManager>();

            }
            return _Instance;
        }
    }
 

    void Awake()
    {
        _Instance = this;
    }

    private void Start()
    {
       
    }

}
