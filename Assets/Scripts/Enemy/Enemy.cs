using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{

    public EnemySO EnemyProperties;

    NavMeshAgent nmaNavMesh; //nav mesh

    PassiveAI PassiveAIRef;
    FleeingAI FleeingAIRef;
    AggressiveAI AggressiveAIRef;

    Health hHealthRef;

    public enum Behaviours { 
        Passive,
        Fleeing,
        Aggressive
    }

    public Behaviours currentBehaviour;


    // Start is called before the first frame update
    void Start()
    {
        PassiveAIRef = GetComponent<PassiveAI>();
        FleeingAIRef = GetComponent<FleeingAI>();
        AggressiveAIRef = GetComponent<AggressiveAI>();

        nmaNavMesh = GetComponent<NavMeshAgent>(); //get nav mesh agent
        nmaNavMesh.speed = EnemyProperties.MovementSpeed;

        hHealthRef = GetComponent<Health>();
        hHealthRef.health = EnemyProperties.Health;

    }

    // Update is called once per frame
    void Update()
    {
        
        if (hHealthRef.health <= EnemyProperties.FleeingThreshold)
        {
            if (FleeingAIRef.CheckForDanger())
            {
                SetState(Behaviours.Fleeing);
            }
        }




        BehaviourSwitch();
    }


    void BehaviourSwitch()
    {
        switch (currentBehaviour)
        {
            case Behaviours.Passive:

                PassiveAIRef.isWandering = true;

                break;

            case Behaviours.Aggressive:
                


                break;

            case Behaviours.Fleeing:

                FleeingAIRef.isFleeing = true;

                break;

            default:
                Debug.LogError("Unknown behaviour: " + currentBehaviour);
                break;
        }
    }


    /// <summary>
    /// change beha
    /// </summary>
    /// <param name="a_bNewBehaviour"></param>
    public void SetState(Behaviours a_bNewBehaviour)
    {
        if (currentBehaviour != a_bNewBehaviour)
        {
            nmaNavMesh.SetDestination(gameObject.transform.position);
            PassiveAIRef.isWandering = false;
            FleeingAIRef.isFleeing = false;
            //AggressiveAIRef.isAggressive = false;

            currentBehaviour = a_bNewBehaviour;
        }
    }


}
