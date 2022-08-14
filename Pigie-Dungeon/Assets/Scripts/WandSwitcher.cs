using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WandSwitcher : MonoBehaviour
{
    [SerializeField] int chosenWand = 0;
    void Update()
    {
        int previousWand = chosenWand;

        ProcessKeyboardInput();
        ProcessMouseScroll();
        
        if(previousWand != chosenWand)
        {
            SwitchWand();
        }

    }

    private void ProcessKeyboardInput()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            chosenWand = 0;
        }
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            chosenWand = 1;
        }
        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            chosenWand = 2;
        }
        if(Input.GetKeyDown(KeyCode.Alpha4))
        {
            chosenWand = 3;
        }
        if(Input.GetKeyDown(KeyCode.Alpha5))
        {
            chosenWand = 4;
        }
    }

    private void ProcessMouseScroll()
    {
        if(Input.GetAxis("Mouse ScrollWheel")>0)
        {
            if(chosenWand == transform.childCount-1)
            {
                chosenWand = 0;
            }
            else
            {
                chosenWand++;
            }
        }

        if(Input.GetAxis("Mouse ScrollWheel")<0)
        {
            if(chosenWand == 0)
            {
                chosenWand = transform.childCount-1;
            }
            else
            {
                chosenWand--;
            }
        }
    }

    private void SwitchWand()
    {
        int currentWand = 0;
        
        foreach(Transform wand in transform)
        {
            if(currentWand == chosenWand)
            {
                wand.gameObject.SetActive(true);
            }   
            else
            {
                wand.gameObject.SetActive(false);
            }
            currentWand++;
        }
    }

    
}
