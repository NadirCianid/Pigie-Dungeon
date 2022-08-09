using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WandAim : MonoBehaviour
{
    [SerializeField] Camera FPcamera;
    [SerializeField] float raycastRange = 100f;

   public Quaternion RaycastProccessing(Transform transform)
    {
        RaycastHit hit;
        if (Physics.Raycast(FPcamera.transform.position, FPcamera.transform.forward, out hit, raycastRange))
        {
            Vector3 direction = (hit.point - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            return transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, 5); 
        }
        else return transform.rotation;
    }
}
