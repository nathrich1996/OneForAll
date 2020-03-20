using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth;
    public float curHealth;
    public GameObject self;

    void Start()
    {
        curHealth = maxHealth;   
    }

   
    void Update()
    {
        if (curHealth >= maxHealth) //Exceed Max HP
            curHealth = maxHealth;

        if (curHealth <= 0) //Death
            self.SetActive(false);
            /* Will probably eventually add conditions that disable
               the activation of hero that is dead and everything else tied to them   */
    }

    public void DecreaseHealth(float dmg)
    {
        curHealth = curHealth - dmg;
    }
}
