using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class EnemyStopState : EnemyState
{
    public EnemyStopState(Enemy enemy, EnemyStateMachine enemyStateMachine) : base(enemy, enemyStateMachine)
    {
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

        enemy.MoveEnemy(UnityEngine.Vector3.zero);

        if (enemy.isTooClose == false && enemy.isAggroed == false)
        {
            enemy.stateMachine.ChangeState(enemy.idleState);
        }

        if (enemy.isTooClose == false && enemy.isAggroed == true)
        {
            enemy.stateMachine.ChangeState(enemy.chaseState);
        }
    }
}
