using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wand : MonoBehaviour
{ 
    [SerializeField] ParticleSystem castingVFX;
    [SerializeField] Orbs orbsPool;
    [SerializeField] OrbType orbType;
    [SerializeField] float castDelay;
    [SerializeField] float damage = 10f;
    public float GetDamage{ get{ return damage; } }
    bool isCasting = false; 
    WandAim wandAim;
    

    void Awake() 
    {
        wandAim = GetComponentInParent<WandAim>();
    }

    private void OnEnable() 
    {
        isCasting = false;
    }

    void Update()
    {
        transform.rotation = wandAim.RaycastProccessing(transform);

        if(Input.GetButtonDown("Fire1") && orbsPool.GetOrbsAmmount(orbType) > 0 && !isCasting)
        {
            StartCoroutine(Cast());
        }
    }

    private IEnumerator Cast()
    {
        isCasting = true;
        orbsPool.UseOrb(orbType);
        CastingVFX();
        yield return new WaitForSecondsRealtime(castDelay);
        isCasting = false;
    }

    private void CastingVFX()
    {
        castingVFX.Play();
    }

    
}
