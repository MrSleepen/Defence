using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{

    public GameObject[] spawnee;
    public GameObject spawned;

    public bool StopSpawning;
    public float spawnTime;
    public float spawnDelay;
    public int MaxSpawn;
    public int CurrentSpawned;
    public int openCreatures;
    public int RandomNumber;
    
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObject", spawnTime, spawnDelay);
    }
    void FixedUpdate()
    {
        RandomNumber = Random.Range(1, openCreatures+1);
    }

    // Update is called once per frame
   public void SpawnObject()
    {
        

        if (CurrentSpawned < MaxSpawn && openCreatures >= 1 && RandomNumber == 1)
        {
            spawned = Instantiate(spawnee[1], transform.position, transform.rotation);
            ++CurrentSpawned;
            PlayerPrefs.SetInt("RoundSpawnCount", PlayerPrefs.GetInt("RoundSpawnCount") + 1);
            PlayerPrefs.SetInt("Spawned1", 1);

            spawned.GetComponent<FollowPath>().NotOriginal();

            

        }

         if (CurrentSpawned < MaxSpawn && openCreatures >= 2 && RandomNumber == 2)
        {
            spawned = Instantiate(spawnee[2], transform.position, transform.rotation);
            ++CurrentSpawned;
            PlayerPrefs.SetInt("RoundSpawnCount", PlayerPrefs.GetInt("RoundSpawnCount") + 1);
            PlayerPrefs.SetInt("Spawned1", 1);

            spawned.GetComponent<FollowPath>().NotOriginal();
            
        }

        if (CurrentSpawned < MaxSpawn && openCreatures >= 3 && RandomNumber == 3)
        {
            spawned = Instantiate(spawnee[3], transform.position, transform.rotation);
            ++CurrentSpawned;
            PlayerPrefs.SetInt("RoundSpawnCount", PlayerPrefs.GetInt("RoundSpawnCount") + 1);
            PlayerPrefs.SetInt("Spawned1", 1);

            spawned.GetComponent<FollowPath>().NotOriginal();

        }
        if (CurrentSpawned < MaxSpawn && openCreatures >= 4 && RandomNumber == 4)
        {
            spawned = Instantiate(spawnee[4], transform.position, transform.rotation);
            ++CurrentSpawned;
            PlayerPrefs.SetInt("RoundSpawnCount", PlayerPrefs.GetInt("RoundSpawnCount") + 1);
            PlayerPrefs.SetInt("Spawned1", 1);

            spawned.GetComponent<FollowPath>().NotOriginal();

        }
        if (CurrentSpawned < MaxSpawn && openCreatures >= 5 && RandomNumber == 5)
        {
            spawned = Instantiate(spawnee[5], transform.position, transform.rotation);
            ++CurrentSpawned;
            PlayerPrefs.SetInt("RoundSpawnCount", PlayerPrefs.GetInt("RoundSpawnCount") + 1);
            PlayerPrefs.SetInt("Spawned1", 1);

            spawned.GetComponent<FollowPath>().NotOriginal();

        }
        if (CurrentSpawned < MaxSpawn && openCreatures >= 6 && RandomNumber == 6)
        {
            spawned = Instantiate(spawnee[6], transform.position, transform.rotation);
            ++CurrentSpawned;
            PlayerPrefs.SetInt("RoundSpawnCount", PlayerPrefs.GetInt("RoundSpawnCount") + 1);
            PlayerPrefs.SetInt("Spawned1", 1);

            spawned.GetComponent<FollowPath>().NotOriginal();

        }
        if (CurrentSpawned < MaxSpawn && openCreatures >= 7 && RandomNumber == 7)
        {
            spawned = Instantiate(spawnee[7], transform.position, transform.rotation);
            ++CurrentSpawned;
            PlayerPrefs.SetInt("RoundSpawnCount", PlayerPrefs.GetInt("RoundSpawnCount") + 1);
            PlayerPrefs.SetInt("Spawned1", 1);

            spawned.GetComponent<FollowPath>().NotOriginal();

        }
        if (CurrentSpawned < MaxSpawn && openCreatures >= 8 && RandomNumber == 8)
        {
            spawned = Instantiate(spawnee[8], transform.position, transform.rotation);
            ++CurrentSpawned;
            PlayerPrefs.SetInt("RoundSpawnCount", PlayerPrefs.GetInt("RoundSpawnCount") + 1);
            PlayerPrefs.SetInt("Spawned1", 1);

            spawned.GetComponent<FollowPath>().NotOriginal();

        }
        if ( CurrentSpawned >= MaxSpawn)
        {
            StopSpawning = true;
        }
        if (StopSpawning)
        {
            CancelInvoke("SpawnObject");
        }
    }
}
