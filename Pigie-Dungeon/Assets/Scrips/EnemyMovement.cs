using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float chaseRangeRadius;
    [SerializeField] float stoppingDistance;
    NavMeshAgent navMeshAgent;
    bool isAggress = false;
    float distanceToTarget = Mathf.Infinity;


    void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.75F);
        Gizmos.DrawWireSphere(transform.position, chaseRangeRadius);

        Gizmos.color = new Color(1, 1, 1, 0.75F);
        Gizmos.DrawWireSphere(transform.position, stoppingDistance);
    }

    void Update()
    {
        distanceToTarget = Vector3.Distance(transform.position, target.position);

        if(isAggress)
        {
            EngageTarget();
        }
        else if(distanceToTarget <= chaseRangeRadius)
        {
            isAggress = true;
        }
    }

    private void EngageTarget()
    {
        if(distanceToTarget <= navMeshAgent.stoppingDistance)
        {
            Attack();
        }
        else 
        {
            ChaseTarget();
        }
    }

    private void Attack()
    {
        Debug.Log("Attack");
    }

    private void ChaseTarget()
    {
        navMeshAgent.SetDestination(target.position);
    }
}
