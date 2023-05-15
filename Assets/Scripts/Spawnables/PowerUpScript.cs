using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpScript : MonoBehaviour
{

    public GameObject HealthPowerUp;
    public GameObject AutoGunPowerUp;
    public GameObject SpeedPowerUp;
    public Transform[] spawnPoints;


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
            SpawnPowerUps();
        }
        else if (e.Spawn.waveNumber == 2)
        {
            SpawnPowerUps();
        }
        else if (e.Spawn.waveNumber == 3)
        {
            SpawnPowerUps();
        }
        else if (e.Spawn.waveNumber == 4)
        {
            SpawnPowerUps();
        }
        else if (e.Spawn.waveNumber == 5)
        {
            SpawnPowerUps();
        }
    }

    void SpawnPowerUps()
    { 
        Instantiate(HealthPowerUp, spawnPoints[0].position, spawnPoints[0].rotation);
        Instantiate(AutoGunPowerUp, spawnPoints[1].position, spawnPoints[1].rotation);
        Instantiate(SpeedPowerUp, spawnPoints[2].position, spawnPoints[2].rotation);
    }



}