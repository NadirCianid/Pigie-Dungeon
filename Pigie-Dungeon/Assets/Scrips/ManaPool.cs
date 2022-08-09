using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaPool : MonoBehaviour
{
    [SerializeField] int manaPoints = 10;
    public int GetManaPoints{ get{ return manaPoints;}}


    public void UseMana(int manaAmount)
    {
        manaPoints -= manaAmount;
    }
}
