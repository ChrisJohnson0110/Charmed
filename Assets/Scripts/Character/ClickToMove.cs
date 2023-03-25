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

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MoveToClickPoint();
        }
    }

    private void MoveToClickPoint()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            navAgent.SetDestination(hit.point);
            CreateClickEffect(hit.point);
        }
    }

    private void CreateClickEffect(Vector3 a_v3Pos)
    {
        GameObject go = Instantiate(ClickEffect, a_v3Pos, transform.rotation);
        Destroy(go, EffectDuration);
    }
}