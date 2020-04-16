using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOSSAI : MonoBehaviour
{
    public Transform nukeSpawn, laserSpawn, ruptSpawn;
    public GameObject laser, tacticalNuke, rupt;
    private float atkTimer, maxtimer;

    void Start()
    {
        maxtimer = 2;
        atkTimer = maxtimer;
    }

    
    void Update()
    {
        atkTimer -= Time.deltaTime;
        if(atkTimer <= 0)
        {
            float roll = Random.Range(1, 3);
            if (roll == 1)
                Boss_Missile();
            else if (roll == 2)
                Boss_Laser();
            else if (roll == 3)
                Boss_Rupture();
            else
                Debug.Log("Gruh Moment");
            atkTimer = maxtimer;
        }
    }

    void Boss_Missile()
    {

    }

    void Boss_Laser()
    {

    }

    void Boss_Rupture()
    {

    }
}
