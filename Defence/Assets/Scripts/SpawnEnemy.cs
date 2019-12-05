using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{

    public GameObject spawnee;
    public bool StopSpawning;
    public float spawnTime;
    public float spawnDelay;
    public int MaxSpawn;
    public int CurrentSpawned;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObject", spawnTime, spawnDelay);
    }

    // Update is called once per frame
   public void SpawnObject()
    {
        if (CurrentSpawned < MaxSpawn )
        {
            Instantiate(spawnee, transform.position, transform.rotation);
            ++CurrentSpawned;
        }
        else
        {
            StopSpawning = true;
        }
        if (StopSpawning)
        {
            CancelInvoke("SpawnObject");
        }
    }
}
