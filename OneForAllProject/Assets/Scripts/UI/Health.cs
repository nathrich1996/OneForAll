using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public float maxHealth;
    public float curHealth;
    public bool isDamaged;

    public Slider healthBar;

    void Start()
    {
        maxHealth = 100f;
        curHealth = maxHealth;
        isDamaged = false;
        if (gameObject.tag == "Player")
            healthBar.value = CalcHealth();
    }

   
    void Update()
    {
        if (curHealth >= maxHealth) //Exceed Max HP
            curHealth = maxHealth;

        if (curHealth <= 0) {//Death
            if(gameObject.tag == "Player")
            {
                SceneController.LoadGameOver();
            }
            gameObject.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            DecreaseHealth(20f);
        }

    }
    
    public void DecreaseHealth(float dmg)
    {
        curHealth = curHealth - dmg;

        //Debug.Log("- " + dmg + "HP");
        //Debug.Log("HP: " + curHealth);
        if (gameObject.tag == "Player")
        {
            healthBar.value = CalcHealth();
            isDamaged = true;
        }
    }

    public float CalcHealth()
    {
        return curHealth / maxHealth;
    }
}
