using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaseState : EnemyState
{
    private GameObject playerTransform;
    private float disToPlayer;

    public EnemyChaseState(Enemy enemy, EnemyStateMachine enemyStateMachine) : base(enemy, enemyStateMachine)
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player");
    }

    public override void EnterState()
    {
        base.EnterState();
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();

        disToPlayer = Vector3.Distance(enemy.transform.position, playerTransform.transform.position);
        enemy.agent.SetDestination(playerTransform.transform.position);

        if (enemy.isTooClose)
        {
            enemy.stateMachine.ChangeState(enemy.stopState);
        }
    }
}
