using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;
    public float GetHP{ get{ return hitPoints;} }
    Animator animator;

    private void Awake() 
    {
        animator = GetComponent<Animator>();
    }

    public void TakeDamage(float amountOfDecreasing)
    {
        hitPoints -= amountOfDecreasing;
        if(hitPoints <= 0)
        {
            animator.SetTrigger("Die");
            Destroy(gameObject, 2);
        }
    }
}
