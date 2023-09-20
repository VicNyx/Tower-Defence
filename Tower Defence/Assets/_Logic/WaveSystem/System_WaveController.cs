using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class System_WaveController : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private WaveAttributes _waves;
    [SerializeField] private ObjectPool _objects;

    [Header("Spawn Points")]
    [SerializeField] private Transform spawnPoint1;
    [SerializeField] private Transform spawnPoint2;
    [SerializeField] private Transform spawnPoint3;
    [SerializeField] private Transform spawnPoint4;
    [SerializeField] private Transform spawnPoint5;
    [SerializeField] private Transform spawnPoint6;

    [Header("Enemy Prefabs")]
    //1 is attack player, 2 is attack objective
    [SerializeField] private GameObject enemySlash1;
    [SerializeField] private GameObject enemySlash2;
    [SerializeField] private GameObject enemyBlunt1;
    [SerializeField] private GameObject enemyBlunt2;
    [SerializeField] private GameObject enemyPierce1;
    [SerializeField] private GameObject enemyPierce2;

    [Header("Bools")]
    [SerializeField] private bool isWaveActive;

    [Header("Trackers")]
    public int currentWave = 0;

    private void Awake()
    {
        isWaveActive = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (!isWaveActive)
            {
                StartNewWave();
            }
        }

        if(currentWave >= 10)
        {
            SceneManager.LoadScene("VictoryScene");
            
        }
    }

    private IEnumerator SetWaveLogic()
    {
        while (currentWave < _waves.MaxWaveAmount)
        {
            yield return new WaitForSeconds(_waves.TimeBetweenWaves);
            StartCoroutine(SpawnWave());
            currentWave++;
        }

        while (!AllEnemiesCleared())
        {
            yield return null;
        }

        isWaveActive = false;
    }

    private void StartNewWave()
    {
        isWaveActive = true;
        currentWave++;
        StartCoroutine(SetWaveLogic());
    }

    private bool AllEnemiesCleared()
    {
        foreach(var enemySlash1 in _objects.slashEnemy1Pool)
        {
            if(enemySlash1.activeSelf)
            {
                return false;
            }
        }

        foreach (var enemySlash2 in _objects.slashEnemy2Pool)
        {
            if (enemySlash2.activeSelf)
            {
                return false;
            }
        }

        foreach (var enemyBlunt1 in _objects.armourEnemy1Pool)
        {
            if (enemyBlunt1.activeSelf)
            {
                return false;
            }
        }

        foreach (var enemyBlunt2 in _objects.armourEnemy2Pool)
        {
            if (enemyBlunt2.activeSelf)
            {
                return false;
            }
        }

        foreach (var enemyPierce1 in _objects.shieldEnemy1Pool)
        {
            if (enemyPierce1.activeSelf)
            {
                return false;
            }
        }

        foreach (var enemyPierce2 in _objects.shieldEnemy2Pool)
        {
            if (enemyPierce2.activeSelf)
            {
                return false;
            }
        }

        return true;
    }

    private IEnumerator SpawnWave()
    {
        int enemySlash1Count = Random.Range(_waves.MinEnemySpawns, _waves.MaxEnemySpawns + 1);
        int enemySlash2Count = Random.Range(_waves.MinEnemySpawns, _waves.MaxEnemySpawns + 1);
        int enemyBlunt1Count = Random.Range(_waves.MinEnemySpawns, _waves.MaxEnemySpawns + 1);
        int enemyBlunt2Count = Random.Range(_waves.MinEnemySpawns, _waves.MaxEnemySpawns + 1);
        int enemyPierce1Count = Random.Range(_waves.MinEnemySpawns, _waves.MaxEnemySpawns + 1);
        int enemyPierce2Count = Random.Range(_waves.MinEnemySpawns, _waves.MaxEnemySpawns + 1);

        float staggerDelay = Random.Range(_waves.SpawnStaggerMin, _waves.SpawnStaggerMax + 1);

        for (int i = 0; i < enemySlash1Count; i++)
        {
            GameObject enemySlash1 = _objects.GetEnemy1();
            enemySlash1.transform.position = spawnPoint1.position;
            enemySlash1.SetActive(true);
        }

        for (int i = 0; i < enemySlash2Count; i++)
        {
            GameObject enemySlash2 = _objects.GetEnemy2();
            enemySlash2.transform.position = spawnPoint2.position;
            enemySlash2.SetActive(true);
        }

        for (int i = 0; i < enemyBlunt1Count; i++)
        {
            GameObject enemyBlunt1 = _objects.GetEnemy3();
            enemyBlunt1.transform.position = spawnPoint3.position;
            enemyBlunt1.SetActive(true);
        }

        for (int i = 0; i < enemyBlunt2Count; i++)
        {
            GameObject enemyBlunt2 = _objects.GetEnemy4();
            enemyBlunt2.transform.position = spawnPoint4.position;
            enemyBlunt2.SetActive(true);
        }

        for (int i = 0; i < enemyPierce1Count; i++)
        {
            GameObject enemyPierce1 = _objects.GetEnemy5();
            enemyPierce1.transform.position = spawnPoint5.position;
            enemyPierce1.SetActive(true);
        }

        for (int i = 0; i < enemyPierce2Count; i++)
        {
            GameObject enemyPierce2 = _objects.GetEnemy6();
            enemyPierce2.transform.position = spawnPoint6.position;
            enemyPierce2.SetActive(true);
        }

        yield return new WaitForSeconds(staggerDelay);
    }
}

/* @Tysonn J. Smith 2023
 * 
 * 
 * 
 * 
 * 
 * 
 */
