using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float chaseRangeRadius;
    [SerializeField] float stoppingDistance;
    [SerializeField] float rotationSpeed = 5f;
    NavMeshAgent navMeshAgent;
    Animator animator;
    PlayerHealth target;

    bool isAggress = false;
    float distanceToTarget = Mathf.Infinity;
    

    void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        target = FindObjectOfType<PlayerHealth>();
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
        distanceToTarget = Vector3.Distance(transform.position, target.transform.position);

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
        FaceTarget();
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
        animator.SetTrigger("Attack");
    }

    private void ChaseTarget()
    {
        navMeshAgent.SetDestination(target.transform.position);
        animator.SetTrigger("Move");
    }

    void FaceTarget()
    {
        Vector3 direction = (transform.position - target.transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, rotationSpeed);
    }
}
