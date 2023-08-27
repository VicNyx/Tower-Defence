using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Attack-Normal", menuName = "Enemy Logic/Attack Logic/Normal")]
public class EnemyAttackNormal : EnemyAttackSOBase
{
    [SerializeField] private float timer;
    [SerializeField] private float timeBetweenAttacks = 2f;

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

        enemy.MoveEnemy(UnityEngine.Vector3.zero);

        if (timer > timeBetweenAttacks)
        {
            timer = 0f;
            // Attack
        }

        timer += Time.deltaTime;
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
