using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
    public GameObject zombiePrefab;
    public Transform[] spawnPoints;
    public TextMeshProUGUI zombiesRemainingText;
    public TextMeshProUGUI waveNumberText;

    public int waveNumber = 1;
    private int zombiesPerWave = 10;
    private int zombiesRemaining = 0;
    private int currentSpawnPointIndex = 0;

    private void OnEnable()
    {
        SpawnListner.OnZombieAdded += SpawnListner_OnZombieAdded;
        Zombie.OnDeath += Zombie_OnDeath;
    }

    private void SpawnListner_OnZombieAdded(object sender, SpawnListner.OnZombieAddedArgs e)
    {
        zombiesRemaining += e.ZombiesAdded;
        UpdateUI();
    }

    private void Zombie_OnDeath(object sender, Zombie.OnDeathEventArgs e)
    {
        zombiesRemaining--;
        UpdateUI();
    }

    private void OnDisable()
    {
        SpawnListner.OnZombieAdded -= SpawnListner_OnZombieAdded;
        Zombie.OnDeath -= Zombie_OnDeath;
    }

    public class OnSpawnEventArgs
    {
        public WaveSpawner Spawn;

        public OnSpawnEventArgs(WaveSpawner waveSpawner)
        {
            Spawn = waveSpawner;
        }

    }

    public static event System.EventHandler<OnSpawnEventArgs> OnSpawn;

    void Start()
    {
        waveNumber = 1;
        zombiesRemaining = zombiesPerWave;
        UpdateUI();
        waveNumberText.text = "Wave: " + waveNumber.ToString();

        StartCoroutine(SpawnWave());
        OnSpawn?.Invoke(this, new OnSpawnEventArgs(this));
    }

    void Update()
    {
        if (zombiesRemaining <= 0)
        {
            StartNextWave();
        }
    }

    void StartNextWave()
    {
        waveNumber++;
        waveNumberText.text = "Wave: " + waveNumber.ToString();

        zombiesPerWave += 5;
        zombiesRemaining = zombiesPerWave;

        StartCoroutine(SpawnWave());
        OnSpawn?.Invoke(this, new OnSpawnEventArgs(this));
        UpdateUI();
    }

    IEnumerator SpawnWave()
    {
        for (int i = 0; i < zombiesPerWave; i++)
        {
            SpawnZombie();
            yield return new WaitForSeconds(0.5f);
        }
    }

    void SpawnZombie()
    {
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        Instantiate(zombiePrefab, spawnPoint.position, spawnPoint.rotation);
    }

    void UpdateUI()
    {
        zombiesRemainingText.text = "Zombies Until Next Wave: " + zombiesRemaining.ToString();
    }
}



