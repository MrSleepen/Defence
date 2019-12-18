using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenuScripts : MonoBehaviour
{
    public GameObject Menu;
   
    private bool MenuOpen=false;
    public GameObject archertower;
    public void OpenMenu()
    {
        if (!MenuOpen)
        {
            MenuOpen = true;
            Menu.SetActive(true);
        }
        else
        {
            MenuOpen = false;
            Menu.SetActive(false);
        }
    }

   
  
}
