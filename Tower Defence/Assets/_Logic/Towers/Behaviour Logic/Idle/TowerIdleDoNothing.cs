using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Idle-Do Nothing", menuName = "Tower Logic/Idle Logic/Do Nothing")]
public class TowerIdleDoNothing : TowerIdleSOBase
{
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
