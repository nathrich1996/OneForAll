using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOSSAI : MonoBehaviour
{
    public Transform nukeSpawn, laserSpawn, droneSpawn;
    public GameObject[] spawnees;
    private GameObject spawn;
    private float atkTimer, maxtimer;
    private int roll;

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
            roll = Random.Range(0, 2);
            spawn = spawnees[roll];
            if (roll == 0)
                Instantiate(spawn, nukeSpawn);
            else if (roll == 1)
                Instantiate(spawn, laserSpawn);
            else if (roll == 2)
                Instantiate(spawn, droneSpawn);
            else
                Debug.Log("Gruh Moment");
            atkTimer = maxtimer;
        }
    }
}
