using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
    public GameObject zombiePrefab;
    public Transform spawnPoint;
    public TextMeshProUGUI zombiesRemainingText;
    public TextMeshProUGUI waveNumberText;

    private int waveNumber = 0;
    private int zombiesPerWave = 10;
    private int zombiesRemaining = 0;

    void Start()
    {
        zombiesRemaining = zombiesPerWave;
        UpdateUI();
        waveNumberText.text = "Wave: " + waveNumber.ToString();
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
        Instantiate(zombiePrefab, spawnPoint.position, spawnPoint.rotation);
        zombiesRemaining--;
        UpdateUI();
    }

    void UpdateUI()
    {
        zombiesRemainingText.text = "Zombies Until Next Wave: " + zombiesRemaining.ToString();
    }
}


