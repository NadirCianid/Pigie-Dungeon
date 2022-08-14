using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cast : MonoBehaviour
{
    [SerializeField] GameObject castSplash;
    [SerializeField] ParticleSystem castParticleSystem;
    List<ParticleCollisionEvent> collisionEvents = new List<ParticleCollisionEvent>();
    void OnParticleCollision(GameObject other) 
    {
        int events = castParticleSystem.GetCollisionEvents(other, collisionEvents);

        for(int i=0; i <= 0 ; i++)
        {
            GameObject splash = Instantiate(castSplash, collisionEvents[i].intersection,
            Quaternion.LookRotation(collisionEvents[i].normal));
            Destroy(splash, 1);
        }
        EnemyHealth target = other.transform.GetComponent<EnemyHealth>();
    
        if (target == null) return;
        
        Wand weapon = transform.parent.parent.GetComponent<Wand>();
        target.TakeDamage(weapon.GetDamage);
        
        Debug.Log(target.GetHP);
    }
}
