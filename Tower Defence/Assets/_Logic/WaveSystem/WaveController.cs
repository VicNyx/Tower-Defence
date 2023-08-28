using System.Collections;
using UnityEngine;

public class WaveController : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private WaveAttributes _waves;
    [SerializeField] private ObjectPool objectPool;

    [Header("Spawn Points")]
    [SerializeField] private Transform spawnPoint1;

    [Header("Enemy Prefabs")]
    [SerializeField] private GameObject enemy1;
    [SerializeField] private GameObject enemy2;

    [Header("Bools")]
    [SerializeField] private bool isWaveActive;

    [Header("Wave Trackers")]
    [SerializeField] private int currentWave = 0;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.H))
        {
            if(!isWaveActive)
            {
                StartNewWave();
            }
        }
    }

    private IEnumerator SpawnWaves()
    {
        while(currentWave < _waves.MaxWaveAmount)
        {
            yield return new WaitForSeconds(_waves.TimeBetweenWaves);
            SpawnActualWave();
            currentWave++;
        }

        //wait til the wave is cleared
        while(!AllEnemiesCleared())
        {
            yield return null;
        }

        isWaveActive = false;
    }

    private void SpawnActualWave()
    {
        //spawning a random amount each time
        int enemy1Count = Random.Range(_waves.MinEnemySpawns, _waves.MaxEnemySpawns + 1);
        int enemy2Count = Random.Range(_waves.MinEnemySpawns, _waves.MaxEnemySpawns + 1);

        for(int i = 0; i < enemy1Count; i++) //grabbing enemy from queue and spawning position with a random effect
        {
            GameObject enemy1 = objectPool.GetEnemy1();
            enemy1.transform.position = spawnPoint1.position + Random.insideUnitSphere * 2f; ;
            enemy1.SetActive(true);
        }

        for(int i = 0; i < enemy2Count; i++)
        {
            GameObject enemy2 = objectPool.GetEnemy2();
            enemy2.transform.position = spawnPoint1.position + Random.insideUnitSphere * 2f; ;
            enemy2.SetActive(true);
        }
    }

    private void StartNewWave()
    {
        isWaveActive = true;
        currentWave++;
        StartCoroutine(SpawnWaves());
    }

    private bool AllEnemiesCleared()
    {
        //check if all enemies from wave are deactivated from objectPool
        foreach(var enemy1 in objectPool.enemy1Pool)
        {
            if(enemy1.activeSelf)
            {
                return false;
            }
        }

        foreach (var enemy2 in objectPool.enemy2Pool)
        {
            if (enemy2.activeSelf)
            {
                return false;
            }
        }

        return true;
    }
}
