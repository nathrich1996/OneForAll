using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleHook : MonoBehaviour
{

    bool isHooking = false;
    public float grappleSpeed = 20f;
    Transform targetPosition;
    
    // Update is called once per frame
    void Update()
    {
        if (isHooking)
        {
            GrappleToObject();
        }
    }

    public void ActivateGrappleHook()
    {
        isHooking = true;
    }
    public void DeactivateGrappleHook()
    {
        isHooking = false;
    }
    public void SetTargetPosition(Transform target)
    {
        targetPosition = target;
    }
    void GrappleToObject()
    {
        if (transform.position.y < targetPosition.position.y)
        {
            //transform.position = Vector2.MoveTowards(
            //    transform.position, targetPosition.position, grappleSpeed * Time.deltaTime);
            transform.position = Vector2.Lerp(transform.position, targetPosition.position, grappleSpeed * Time.deltaTime);
            
        }
        else //reached the grapple hook point
        {
            DeactivateGrappleHook();
        }
    }
}
