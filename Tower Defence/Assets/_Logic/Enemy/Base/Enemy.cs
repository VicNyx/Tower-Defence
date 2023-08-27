using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour, IDamage, IEnemyMovable, IEnemyTriggerCheckable
{
    public NavMeshAgent agent { get; set; }

    public enum Armour { Shielded, Armoured, Unarmoured }
    public Armour armour;

    #region Trigger Check Bools
    public bool isAggroed { get; set; }
    public bool isWithinStrikingDistance { get; set; }
    #endregion

    #region Movement Floats
    [SerializeField] private float speedMod;
    [SerializeField] private float accelerationMod;
    [SerializeField] private float angularMod;
    #endregion

    #region Health Floats
    public float maxHealth { get; set; }
    public float currentHealth { get; set; }
    #endregion

    #region ScriptableObjects Variables
    [SerializeField] private EnemyIdleSOBase enemyIdleBase;
    [SerializeField] private EnemyChaseSOBase enemyChaseBase;
    [SerializeField] private EnemyAttackSOBase enemyAttackBase;

    public EnemyIdleSOBase enemyIdleBaseInstance { get; set; }
    public EnemyChaseSOBase enemyChaseBaseInstance { get; set; }
    public EnemyAttackSOBase enemyAttackBaseInstance { get; set; }
    #endregion

    #region State Machine Variables
    public EnemyStateMachine stateMachine { get; set; }
    public EnemyIdleState idleState { get; set; }
    public EnemyChaseState chaseState { get; set; }
    public EnemyAttackState attackState { get; set; }
    #endregion

    void Awake()
    {
        enemyIdleBaseInstance = Instantiate(enemyIdleBase);
        enemyChaseBaseInstance = Instantiate(enemyChaseBase);
        enemyAttackBaseInstance = Instantiate(enemyAttackBase);

        stateMachine = new EnemyStateMachine();

        idleState = new EnemyIdleState(this, stateMachine);
        chaseState = new EnemyChaseState(this, stateMachine);
        attackState = new EnemyAttackState(this, stateMachine);
    }

    private void Start()
    {
        currentHealth = maxHealth;

        agent = GetComponent<NavMeshAgent>();

        enemyIdleBaseInstance.Initialize(gameObject, this);
        enemyChaseBaseInstance.Initialize(gameObject, this);
        enemyAttackBaseInstance.Initialize(gameObject, this);

        stateMachine.Initialize(idleState);

        SetModifiers();
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
        agent.speed = speedMod;
        agent.acceleration = accelerationMod;
        agent.angularSpeed = angularMod * 1000f;
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

    public void SetStrikingDistanceBool(bool withinStrikingDistance)
    {
        isWithinStrikingDistance = withinStrikingDistance;
    }

    #endregion
}
