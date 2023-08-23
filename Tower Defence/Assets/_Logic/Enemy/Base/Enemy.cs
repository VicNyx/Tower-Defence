using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour, IDamage, IEnemyMovable, ITriggerCheckable
{
    public NavMeshAgent agent { get; set; }

    #region Trigger Check Bools
    public bool isAggroed { get; set; }
    public bool isTooClose { get; set; }
    #endregion

    #region Movement Floats
    public float speedMod { get; set; }
    public float accelerationMod { get; set; }
    public float angularMod { get; set; }
    #endregion

    #region Health Floats
    public float maxHealth { get; set; }
    public float currentHealth { get; set; }
    #endregion

    #region State Machine Variables
    public EnemyStateMachine stateMachine { get; set; }
    public EnemyIdleState idleState { get; set; }
    public EnemyChaseState chaseState { get; set; }
    public EnemyStopState stopState { get; set; }    
    #endregion

    void Awake()
    {
        stateMachine = new EnemyStateMachine();

        idleState = new EnemyIdleState(this, stateMachine);
        chaseState = new EnemyChaseState(this, stateMachine);
        stopState = new EnemyStopState(this, stateMachine);
    }

    private void Start()
    {
        currentHealth = maxHealth;

        agent = GetComponent<NavMeshAgent>();

        stateMachine.Initialize(idleState);
    }

    private void Update()
    {
        stateMachine.currentEnemyState.FrameUpdate();
    }

    #region Movement Functions
    public void MoveEnemy(Vector3 velocity)
    {
        agent.velocity = velocity;
    }

    public void SetModifiers()
    {
        agent.speed = speedMod; //movement speed
        agent.acceleration = accelerationMod; //speeding up
        agent.angularSpeed = angularMod * 1000f; //turning speed
    }

    #endregion

    #region Health/Die Functions

    public void Damage(float damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0f)
        {
            Die();
        }
    }

    public void Die()
    {
        
    }

    #endregion

    #region Distance Checks

    public void SetAggroStatus(bool aggroed)
    {
        isAggroed = aggroed;
    }

    public void SetStopStatus(bool tooClose)
    {
        isTooClose = tooClose;
    }

    #endregion
}
