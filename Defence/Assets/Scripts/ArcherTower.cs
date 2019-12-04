using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherTower : MonoBehaviour
{
    public int AttackPower;
    public GameObject AttackRange;
    private int AttackSpeed = 2;
    public bool Shoot = false;
    public GameObject target;
    public int TowerLevel = 4;
    
    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(PlayerPrefs.GetInt("Money"));
        AttackPower = 1 + TowerLevel;
        //Debug.Log(target);
        if (Shoot == false)
        {
            
        }
    }

    void OnTriggerStay(Collider other)
    {

        if (other.gameObject.tag == "Enemy")
        {
           
            if (Shoot == false)
            {
                Shoot = true;
                target = other.gameObject;
                StartCoroutine(Fire());
           
            }
        }
    }

    IEnumerator Fire()
    {
        
        if(Shoot == true) { 
        //Debug.Log("Shoot");
        AttackPower += 1;
            target.GetComponent<Enemy1>().Damage(Dam:AttackPower) ;
        //target.GetComponent<Enemy2>().Damage2();
        yield return new WaitForSeconds(AttackSpeed);
        Shoot = false;

        }
    }
}
