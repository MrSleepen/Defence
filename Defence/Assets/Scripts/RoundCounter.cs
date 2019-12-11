using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundCounter : MonoBehaviour
{
    public bool nextWave;
    public GameObject spawner;
    public int roundNumLoc;
    public bool roundActive;
    
    
    void Update()
    {
        //Debug.Log(PlayerPrefs.GetInt("RoundDeathCount"));
        //Debug.Log(PlayerPrefs.GetInt("RoundSpawnCount"));
        //Debug.Log(PlayerPrefs.GetInt("RoundNum"));
        //PlayerPrefs.SetInt("RoundDeathCount",0);
        //PlayerPrefs.SetInt("RoundSpawnCount",0);
        //PlayerPrefs.SetInt("RoundNum",0);
        if (nextWave == true)
        {  
            StartCoroutine(ActivateNextRound());
            nextWave = false;
        }
        
        //SetLocalNUmbers
        if (PlayerPrefs.GetInt("Spawned1") == 1)
        {
            if(PlayerPrefs.GetInt("RoundDeathCount") >= PlayerPrefs.GetInt("RoundSpawnCount"))
            {
                Debug.Log("Active");
                PassedWave();
            }
            if (PlayerPrefs.GetInt("BaseHealth") <= 0)
            {
                FailedWave();
            }
        }  
    }  

    
    //Button For Next Round
    public void PressedWave()
    {
        PlayerPrefs.SetInt("BaseHealth", 1);
        roundNumLoc = PlayerPrefs.GetInt("RoundNum")+1;
        PlayerPrefs.SetInt("RoundDeathCount",0);
        PlayerPrefs.SetInt("RoundSpawnCount",0);
        PlayerPrefs.SetInt("Spawned1", 2);
        nextWave = true;
        roundActive = true;
    }
    
    
    //Button For Replaying Round
    public void replayWave()
    {
        PlayerPrefs.SetInt("BaseHealth", 1);
        roundNumLoc = PlayerPrefs.GetInt("RoundNum");
        PlayerPrefs.SetInt("RoundDeathCount", 0);
        PlayerPrefs.SetInt("RoundSpawnCount", 0);
        PlayerPrefs.SetInt("Spawned1", 2);
        nextWave = true;
        roundActive = true;
    }
    
    
    //Called if wave Is completed
    public void PassedWave()
    {
        PlayerPrefs.SetInt("BaseHealth", 1);
        spawner.SetActive(false);
        PlayerPrefs.SetInt("RoundNum",roundNumLoc);
        PlayerPrefs.SetInt("Spawned1", 2);
    }
    
    
    //Called if wave is failed
    public void FailedWave()
    {
        PlayerPrefs.SetInt("BaseHealth", 1);
        Debug.Log("Failed");
        spawner.SetActive(false);
        roundNumLoc = PlayerPrefs.GetInt("RoundNum") - 1;
        PlayerPrefs.SetInt("Spawned1", 2);
    }
    
    
    //Enumerator For Activated New round.
    IEnumerator ActivateNextRound()
    { 
        spawner.SetActive(true);
        yield return new WaitForSeconds(.1f);
    }
}
