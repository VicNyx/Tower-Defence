using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Idle-Go To Objective", menuName = "Enemy Logic/Idle Logic/Go To Objective")]
public class EnemyIdleObjective : EnemyIdleSOBase
{
    private float disToObjective;

    public override void DoEnterLogic()
    {
        base.DoEnterLogic();
    }

    public override void DoExitLogic()
    {
        base.DoExitLogic();
    }

    public override void DoFrameUpdateLogic()
    {
        base.DoFrameUpdateLogic();

        //disToObjective = Vector3.Distance(enemy.transform.position, objectiveTransform.transform.position);
        enemy.agent.SetDestination(objectiveTransform.position);
    }

    public override void Initialize(GameObject gameObject, Enemy enemy)
    {
        base.Initialize(gameObject, enemy);
    }

    public override void ResetValues()
    {
        base.ResetValues();
    }
}
