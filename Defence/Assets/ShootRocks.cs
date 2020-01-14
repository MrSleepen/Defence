using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootRocks : MonoBehaviour
{
    public GameObject Rocktower;


    public void Fire()
    {
        Rocktower.GetComponent<RockTower>().Shootdat();
      
    }
}
