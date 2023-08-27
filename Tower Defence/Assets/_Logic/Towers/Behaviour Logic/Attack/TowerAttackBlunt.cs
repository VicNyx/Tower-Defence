using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Attack-Blunt", menuName = "Tower Logic/Attack Logic/Blunt")]
public class TowerAttackBlunt : TowerAttackSOBase
{
    [SerializeField] private GameObject bullet;

    [SerializeField] private float timeBetweenShots = 2f;
    [SerializeField] private float timeTillExit = 3f;
    [SerializeField] private float distanceToCountExit = 3f;

    private float timer;
    private float exitTimer;

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

        if (timer > timeBetweenShots)
        {
            timer = 0f;

            // Instantiate a ranged projectile and fire it at enemy position
        }

        if (Vector3.Distance(enemyTransform.position, tower.transform.position) > distanceToCountExit)
        {
            exitTimer += Time.deltaTime;

            if (exitTimer > timeTillExit)
            {
                tower.stateMachine.ChangeState(tower.idleState);
            }
        }

        else
        {
            exitTimer = 0f;
        }

        timer += Time.deltaTime;
    }

    public override void Initialize(GameObject gameObject, Tower tower)
    {
        base.Initialize(gameObject, tower);
    }

    public override void ResetValues()
    {
        base.ResetValues();
    }
}
