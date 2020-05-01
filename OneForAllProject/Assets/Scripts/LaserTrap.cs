using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTrap : MonoBehaviour
{
    public GameObject laser;
    public float speed;
    public void SpawnLaser()
    {
        GameObject spawnedLaser = Instantiate(laser, transform) as GameObject;
        spawnedLaser.GetComponent<LaserWall>().SetSpeed(speed);
    }
}
