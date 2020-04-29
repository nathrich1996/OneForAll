using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BOSSHEALTH : MonoBehaviour
{
    public float maxHealth;
    public float curHealth;

    public Slider healthBar;

    void Start()
    {
        maxHealth = 300f;
        curHealth = maxHealth;
        healthBar.value = CalcHealth();
    }


    void Update()
    {
        if (curHealth >= maxHealth) //Exceed Max HP
            curHealth = maxHealth;

        if (curHealth <= 0)
        {
           // SceneManager.LoadScene(/*"SceneName*/);
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
        return curHealth;
    }
}
