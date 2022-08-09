using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wand : MonoBehaviour
{ 
    [SerializeField] ParticleSystem castingVFX;
    [SerializeField] ManaPool manaPool;
    [SerializeField] int manaCost;
    
    [SerializeField] float damage = 10f;
    public float GetDamage{ get{ return damage; } }
    WandAim wandAim;

    void Awake() 
    {
        wandAim = GetComponentInParent<WandAim>();
    }


    void Update()
    {
        transform.rotation = wandAim.RaycastProccessing(transform);

        if(Input.GetButtonDown("Fire1") && manaPool.GetManaPoints >= manaCost )
        {
            Cast();
        }
    }

    private void Cast()
    {
        manaPool.UseMana(manaCost);
        CastingVFX();
    }

    private void CastingVFX()
    {
        castingVFX.Play();
    }

    
}
