using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPcamera;
    [SerializeField] ParticleSystem castingVFX;
    [SerializeField] float raycastRange = 100f;
    [SerializeField] float damage = 10f;
    public float GetDamage{ get{ return damage; } }


    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Cast();
        }
        
        
    }

    private void Cast()
    {
        //RaycastProccessing();
        CastingVFX();
    }

    private void CastingVFX()
    {
        castingVFX.Play();
        
    }

    private void RaycastProccessing()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPcamera.transform.position, FPcamera.transform.forward, out hit, raycastRange))
        {
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null) return;
            target.TakeDamage(damage);
            Debug.Log(target.GetHP);
        }
        else return;
    }
}
