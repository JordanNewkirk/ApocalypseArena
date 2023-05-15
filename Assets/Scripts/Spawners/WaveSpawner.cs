using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class WaveSpawner : MonoBehaviour
{
    public GameObject zombiePrefab1;
    public GameObject zombiePrefab2;
    public GameObject zombiePrefab3;
    public GameObject zombiePrefab4;
    public Transform[] spawnPoints;
    public TextMeshProUGUI zombiesRemainingText;
    public TextMeshProUGUI waveNumberText;

    public int waveNumber = 1;
    private int zombiesPerWave = 9;
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
        waveNumberText.text = "Wave: " + waveNumber.ToString();
        UpdateUI();

        Color textColor = waveNumberText.color;
        textColor.a = 0f;
        waveNumberText.color = textColor;

        StartCoroutine(SpawnWave());
        OnSpawn?.Invoke(this, new OnSpawnEventArgs(this));
    }

    void Update()
    {
        if (zombiesRemaining <= 0)
        {
            StartNextWave();
        }

        if(waveNumber == 6)
        {
            SceneManager.LoadScene("YouWin");
        }

        if(Input.GetKeyDown("J"))
        {
            waveNumber = 5;
        }
    }

    void StartNextWave()
    {
        waveNumber++;
        waveNumberText.text = "Wave " + waveNumber.ToString();

        zombiesPerWave += 3;
        zombiesRemaining = zombiesPerWave;

        StartCoroutine(FadeTextInAndOut(waveNumberText));


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

        switch (waveNumber)
        {
            case 1:
                Instantiate(zombiePrefab1, spawnPoint.position, spawnPoint.rotation);
                break;
            case 2:
                Instantiate(zombiePrefab2, spawnPoint.position, spawnPoint.rotation);
                break;
            case 3:
                Instantiate(zombiePrefab3, spawnPoint.position, spawnPoint.rotation);
                break;
            case 4:
                Instantiate(zombiePrefab4, spawnPoint.position, spawnPoint.rotation);
                break;
            case 5:
                Instantiate(zombiePrefab4, spawnPoint.position, spawnPoint.rotation);
                break;
        }
            
    }

    void UpdateUI()
    {
        zombiesRemainingText.text = "Zombies Until Next Wave: " + zombiesRemaining.ToString();
    }

    IEnumerator FadeTextInAndOut(TextMeshProUGUI text)
    {
        float fadeInDuration = 1f; // adjust the duration to your liking
        float fadeOutDuration = 1f; // adjust the duration to your liking
        float elapsedTime = 0f;

        while (elapsedTime < fadeInDuration)
        {
            float alpha = Mathf.Lerp(0f, 1f, elapsedTime / fadeInDuration);
            Color color = text.color;
            color.a = alpha;
            text.color = color;

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        yield return new WaitForSeconds(2f); // adjust the wait time to your liking

        elapsedTime = 0f;

        while (elapsedTime < fadeOutDuration)
        {
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeOutDuration);
            Color color = text.color;
            color.a = alpha;
            text.color = color;

            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }
}



