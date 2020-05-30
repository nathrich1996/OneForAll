using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleHook : MonoBehaviour
{

    bool isHooking = false;
    bool inHookZone = false;
    public float grappleSpeed = 20f;
    Transform targetPosition;
    float hookTime = 0f;
    // Update is called once per frame
    void Update()
    {
        if (isHooking)
        {
            hookTime += Time.deltaTime;
            if (hookTime>.5f)
            {
                DeactivateGrappleHook();
                hookTime = 0f;
            }
                GrappleToObject();
        }
    }

    public void ToggleHookZone(bool isInZone)
    {
        inHookZone = isInZone;
    }
    public void ActivateGrappleHook()
    {
        isHooking = true;
        Debug.Log("Player Grappling");
    }
    public void DeactivateGrappleHook()
    {
        isHooking = false;
        Debug.Log("Player Not Grappling");
    }
    public bool IsHooked()
    {
        return isHooking;
    }
    public bool IsInZone()
    {
        return inHookZone;
    }
    public void SetTargetPosition(Transform target)
    {
        targetPosition = target;
        Debug.Log("Target Position Set");
    }
    void GrappleToObject()
    {
        if (transform.position.y < targetPosition.position.y)
        {
            transform.position = Vector2.Lerp(transform.position, targetPosition.position, grappleSpeed * 2.5f * Time.deltaTime);
            
        }
        else //reached the grapple hook point
        {
            DeactivateGrappleHook();
            Debug.Log("Deactivated grapple hook");
        }
    }
}
