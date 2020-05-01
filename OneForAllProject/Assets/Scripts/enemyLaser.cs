using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyLaser : MonoBehaviour
{
    Rigidbody2D rb;
    public float velX = -7, velY;
    private float tiktok;
    public float dmg = 10;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        tiktok = 0;
    }

   
    void Update()
    {
        rb.velocity = new Vector2(velX, velY);
        if(tiktok > 3.0f)
        {
            Destroy(gameObject);
            Debug.Log("Laser destroyed");
            tiktok = 0f;
            tiktok = 0f;
        }
        else
        {
            tiktok += Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Health>().DecreaseHealth(dmg);
            Destroy(gameObject);
            Debug.Log("Laser hit Player");
        }
    }
}
