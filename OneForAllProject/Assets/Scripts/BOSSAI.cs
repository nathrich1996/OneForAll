using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOSSAI : MonoBehaviour
{
    public Transform nukeSpawn, laserSpawn, droneSpawn;
    public GameObject laser, tacticalNuke, drone;
    private float atkTimer, maxtimer, roll;

    void Start()
    {
        maxtimer = 3;
        atkTimer = maxtimer;
    }

    
    void Update()
    {
        atkTimer -= Time.deltaTime;
        if(atkTimer <= 0)
        {
            roll = Random.Range(1, 3);
            if (roll == 1)
                Boss_Missile();
            else if (roll == 2)
                Boss_Laser();
            else if (roll == 3)
                Boss_Drone();
            else
                Debug.Log("Gruh Moment");
            atkTimer = maxtimer;
        }
    }

    void Boss_Missile()
    {
        Instantiate(tacticalNuke, nukeSpawn);
    }

    void Boss_Laser()
    {
        Instantiate(laser, laserSpawn);
    }

    void Boss_Drone()
    {
        Instantiate(drone, droneSpawn);
    }
}
