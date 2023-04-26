using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnListner : MonoBehaviour
{

    public GameObject zombiePrefab;
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
            SpawnZombie(numOfZombies);
        }
        else if(e.Spawn.waveNumber == 2)
        {
            numOfZombies = 2;
            SpawnZombie(numOfZombies);
        }
        else if(e.Spawn.waveNumber == 3)
        {
            numOfZombies = 3;
            SpawnZombie(numOfZombies);
        }
        else if(e.Spawn.waveNumber == 4)
        {
            numOfZombies = 4;
            SpawnZombie(numOfZombies);
        }
        else if(e.Spawn.waveNumber == 5)
        {
            numOfZombies = 5;
            SpawnZombie(numOfZombies);
        }
    }

    void SpawnZombie(int numOfZombies)
    {
        for(int i = 0; i < numOfZombies; i++)
            Instantiate(zombiePrefab, spawnPoint.position, spawnPoint.rotation);

        OnZombieAdded?.Invoke(this, new OnZombieAddedArgs(numOfZombies));
    }


}
