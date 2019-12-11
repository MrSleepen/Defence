using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
//Leveling Vars
    public int vLevel = 1;
    public int vCurrExp = 0;
    public int vCurrExpLoc = 0;
    public int vExpBase = 10;
    public int vExpLeft = 10;
    public float vExpMod = 1.15f;
    //Money Vars
    public int MoneyLoc;
    #region Update
    void Update()
    {
        
        vLevel = PlayerPrefs.GetInt("BaseLevel");
        vExpLeft = PlayerPrefs.GetInt("ExpLeft");
        vCurrExp = PlayerPrefs.GetInt("CurExp");
        
}
    #endregion
    #region Leveling
    //leveling methods
    public void GainExp(int e)
    {
        PlayerPrefs.SetInt("CurExp", vCurrExp + e);
        if  (PlayerPrefs.GetInt("CurExp") >= vExpLeft)
        {
            vCurrExpLoc = PlayerPrefs.GetInt("CurExp");
            LvlUp();
        }
    }
    void LvlUp()
    {
        vCurrExpLoc -= vExpLeft;
        PlayerPrefs.SetInt("CurExp", vCurrExpLoc);
        PlayerPrefs.SetInt("BaseLevel",vLevel + 1);
        float t = Mathf.Pow(vExpMod, vLevel);
        PlayerPrefs.SetInt("ExpLeft",(int)Mathf.Floor(vExpBase * t));
    }
    #endregion
    #region Money
    

    #endregion
}
