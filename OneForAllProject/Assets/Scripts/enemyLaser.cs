using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyLaser : MonoBehaviour
{
    Rigidbody2D rb;
    public float velX = -7, velY;
    private float tiktok;

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
        }
        else
        {
            tiktok += Time.deltaTime;
        }
    }
}
