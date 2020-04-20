using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_tacticalnuke : MonoBehaviour
{
    public Transform playerPosition;
    Rigidbody2D rb;
    public float turnRate, nukeVelocity;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
    }

    
    void FixedUpdate()
    {
        rb.velocity = transform.up * nukeVelocity * Time.deltaTime;
        Vector3 deltaPos = playerPosition.position - transform.position;
        float rotationIndex = Vector3.Cross(deltaPos, transform.up).z;
        rb.angularVelocity = -1 * rotationIndex * turnRate * Time.deltaTime;
    }
}
