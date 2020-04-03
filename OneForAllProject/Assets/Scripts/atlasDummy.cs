using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class atlasDummy : MonoBehaviour
{

    float rockFistMeter;
    float maxMeter; //value to cap meter
    float shieldParryVal;
    public bool isBoulderShieldActive = false;
    public GameObject self;
    public GameObject fistHB;

    private void Start()
    {
        fistHB.SetActive(false);
        shieldParryVal = 1;
        rockFistMeter = 0f;
        maxMeter = 15;
    }


    void Update()
    {
        BoulderShield();
        RockFist();
    }

    void BoulderShield()
    {
        if (Input.GetKeyDown(KeyCode.Q)) //if holding block button
        {
            isBoulderShieldActive = true; //shield is active
        }
        else if (Input.GetKeyUp(KeyCode.Q))
        {
            isBoulderShieldActive = false; //shield is not active
        }
    }

    public void AddToRockFistMeter(float damageValue)//add to meter when Boulder Shield hits projectiles
    {
        rockFistMeter += damageValue;
        if (rockFistMeter > maxMeter)
        {
            rockFistMeter = maxMeter;
        }
    }

    void RockFist()
    {
        if (isBoulderShieldActive == true)
            Debug.Log("Shield up, can't use rock fist");
        else
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Punch");
                float fistDmg = 30 * rockFistMeter;
                fistHB.GetComponent<CollisionKey>().trueDamage = fistDmg;
                fistHB.SetActive(true);
                rockFistMeter = 0; //meter is back to zero;
            }
            else
            {
                fistHB.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isBoulderShieldActive == true)
        {
            AddToRockFistMeter(shieldParryVal);
            collision.gameObject.SetActive(false);
        }
    }
}
