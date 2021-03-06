﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserWall : MonoBehaviour
{

    public float speed, maxtimer;
    private float timer;
    Rigidbody2D rb;
    void Start()
    {
        timer = 0;
        rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        rb.velocity = new Vector2(speed, 0);
        timer += Time.deltaTime;
        if(timer >= maxtimer)
        {
            speed = speed * -1;
            timer = 0;
        }
    }
    public void SetSpeed(float s)
    {
        speed = 3;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && !collision.gameObject.GetComponent<ActivateAbility>().AreInvincible())
        {
            collision.gameObject.GetComponent<Health>().DecreaseHealth(12f);
            Debug.Log("Laser hit Player");
        }
    }
}
