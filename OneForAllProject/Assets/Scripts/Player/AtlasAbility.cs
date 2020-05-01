using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace   Player.HeroAbility
{
    public class AtlasAbility : HeroAbilityBase
    {

        float rockFistMeter;
        float maxMeter; //value to cap meter
        float shieldParryVal;
        public  bool isBoulderShieldActive = false;
        public GameObject self;
        public GameObject fistHB;

        private void Start()
        {
            fistHB.SetActive(false);
            shieldParryVal = 1;
            rockFistMeter = 0f;
            maxMeter = 15;
        }
        public override void ActivateFirstAbility()
        {
            BoulderShield();
        }
        public override void ActivateSecondAbility()
        {
            RockFist();
        }

        void BoulderShield()
        {
            if (Input.GetKeyDown("Q")) //if holding block button
            {
                isBoulderShieldActive = true; //shield is active
            }
            else if (Input.GetKeyUp("Q"))
            {
                isBoulderShieldActive = false; //shield is not active
            }
        }
        void RockFist()
        {
            if (isBoulderShieldActive == true)
                Debug.Log("Shield up, can't use rock fist");
            else
            {
                if (Input.GetKeyDown("E"))
                {
                    Debug.Log("Punch");
                    float fistDmg = 30 * rockFistMeter;
                    fistHB.GetComponent<CollisionKey>().trueDamage = fistDmg;
                    fistHB.SetActive(true);
                    fistHB.SetActive(false);
                    rockFistMeter = 0; //meter is back to zero;
                }
            }
        }
        public void AddToRockFistMeter(float damageValue)//add to meter when Boulder Shield hits projectiles
        {
            rockFistMeter += damageValue;
            if (rockFistMeter>maxMeter)
            {
                rockFistMeter = maxMeter;
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
}

