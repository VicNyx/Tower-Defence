using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour, ITowerTriggerCheckable
{
    #region State Machine Variables
    public TowerStateMachine stateMachine { get; set; }
    public TowerIdleState idleState { get; set; }
    public TowerAttackState attackState { get; set; }
    #endregion

    #region ScriptableObjects Variables
    [SerializeField] private TowerIdleSOBase towerIdleBase;
    [SerializeField] private TowerAttackSOBase towerAttackBase;

    public TowerIdleSOBase towerIdleBaseInstance { get; set; }
    public TowerAttackSOBase towerAttackBaseInstance { get; set; }
    #endregion

    #region Trigger Check Bools
    public bool isWithinAttackRange { get; set; }
    #endregion

    void Awake()
    {
        towerIdleBaseInstance = Instantiate(towerIdleBase);
        towerAttackBaseInstance = Instantiate(towerAttackBase);

        stateMachine = new TowerStateMachine();

        idleState = new TowerIdleState(this, stateMachine);
        attackState = new TowerAttackState(this, stateMachine);
    }

    // Start is called before the first frame update
    void Start()
    {
        towerIdleBaseInstance.Initialize(gameObject, this);
        towerAttackBaseInstance.Initialize(gameObject, this);

        stateMachine.Initialize(attackState);
    }

    // Update is called once per frame
    void Update()
    {
        stateMachine.currentTowerState.FrameUpdate();
    }
    public void SetAttackRangeBool(bool withinAttackRange)
    {
        isWithinAttackRange = withinAttackRange;
    }

}
