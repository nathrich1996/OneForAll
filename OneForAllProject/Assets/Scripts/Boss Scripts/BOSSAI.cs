using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOSSAI : MonoBehaviour
{
    public Transform nukeSpawn, laserSpawn, droneSpawn;
    public GameObject[] spawnees;
    private Animator BAnimator;
    private GameObject spawn;
    private float atkTimer, maxtimer;
    private int roll;

    void Start()
    {
        maxtimer = 3;
        atkTimer = maxtimer;
        BAnimator = GetComponent<Animator>();
    }

    
    void Update()
    {
        atkTimer -= Time.deltaTime;
        if(atkTimer <= 0)
        {
            roll = Random.Range(0, 2);
            spawn = spawnees[roll];
            if (roll == 0)
            {
                BAnimator.SetTrigger("Rocket");
                Instantiate(spawn, nukeSpawn);
            }
            else if (roll == 1)
            {
                BAnimator.SetTrigger("Laser");
                Instantiate(spawn, laserSpawn);
            }
            else if (roll == 2)
            {
                BAnimator.SetTrigger("Rocket");
                Instantiate(spawn, droneSpawn);
            }
            else
                Debug.Log("Gruh Moment");
            atkTimer = maxtimer;
        }
    }
}
