using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    PlayerHealth target;
    [SerializeField] float damage;
    void Awake()
    {
       target = FindObjectOfType<PlayerHealth>(); 
    }

    public void AttackHitEvent()
    {
        if(target == null) return;
        Debug.Log("I dealed " + damage + " damage to the " + target);
        target.TakeDamage(damage);
    }
}
