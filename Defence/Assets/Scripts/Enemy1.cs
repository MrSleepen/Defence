using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    private bool Dieing = false;
    public int Health = 10;
    public GameObject This;
    public int CurrentMoney;
    public int DollerPK = 1;
    public int CreatureMultiplier = 1;
    




    // Start is called before the first frame update

    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        DollerPK = PlayerPrefs.GetInt("RoundNum") * CreatureMultiplier;
        //Debug.Log(CurrentMoney);
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
                Dieing = false;
                StartCoroutine(Death());
            }
        

        
    }
    //Damage Called from tower script upon Hit
    public void Damage(int Dam)
    {
        //Debug.Log(Dam);
        Health -= Dam;
    }
    //Run When Health =0a
    IEnumerator Death()
    {   
        PlayerPrefs.SetInt("Money", CurrentMoney);
        Destroy(This);
        yield return new WaitForSeconds(.5f);

    }

}
