using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoXColTower : MonoBehaviour
{
    public GameObject TowerParent;
    public bool Safetospawn = false;

    void Start()
    {
        StartCoroutine(SpawnCountDown());
    }
    void OnTriggerStay(Collider other)
    {

        if (other.gameObject.tag == "Tower" && Safetospawn == false)
        {
            Debug.Log("HAHAHA");
            Destroy(TowerParent);
        }
    }

    public IEnumerator SpawnCountDown() 
    { 
        yield return new WaitForSeconds(.1f);
        Safetospawn = true;
    }
}
