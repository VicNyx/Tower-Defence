using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WaveAttributes", menuName = "Wave Logic/WaveAttributes")]
public class WaveAttributes : ScriptableObject
{
    [Header("Wave Properties")]
    [SerializeField] private float timeBetweenWaves;
    [SerializeField] private int maxWaveAmount;

    [Header("Enemy Limits")]
    [SerializeField] private int minEnemySpawns;
    [SerializeField] private int maxEnemySpawns;

    public float TimeBetweenWaves => timeBetweenWaves;
    public int MaxWaveAmount => maxWaveAmount;

    public int MinEnemySpawns => minEnemySpawns;
    public int MaxEnemySpawns => maxEnemySpawns;
}
