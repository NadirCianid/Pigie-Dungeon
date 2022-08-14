using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;
    public float GetHP{ get{ return hitPoints;} }
    Animator animator;
    NavMeshAgent navMeshAgent;

    private void Awake() 
    {
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    public void TakeDamage(float amountOfDecreasing)
    {
        BroadcastMessage("ProcessDamage");
        hitPoints -= amountOfDecreasing;
        if(hitPoints <= 0)
        {
            navMeshAgent.enabled = false;
            GetComponent<EnemyAI>().enabled = false;
            enabled = false;
            animator.SetTrigger("Die");
            
        }
    }
}
