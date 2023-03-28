using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClickToMove : MonoBehaviour
{
    private NavMeshAgent navAgent;
    [SerializeField] private GameObject ClickEffect;
    [SerializeField] private float EffectDuration = 2f;

    private void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
    }

    /// <summary>
    /// cast ray and move to
    /// </summary>
    private void MoveToClickPoint(RaycastHit hit)
    {
        navAgent.SetDestination(hit.point); // set destination to hit pos
        CreateClickEffect(hit.point); //create effect at hit pos
    }

    /// <summary>
    /// create effect
    /// </summary>
    private void CreateClickEffect(Vector3 a_v3Pos)
    {
        GameObject go = Instantiate(ClickEffect, a_v3Pos, transform.rotation);
        Destroy(go, EffectDuration);
    }
}