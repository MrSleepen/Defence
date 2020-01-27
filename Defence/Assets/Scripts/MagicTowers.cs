using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicTowers : MonoBehaviour
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

    
    public ParticleSystem Burst;

    public GameObject[] LightningBurst;
    public bool TowerGOActive;
    private int PartActive;

    
    
   



    // Update is called once per frame
    void Update()
    {
       
        //Archer.speed = animSpeed;

        vLevel = PlayerPrefs.GetInt("BaseLevelt1");
        vExpLeft = PlayerPrefs.GetInt("ExpLeftt1");
        vCurrExp = PlayerPrefs.GetInt("CurExpt1");
        
        if(target != null)
        {
            
        }

        if (TowerGOActive)
        {
            PartActive = Random.Range(1, 10);
            if(PartActive == 1)
            {
                LightningBurst[1].SetActive(true);
                LightningBurst[2].SetActive(false);
                LightningBurst[3].SetActive(false);
                LightningBurst[4].SetActive(false);
                LightningBurst[5].SetActive(false);
                LightningBurst[6].SetActive(false);
                LightningBurst[7].SetActive(false);
            }
            if (PartActive == 2)
            {
                LightningBurst[1].SetActive(false);
                LightningBurst[2].SetActive(true);
                LightningBurst[3].SetActive(false);
                LightningBurst[4].SetActive(false);
                LightningBurst[5].SetActive(false);
                LightningBurst[6].SetActive(false);
                LightningBurst[7].SetActive(false);
            }
            if (PartActive == 3)
            {
                LightningBurst[1].SetActive(false);
                LightningBurst[2].SetActive(false);
                LightningBurst[3].SetActive(true);
                LightningBurst[4].SetActive(false);
                LightningBurst[5].SetActive(false);
                LightningBurst[6].SetActive(false);
                LightningBurst[7].SetActive(false);
            }
            if (PartActive == 4)
            {
                LightningBurst[1].SetActive(false);
                LightningBurst[2].SetActive(false);
                LightningBurst[3].SetActive(false);
                LightningBurst[4].SetActive(true);
                LightningBurst[5].SetActive(false);
                LightningBurst[6].SetActive(false);
                LightningBurst[7].SetActive(false);
            }
            if (PartActive == 5)
            {
                LightningBurst[1].SetActive(false);
                LightningBurst[2].SetActive(false);
                LightningBurst[3].SetActive(false);
                LightningBurst[4].SetActive(false);
                LightningBurst[5].SetActive(true);
                LightningBurst[6].SetActive(false);
                LightningBurst[7].SetActive(false);
            }
            if (PartActive == 6)
            {
                LightningBurst[1].SetActive(false);
                LightningBurst[2].SetActive(false);
                LightningBurst[3].SetActive(false);
                LightningBurst[4].SetActive(false);
                LightningBurst[5].SetActive(false);
                LightningBurst[6].SetActive(true);
                LightningBurst[7].SetActive(false);
            }
            if (PartActive == 7)
            {
                LightningBurst[1].SetActive(false);
                LightningBurst[2].SetActive(false);
                LightningBurst[3].SetActive(false);
                LightningBurst[4].SetActive(false);
                LightningBurst[5].SetActive(false);
                LightningBurst[6].SetActive(false);
                LightningBurst[7].SetActive(true);
            }

        }
       
        

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
                




        }

    }


    IEnumerator Fire()
    {
      

        if (Shoot == true) {
            Debug.Log("Fire");
            //target.GetComponent<Enemy1>().Damage(Dam:AttackPower) ;
            GameObject ArrowObj = (GameObject)Instantiate(ArrowPrefab, FirePointPos.position, FirePointPos.rotation);
            Arrow arrow = ArrowObj.GetComponent<Arrow>();
           

            if (arrow != null)

            {
                
                Burst.Play();
                arrow.Seek(target.transform);
            }
            
            yield return new WaitForSeconds(AttackSpeed);

            Shoot = false;

            

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
