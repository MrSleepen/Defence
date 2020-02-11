using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NavMenu : MonoBehaviour
{

    public GameObject MMnav;
    public GameObject[] Levels;
    public GameObject LevelSel;
    public GameObject Settings;
    public GameObject[] MusicToggle;
    public GameObject[] AudioToggle;
    public int DisplayingLevel =1 ;
    public int MTog =0 ;
   

    public void MoveRight()
    {
        if(DisplayingLevel <= 7 ) { DisplayingLevel += 1; }
       
        if (DisplayingLevel == 1)
        {
            Levels[1].SetActive(true);
            Levels[2].SetActive(false);
            Levels[3].SetActive(false);
            Levels[4].SetActive(false);
            Levels[5].SetActive(false);
            Levels[6].SetActive(false);
            Levels[7].SetActive(false);
            Levels[8].SetActive(false);
        }
        if (DisplayingLevel == 2)
        {
            Levels[1].SetActive(false);
            Levels[2].SetActive(true);
            Levels[3].SetActive(false);
            Levels[4].SetActive(false);
            Levels[5].SetActive(false);
            Levels[6].SetActive(false);
            Levels[7].SetActive(false);
            Levels[8].SetActive(false);
        }
        if (DisplayingLevel == 3)
        {
            Levels[1].SetActive(false);
            Levels[2].SetActive(false);
            Levels[3].SetActive(true);
            Levels[4].SetActive(false);
            Levels[5].SetActive(false);
            Levels[6].SetActive(false);
            Levels[7].SetActive(false);
            Levels[8].SetActive(false);
        }
        if (DisplayingLevel == 4)
        {
            Levels[1].SetActive(false);
            Levels[2].SetActive(false);
            Levels[3].SetActive(false);
            Levels[4].SetActive(true);
            Levels[5].SetActive(false);
            Levels[6].SetActive(false);
            Levels[7].SetActive(false);
            Levels[8].SetActive(false);
        }
        if (DisplayingLevel == 5)
        {
            Levels[1].SetActive(false);
            Levels[2].SetActive(false);
            Levels[3].SetActive(false);
            Levels[4].SetActive(false);
            Levels[5].SetActive(true);
            Levels[6].SetActive(false);
            Levels[7].SetActive(false);
            Levels[8].SetActive(false);
        }
        if (DisplayingLevel == 6)
        {
            Levels[1].SetActive(false);
            Levels[2].SetActive(false);
            Levels[3].SetActive(false);
            Levels[4].SetActive(false);
            Levels[5].SetActive(false);
            Levels[6].SetActive(true);
            Levels[7].SetActive(false);
            Levels[8].SetActive(false);
        }
        if (DisplayingLevel == 7)
        {
            Levels[1].SetActive(false);
            Levels[2].SetActive(false);
            Levels[3].SetActive(false);
            Levels[4].SetActive(false);
            Levels[5].SetActive(false);
            Levels[6].SetActive(false);
            Levels[7].SetActive(true);
            Levels[8].SetActive(false);
        }
        if (DisplayingLevel == 8)
        {
            Levels[1].SetActive(false);
            Levels[2].SetActive(false);
            Levels[3].SetActive(false);
            Levels[4].SetActive(false);
            Levels[5].SetActive(false);
            Levels[6].SetActive(false);
            Levels[7].SetActive(false);
            Levels[8].SetActive(true);
        }
    }
    public void MoveLeft()
    {
        if (DisplayingLevel >= 2) { DisplayingLevel -= 1; }
        if (DisplayingLevel == 1)
        {
            Levels[1].SetActive(true);
            Levels[2].SetActive(false);
            Levels[3].SetActive(false);
            Levels[4].SetActive(false);
            Levels[5].SetActive(false);
            Levels[6].SetActive(false);
            Levels[7].SetActive(false);
            Levels[8].SetActive(false);
        }
        if (DisplayingLevel == 2)
        {
            Levels[1].SetActive(false);
            Levels[2].SetActive(true);
            Levels[3].SetActive(false);
            Levels[4].SetActive(false);
            Levels[5].SetActive(false);
            Levels[6].SetActive(false);
            Levels[7].SetActive(false);
            Levels[8].SetActive(false);
        }
        if (DisplayingLevel == 3)
        {
            Levels[1].SetActive(false);
            Levels[2].SetActive(false);
            Levels[3].SetActive(true);
            Levels[4].SetActive(false);
            Levels[5].SetActive(false);
            Levels[6].SetActive(false);
            Levels[7].SetActive(false);
            Levels[8].SetActive(false);
        }
        if (DisplayingLevel == 4)
        {
            Levels[1].SetActive(false);
            Levels[2].SetActive(false);
            Levels[3].SetActive(false);
            Levels[4].SetActive(true);
            Levels[5].SetActive(false);
            Levels[6].SetActive(false);
            Levels[7].SetActive(false);
            Levels[8].SetActive(false);
        }
        if (DisplayingLevel == 5)
        {
            Levels[1].SetActive(false);
            Levels[2].SetActive(false);
            Levels[3].SetActive(false);
            Levels[4].SetActive(false);
            Levels[5].SetActive(true);
            Levels[6].SetActive(false);
            Levels[7].SetActive(false);
            Levels[8].SetActive(false);
        }
        if (DisplayingLevel == 6)
        {
            Levels[1].SetActive(false);
            Levels[2].SetActive(false);
            Levels[3].SetActive(false);
            Levels[4].SetActive(false);
            Levels[5].SetActive(false);
            Levels[6].SetActive(true);
            Levels[7].SetActive(false);
            Levels[8].SetActive(false);
        }
        if (DisplayingLevel == 7)
        {
            Levels[1].SetActive(false);
            Levels[2].SetActive(false);
            Levels[3].SetActive(false);
            Levels[4].SetActive(false);
            Levels[5].SetActive(false);
            Levels[6].SetActive(false);
            Levels[7].SetActive(true);
            Levels[8].SetActive(false);
        }
        if (DisplayingLevel == 8)
        {
            Levels[1].SetActive(false);
            Levels[2].SetActive(false);
            Levels[3].SetActive(false);
            Levels[4].SetActive(false);
            Levels[5].SetActive(false);
            Levels[6].SetActive(false);
            Levels[7].SetActive(false);
            Levels[8].SetActive(true);
        }
    }
    public void CloseLS()
    {
        LevelSel.SetActive(false);
        MMnav.SetActive(true);
    }
    public void OpenLS()
    {
        LevelSel.SetActive(true);
        MMnav.SetActive(false);
    }
    public void CloseSS()
    {
        Settings.SetActive(false);
        MMnav.SetActive(true);
    }
    public void OpenSS()
    {
        Settings.SetActive(true);
        MMnav.SetActive(false);
    }
    public void LoadLevel1()
    {
        SceneManager.LoadScene("Level1");
    }
    public void LoadLevel2()
    {
        SceneManager.LoadScene("Level2");
    }
    public void LoadLevel3()
    {
        SceneManager.LoadScene("Level3");
    }
    public void LoadLevel4()
    {
        SceneManager.LoadScene("Level4");
    }
    public void LoadLevel5()
    {
        SceneManager.LoadScene("Level5");
    }
    public void LoadLevel6()
    {
        SceneManager.LoadScene("Level6");
    }
    public void LoadLevel7()
    {
        SceneManager.LoadScene("Level7");
    }
    public void LoadLevel8()
    {
        SceneManager.LoadScene("Level8");
    }

    public void ToggleMusic()
    {
        if (MTog == 0)
        {
            MTog = 1;
        }
        else 
        {
            MTog = 0;   
        }

        if (MTog == 0)
        {
            MusicToggle[0].SetActive(true);
            MusicToggle[1].SetActive(false);
        }
        else
        {
            MusicToggle[0].SetActive(false);
            MusicToggle[1].SetActive(true);
        }
    }


}
