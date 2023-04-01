using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AggressiveAI : MonoBehaviour
{
    public bool isAggressive; //is currently aggressive
    float fAttackRange = 2f; //attack range

    NavMeshAgent agent; //this agent
    GameObject player; // //player ref
    
    LayerMask TargetLayer; // what is a danger
    float AgroRange; // distance that if a danger is within will flee

    GameObject target;

    Enemy EnemySORef; //nav mesh

    private void Start()
    {
        EnemySORef = GetComponent<Enemy>();
        agent = GetComponent<NavMeshAgent>(); //get this agent
        player = GameObject.FindGameObjectWithTag("Player"); //get the player
        TargetLayer = LayerMask.GetMask("FriendlyCreature");
        AgroRange = EnemySORef.EnemyProperties.AgroRange;
    }

    private void Update()
    {
        if (isAggressive == true) //currently aggressive ?
        {
            if (Vector3.Distance(transform.position, player.transform.position) < fAttackRange) //is in range of attack
            {
                Attack(); //attack
            }
            else
            {
                agent.SetDestination(target.transform.position); //chase player
            }
        }
    }

    public void CheckForTarget100f()
    {
        Collider[] dangerColliders = Physics.OverlapSphere(transform.position, 100f, TargetLayer); //find dangers
        if (dangerColliders.Length > 0)
        {
            target = dangerColliders[0].gameObject; //set target
        }
    }

    public bool CheckForTarget()
    {
        Collider[] dangerColliders = Physics.OverlapSphere(transform.position, AgroRange, TargetLayer); //find dangers
        if (dangerColliders.Length > 0)
        {
            target = dangerColliders[0].gameObject; //set target
            return true;
        }
        return false;
    }

    private void Attack()
    {
        Debug.Log("Attack Player");
    }
}
