using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbPickup : MonoBehaviour
{
    [SerializeField] OrbType orbType;
    [SerializeField] int orbAmmount;
    Orbs playerOrbs;
    private void OnTriggerEnter(Collider other) 
    {
        if(other.TryGetComponent<Orbs>(out playerOrbs))
        {
            playerOrbs.IncreaseOrbAmmount(orbType, orbAmmount);
            Destroy(gameObject);
        }
    }
}
