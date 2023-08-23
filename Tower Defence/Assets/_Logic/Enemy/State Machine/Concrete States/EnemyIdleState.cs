using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : EnemyState
{
    private GameObject objectiveTransform;
    private float disToObjective;

    public EnemyIdleState(Enemy enemy, EnemyStateMachine enemyStateMachine) : base(enemy, enemyStateMachine)
    {
        objectiveTransform = GameObject.FindGameObjectWithTag("Objective");
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

        disToObjective = Vector3.Distance(enemy.transform.position, objectiveTransform.transform.position);
        enemy.agent.SetDestination(objectiveTransform.transform.position);

        if (enemy.isAggroed)
        {
            enemy.stateMachine.ChangeState(enemy.chaseState);
        }

        if (enemy.isTooClose)
        {
            enemy.stateMachine.ChangeState(enemy.stopState);
        }
    }
}
