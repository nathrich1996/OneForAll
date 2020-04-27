using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOSSCRAPER : MonoBehaviour
{
    Rigidbody2D rb;
    public float xSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        rb.velocity = new Vector2(xSpeed, 0f);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "SkyDestroyer")
        {
            Destroy(gameObject);
        }
    }
}
