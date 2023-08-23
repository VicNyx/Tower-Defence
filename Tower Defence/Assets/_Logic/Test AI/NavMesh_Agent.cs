using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMesh_Agent : MonoBehaviour
{
    [Header("Points")]
    [SerializeField] private GameObject playerTransform; //player
    [SerializeField] private GameObject objectiveTransform; //objective
    //towers List

    [Header("Movement Properties")]
    [SerializeField] private float speedMod;
    [SerializeField] private float accelerationMod;
    [SerializeField] private float angularMod;
    [SerializeField] private float stoppingDis;

    [Header("Bools")]
    [SerializeField] private bool isPlayerAlive;
    [SerializeField] private bool playerAttack;
    [SerializeField] private bool objectiveAttack;
    //tower bool

    [Header("Distance Tracker")]
    [SerializeField] private float disToPlayer;
    [SerializeField] private float disToObjective;
    //distance to tower


    private NavMeshAgent agent;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();

        //check for gameobject (player) by tag if not found, throw error
        if(GameObject.FindGameObjectWithTag("Player") != null)
        {
            playerTransform = GameObject.FindGameObjectWithTag("Player");
        }
        else
        {
            Debug.LogError("No object with tag Player found!");
        }

        //check for gameobject (objective) by tag if not found, throw error
        if (GameObject.FindGameObjectWithTag("Objective") != null)
        {
            objectiveTransform = GameObject.FindGameObjectWithTag("Objective");
        }
        else
        {
            Debug.LogError("No object with tag Objective found!");
        }

        //throw error if no navmeshagent found
        if (agent == null )
        {
            Debug.LogError("NavMeshAgent not found!");
        }
        else
        {
            //set modifiers for the agent
            SetModifiers();
        }
    }

    private void SetModifiers()
    {
        agent.speed = speedMod; //movement speed
        agent.acceleration = accelerationMod; //speeding up
        agent.angularSpeed = angularMod * 1000f; //turning speed
        agent.stoppingDistance = stoppingDis; //stopping distance from target
    }

    private void Update()
    {
        FindTarget();
        StopWithinDistance();
    }

    private void FindTarget()
    {
        //check if player is alive
        if (isPlayerAlive)
        {
            //calculate distances between player and objective
            CalculateDistances();

            if (playerAttack)
            {
                //if attacking player, set destination to player pos, updating per frame
                agent.SetDestination(playerTransform.transform.position);
            }
            else if (objectiveAttack)
            {
                //if attacking objective, set destination to objective pos, updating per frame
                agent.SetDestination(objectiveTransform.transform.position);
            }
        }
        else
        {
            //if player not alive, go for the objective
            agent.SetDestination(objectiveTransform.transform.position);
        }
    }

    private void StopWithinDistance()
    {
        //stop if within stopping distance to obj
        if (disToObjective < stoppingDis)
        {
            agent.isStopped = true;
        }

        //stop if within stopping distance to player
        if (disToPlayer < stoppingDis)
        {
            agent.isStopped = true;
        }

        //check if outside the stopping distance to obj and keep moving
        if(disToObjective > stoppingDis)
        {
            agent.isStopped = false;
        }

        //check if outside the stopping distance to player and keep moving
        if (disToPlayer > stoppingDis)
        {
            agent.isStopped = false;
        }
    }

    private void CalculateDistances()
    {
        //tracking the distance between the player or obj using Vector3.Distance
        disToPlayer = Vector3.Distance(transform.position, playerTransform.transform.position);
        disToObjective = Vector3.Distance(transform.position, objectiveTransform.transform.position);
    }
}
/* @Tysonn J. Smith 2023
 * 
 * a basic navmesh set up for the agent to be set to run at either the player or objective, manually set to a prefab before hand through bools
 * having it in update may be expensive, mainly the objective one
 * 
 * checking if player alive before doing any navmesh nav, if dead go for the obj, if alive go for the player if set so
 * finds both the player and objective as long as they are tagged right, even when you drop one in at play, it updates and attacks its target
 * 
 */