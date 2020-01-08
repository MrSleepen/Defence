using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherTower : MonoBehaviour
{


    private int AttackSpeed = 2;
    public bool Shoot = false;
    public GameObject target;
    public GameObject ArrowPrefab;
    public Transform FirePointPos;

    public int vLevel = 1;
    public int vCurrExp = 0;
    public int vCurrExpLoc = 0;
    public int vExpBase = 10;
    public int vExpLeft = 10;
    public float vExpMod = 1.15f;

 
    public Animator Archer;
    public SpriteRenderer ArcherRend;


    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        //Debug.Log(PlayerPrefs.GetInt("CurExpt1"));
        vLevel = PlayerPrefs.GetInt("BaseLevelt1");
        vExpLeft = PlayerPrefs.GetInt("ExpLeftt1");
        vCurrExp = PlayerPrefs.GetInt("CurExpt1");
        

        FaceThatWay();
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            if (Shoot == false)
            {
                Shoot = true;

                if (target == null)
                {
                    target = other.gameObject;
                    Archer.SetBool("Hastarget", true);
                    
                }
               
                
                StartCoroutine(Fire());
            }
        }

    }
    void OnTriggerExit(Collider other) 
    { 
        if (other.gameObject.tag == "Enemy" && target)
        {    
                target = null;
            Archer.SetBool("Hastarget", false);
            
        }

    }


    IEnumerator Fire()
    {
        
        if(Shoot == true) {

            //target.GetComponent<Enemy1>().Damage(Dam:AttackPower) ;
            GameObject ArrowObj = (GameObject)Instantiate(ArrowPrefab, FirePointPos.position, FirePointPos.rotation);
            Arrow arrow = ArrowObj.GetComponent<Arrow>();
           

            if (arrow != null)
            {
                arrow.Seek(target.transform);
            }
            
            yield return new WaitForSeconds(AttackSpeed);

            Shoot = false;

        }
    }

    public void FaceThatWay()
    {
        if (target) 
        
        { 
            if(target.transform.position.y > transform.position.y)
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

    #region Leveling
    //leveling methods
    public void GainExp(int e)
    {
        PlayerPrefs.SetInt("CurExpt1", vCurrExp + e);
        if (PlayerPrefs.GetInt("CurExpt1") >= vExpLeft)
        {
            vCurrExpLoc = PlayerPrefs.GetInt("CurExpt1");
            LvlUp();
        }
    }
    void LvlUp()
    {
        vCurrExpLoc -= vExpLeft;
        PlayerPrefs.SetInt("CurExpt1", vCurrExpLoc);
        PlayerPrefs.SetInt("BaseLevelt1", vLevel + 1);
        float t = Mathf.Pow(vExpMod, vLevel);
        PlayerPrefs.SetInt("ExpLeftt1", (int)Mathf.Floor(vExpBase * t));
    }
    #endregion

}
