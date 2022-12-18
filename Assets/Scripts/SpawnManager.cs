using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    private float spawnRange = 6;
    public int enemyCount;
    public int waveNumber = 1;

    public AudioClip enemySound;
    private AudioSource enemyAudio;
    
    void Start()
    {
        SpawnEnemyWave(waveNumber);
        enemyAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        enemyCount = FindObjectsOfType<EnemyAI>().Length;
        if(enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            enemyAudio.PlayOneShot(enemySound, 1.0f);
        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);

        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);

        return randomPos;
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for(int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }

        if(waveNumber >= 4)
        {
            enemiesToSpawn = 0;
        }
    }
}
