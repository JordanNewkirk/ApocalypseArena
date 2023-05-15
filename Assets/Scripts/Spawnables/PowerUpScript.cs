using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpScript : MonoBehaviour
{

    public GameObject powerUp;
    public Transform spawnPoint;


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
        if (e.Spawn.waveNumber == 1)
        {
            SpawnPowerUp();
        }
        else if (e.Spawn.waveNumber == 2)
        {
            SpawnPowerUp();
        }
        else if (e.Spawn.waveNumber == 3)
        {
            SpawnPowerUp();
        }
        else if (e.Spawn.waveNumber == 4)
        {
            SpawnPowerUp();
        }
        else if (e.Spawn.waveNumber == 5)
        {
            SpawnPowerUp();
        }
    }

    void SpawnPowerUp()
    { 
          Instantiate(powerUp, spawnPoint.position, spawnPoint.rotation);
    }


}