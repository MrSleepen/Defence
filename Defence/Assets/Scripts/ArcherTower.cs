using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherTower : MonoBehaviour
{


    private float AttackSpeed = 1;
    public bool Shoot = false;
    public GameObject target;
    public GameObject ArrowPrefab;
    public Transform FirePointPos;
    public GameObject ArcherTowerPanel;
    public bool Visible;
    private int TowerLevel = 1;
    private int SpeedLevel;
    private int Cost;
    public float CritChance;
    private int AttackPowert = 3;
    public BoxCollider Range;
    private float RangeSize = 5f;
    private int crithit = 1;

    private int speed = 1;
    private int attack = 1;
    private int range = 1;
    private int crit = 1;





    //private float animSpeed = 0.5f;
    public Animator Archer;
    public SpriteRenderer ArcherRend;


    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update()
    {
      

        Range.size = new Vector3( RangeSize, RangeSize, RangeSize);
       
        FaceThatWay();
        if (Visible)
        {
            ArcherTowerPanel.SetActive(true);
        }
        else if (!Visible)
        {
            ArcherTowerPanel.SetActive(false);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Enemy" && Shoot == false)
        {        
            Shoot = true;    
            while (target == null)   
            {       
                target = other.gameObject;      
                Archer.SetBool("Hastarget", true); 
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        while (other.gameObject.tag == "Enemy" && target)
        {
            target = null;
            Archer.SetBool("Hastarget", false);
        }
    }


    IEnumerator Fire()
    {
        Archer.SetBool("Hastarget", false);
        if (Shoot == true)
        {
             int i = Random.Range(1, 100);
            //target.GetComponent<Enemy1>().Damage(Dam:AttackPower) ;
            GameObject ArrowObj = (GameObject)Instantiate(ArrowPrefab, FirePointPos.position, FirePointPos.rotation);
            Arrow arrow = ArrowObj.GetComponent<Arrow>();
            if (arrow != null)
            {
                if(i <= CritChance)
                {
                    crithit = 2;
                    Debug.Log("Crit");
                }
                arrow.AttackPower = AttackPowert * crithit;
                
                arrow.Seek(target.transform);
            }
            yield return new WaitForSeconds(AttackSpeed);
            Archer.SetBool("Hastarget", true);
            crithit = 1;
            Shoot = false;

        }
    }

    public void FaceThatWay()
    {
        if (target)

        {
            if (target.transform.position.y > transform.position.y)
            {
                Archer.SetBool("IsBehind", true);
            }
            else
            {
                Archer.SetBool("IsBehind", false);
            }
            if (target.transform.position.x > transform.position.x)
            {
                ArcherRend.flipX = false;
            }
            else
            {
                ArcherRend.flipX = true;
            }


        }
    }

    public void LevelSpeed()
    {
        if(Cost <= PlayerPrefs.GetInt("CurMoneyt1") && TowerLevel <= 40 && speed <=20)
        {
            AttackSpeed -= .1f;
            speed +=1 ;
            TowerLevel++;
        }
        else
        {
            Debug.Log("MaxLevel");
        }
    }
   
    public void LevelRange()
    {
        if (Cost <= PlayerPrefs.GetInt("CurMoneyt1") && TowerLevel <= 40 && range <= 20)
        {
            range += 1;
            RangeSize += .5f;
            TowerLevel++;
        }
        else
        {
            Debug.Log("MaxLevel");
        }
    }

    public void LevelAttack()
    {
        if (Cost <= PlayerPrefs.GetInt("CurMoneyt1") && TowerLevel <= 40 && attack <= 20)
        {
            AttackPowert += 1;
            attack +=1 ;
            TowerLevel++;
        }
        else
        {
            Debug.Log("MaxLevel");
        }
    }
    public void LevelCrit()
    {
        if (Cost <= PlayerPrefs.GetInt("CurMoneyt1") && TowerLevel <=40 && crit <= 20)
        {
            CritChance += 1;
            crit +=1 ;
            TowerLevel++;
        }
        else
        {
            Debug.Log("MaxLevel");
        }
    }

}