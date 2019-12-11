using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    private bool Dieing = false;
    public int Health;
    public GameObject This;
    public int CurrentMoney;
    public int DollerPK = 1;
    public int CreatureMultiplier = 1;
    public int Attack = 1;
    public int MoneyLoc;
    public int MoneyBase = 10;
    public int MoneyMult;
    
    
    




    // Start is called before the first frame update

    void Start()
    {
        Health = PlayerPrefs.GetInt("RoundNum") * 4;
        Attack = PlayerPrefs.GetInt("RoundNum") / 4;
    }
    // Update is called once per frame
    void Update()
    {
       
        MoneyMult = MoneyBase + (PlayerPrefs.GetInt("RoundNum") / 2); 
        DollerPK = PlayerPrefs.GetInt("RoundNum") * CreatureMultiplier;
        Debug.Log(Health);
        //Debug.Log(PlayerPrefs.GetInt("Money"));
        //Debug.Log(DollerPK);
        if (Health <= 0)
        {
            Dieing = true;
        }

        //Current Money is always higher than the actualy amount
        CurrentMoney = PlayerPrefs.GetInt("Money") + DollerPK;

        
        //If Dieing Start Death() Coroutine
        if (Dieing == true)
            {
            PlayerPrefs.SetInt("RoundDeathCount", PlayerPrefs.GetInt("RoundDeathCount") + 1);
                Dieing = false;
                StartCoroutine(Death());
            }
        

        
    }
    //Damage Called from tower script upon Hit
    public void Damage(int Dam)
    {
        //Debug.Log("aqhahahhahahahhahahahhah");
        Health -= Dam;
    }
    //Run When Health =0a
    IEnumerator Death()
    {
        PlusMoney(e:MoneyMult) ;
        PlayerPrefs.SetInt("Money", CurrentMoney);
        Destroy(This);
        yield return new WaitForSeconds(.5f);
        

    }
    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Base")
        {
            PlayerPrefs.SetInt("BaseHealth", PlayerPrefs.GetInt("BaseHealth") - Attack);
            Destroy(This);
        }
    }
    public void PlusMoney(int e)
    {
        MoneyLoc = PlayerPrefs.GetInt("CurMoney") + e;
        PlayerPrefs.SetInt("CurMoney", MoneyLoc);
    }
}
