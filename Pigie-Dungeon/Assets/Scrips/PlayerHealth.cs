using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float hitPointsAmmount = 100;
    public float GetHPAmmount{ get{ return hitPointsAmmount; } }
    GameManager gameManager;

    void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    public void TakeDamage(float damage)
    {
        hitPointsAmmount -= damage;
        if(hitPointsAmmount <= 0)
        {
            gameManager.ActivateGameOverScreen();
        }
    }
    
}
