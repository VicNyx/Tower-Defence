using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAttackSOBase : ScriptableObject
{
    protected Tower tower;
    protected Transform transform;
    protected GameObject gameObject;

    protected Transform enemyTransform;

    public virtual void Initialize(GameObject gameObject, Tower tower)
    {
        this.gameObject = gameObject;
        transform = gameObject.transform;
        this.tower = tower;

        enemyTransform = GameObject.FindGameObjectWithTag("Enemy").transform;
    }

    public virtual void DoEnterLogic() { }
    public virtual void DoExitLogic() { ResetValues(); }
    public virtual void DoFrameUpdateLogic() { }
    public virtual void ResetValues() { }
}
