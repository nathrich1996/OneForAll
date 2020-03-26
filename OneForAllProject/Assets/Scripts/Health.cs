using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float maxHealth;
    public float curHealth;
    public GameObject self;

    public Slider healthBar;

    void Start()
    {
        maxHealth = 100f;
        curHealth = maxHealth;
        healthBar.value = CalcHealth();
    }

   
    void Update()
    {
        if (curHealth >= maxHealth) //Exceed Max HP
            curHealth = maxHealth;

        if (curHealth <= 0) //Death
            //self.SetActive(false);
           
            /* Will probably eventually add conditions that disable
               the activation of hero that is dead and everything else tied to them   */
            Debug.Log("Bruh..");

        if (Input.GetKeyDown(KeyCode.X))
        {
            DecreaseHealth(20f);
        }

    }
    
    public void DecreaseHealth(float dmg)
    {
        curHealth = curHealth - dmg;
        
        Debug.Log("- " + dmg + "HP");
        Debug.Log("HP: " + curHealth);

        healthBar.value = CalcHealth();

    }

    public float CalcHealth()
    {
        return curHealth / maxHealth;
    }
}
