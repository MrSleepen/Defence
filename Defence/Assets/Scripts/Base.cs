using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Base : MonoBehaviour
{
//Leveling Vars
  
    //Money Vars
   
    #region Update
    void Awake()
    {
        PlayerPrefs.SetInt("BaseHealth", 20);
 
    }
        void Update()
    {

        if (PlayerPrefs.GetInt("BaseHealth")<= 0)
        {
            SceneManager.LoadScene("MainSelection Menu");
        }
}
    #endregion
   


   
}
