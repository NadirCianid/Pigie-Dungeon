using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbs : MonoBehaviour
{
    [System.Serializable]
    private class OrbSlot
    {
        public OrbType orbType;
        public int orbsAmmount;
    }


    [SerializeField] OrbSlot[] orbSlots;
    private OrbSlot GetOrbSlot(OrbType orbType)
    {
        foreach (OrbSlot slot in orbSlots)
        {
            if(slot.orbType == orbType)
            {
                return slot;
            }
        }
        return null;
    }

    public int GetOrbsAmmount(OrbType orbType)
    {
        return GetOrbSlot(orbType).orbsAmmount;
    }
    
    public void UseOrb(OrbType orbType)
    {
        GetOrbSlot(orbType).orbsAmmount--;
    }

    public void IncreaseOrbAmmount(OrbType orbType, int orbAmmount)
    {
        GetOrbSlot(orbType).orbsAmmount+= orbAmmount;
    }
}
