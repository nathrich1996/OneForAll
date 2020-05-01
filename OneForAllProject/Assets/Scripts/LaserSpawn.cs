using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSpawn : MonoBehaviour
{

    public LaserTrap ls;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ls.SpawnLaser();
        }
    }
}
