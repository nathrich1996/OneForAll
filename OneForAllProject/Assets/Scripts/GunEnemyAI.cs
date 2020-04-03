using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunEnemyAI : MonoBehaviour
{
    public Transform shootSpot;
    public GameObject laser;
    public GameObject self;
    public Camera playerView;
    Rigidbody2D rb;
    private float timer, maxtimer;   

    void Start()
    {
        maxtimer = 3;
        timer = maxtimer;
    }

    
    void Update()
    {
        ICanSee();
    }

    private void ICanSee()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Vector2 screenpoint = playerView.WorldToScreenPoint(self.transform.position);
            if (screenpoint.x > 0 && screenpoint.x < Screen.width)
            {
                GameObject pewlaser = Instantiate(laser, shootSpot);
            }
            timer = maxtimer;
        }
    }





}
