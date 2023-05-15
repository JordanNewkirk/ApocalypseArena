using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnListner : MonoBehaviour
{

    public GameObject zombiePrefab;
    public GameObject zombiePrefab1;
    public GameObject zombiePrefab2;
    public GameObject zombiePrefab3;
    public GameObject bossZombiePrefab;
    public Transform spawnPoint;

    public int numOfZombies;

    public class OnZombieAddedArgs
    {
        public int ZombiesAdded;

        public OnZombieAddedArgs(int zombiesAdded)
        {
            ZombiesAdded = zombiesAdded;
        }
    }

    public static event System.EventHandler<OnZombieAddedArgs> OnZombieAdded;


    private void OnEnable()
    {
        WaveSpawner.OnSpawn += WaveSpawner_OnSpawn;
    }

    private void OnDisable()
    {
        WaveSpawner.OnSpawn -= WaveSpawner_OnSpawn;
    }

    private void WaveSpawner_OnSpawn(object sender, WaveSpawner.OnSpawnEventArgs e)
    {
        if(e.Spawn.waveNumber == 1)
        {
            numOfZombies = 1;
            SpawnZombie(zombiePrefab, numOfZombies);
        }
        else if(e.Spawn.waveNumber == 2)
        {
            numOfZombies = 2;
            SpawnZombie(zombiePrefab1, numOfZombies);
        }
        else if(e.Spawn.waveNumber == 3)
        {
            numOfZombies = 3;
            SpawnZombie(zombiePrefab2, numOfZombies);
        }
        else if(e.Spawn.waveNumber == 4)
        {
            numOfZombies = 4;
            SpawnZombie(zombiePrefab3, numOfZombies);
        }
        else if(e.Spawn.waveNumber == 5)
        {
            numOfZombies = 5;
            SpawnZombie(bossZombiePrefab, numOfZombies);
        }
    }

    void SpawnZombie(GameObject zombie, int numOfZombies)
    {
        for(int i = 0; i < numOfZombies; i++)
            Instantiate(zombie, spawnPoint.position, spawnPoint.rotation);

        OnZombieAdded?.Invoke(this, new OnZombieAddedArgs(numOfZombies));
    }


}
