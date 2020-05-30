using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_tacticalnuke : MonoBehaviour
{
    private Transform playerPosition;
    Rigidbody2D rb;
    public float turnRate, nukeVelocity;
    public float dmg = 10, timer, maxtimer;

    void Start()
    {
        maxtimer = 10f;
        timer = 0;
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        GameObject player = GameObject.FindWithTag("Player");
        playerPosition = player.transform;
    }

    
    void FixedUpdate()
    {
        rb.velocity = transform.up * nukeVelocity * Time.deltaTime;
        Vector3 deltaPos = playerPosition.position - transform.position;
        float rotationIndex = Vector3.Cross(deltaPos, transform.up).z;
        rb.angularVelocity = -1 * rotationIndex * turnRate * Time.deltaTime;
        timer += Time.deltaTime;
        if (timer >= maxtimer)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Health>().DecreaseHealth(dmg);
            Destroy(gameObject);
        }
    }
}
