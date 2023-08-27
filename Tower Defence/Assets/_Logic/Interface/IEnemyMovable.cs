using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public interface IEnemyMovable
{
    NavMeshAgent agent { get; set; }

    void SetModifiers();
    void MoveEnemy(Vector3 velocity);

}
