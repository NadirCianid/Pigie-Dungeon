using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cast : MonoBehaviour
{
    [SerializeField] GameObject castSplash;
    [SerializeField] ParticleSystem particleSystem;
    List<ParticleCollisionEvent> collisionEvents = new List<ParticleCollisionEvent>();
    void OnParticleCollision(GameObject other) 
    {
        int events = particleSystem.GetCollisionEvents(other, collisionEvents);

        for(int i=0; i <= 0 ; i++)
        {
        Instantiate(castSplash, collisionEvents[i].intersection, Quaternion.LookRotation(collisionEvents[i].normal));
        }
        EnemyHealth target = other.transform.GetComponent<EnemyHealth>();
    
        if (target == null) return;
        
        Weapon weapon = transform.parent.GetComponent<Weapon>();
        target.TakeDamage(weapon.GetDamage);
        
        Debug.Log(target.GetHP);
    }
}
