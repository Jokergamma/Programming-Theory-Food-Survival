using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefab;

    public GameObject[] enemyCount;

    [SerializeField] private TextMeshProUGUI waveNumberText;
    [SerializeField] private int waveNumber = 1;

    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private Button startButton;
    [SerializeField] private GameObject startScreen;

    [SerializeField] private bool isGameActive;

    private float spawnRangeX = 32.3f;
    private float spawnRangeZ = 11.2f;
    // Start is called before the first frame update
    void Start()
    {
        isGameActive = false;
    }
    // Spawning Random Enemies depending on the wave
    void SpawnEnemyWave(int enemiesToSpawn)
    {
       int enemyIndex = Random.Range(0, enemyPrefab.Length);
       for(int i = 0; i < enemiesToSpawn; i++)
       Instantiate(enemyPrefab[enemyIndex], GenerateSpawnPosition(), enemyPrefab[enemyIndex].transform.rotation);
        waveNumberText.text = "Wave Number: " + waveNumber;
    }

    // Update is called once per frame
    void Update()
    {
        if(isGameActive == true)
        {
            SpawnNewWave();
        }
    }
    // Generate a random spawn position for each enemy
    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRangeX, spawnRangeX);
        float spawnPosZ = Random.Range(-spawnRangeZ, spawnRangeZ);

        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);

        return randomPos;
    }
    void SpawnNewWave()
    {
        // Spawn a new wave of enemies once all enemies are taken out
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemyCount.Length == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
        }
    }
    public void StartGame()
    {
        isGameActive = true;
        startScreen.gameObject.SetActive(false);
        SpawnEnemyWave(waveNumber);
    }
}
