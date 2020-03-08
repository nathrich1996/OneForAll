using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace   Player.HeroAbility
{
    public class AtlasAbility : HeroAbilityBase
    {

        float rockFistMeter;
        float maxMeter; //value to cap meter
        bool isBoulderShieldActive = false;
        private void Start()
        {
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
            //Implement rock fist attack here
            rockFistMeter = 0; //meter is back to zero;
        }
        void AddToRockFistMeter(float damageValue)//add to meter when Boulder Shield hits projectiles
        {
            rockFistMeter += damageValue;
            if (rockFistMeter>maxMeter)
            {
                rockFistMeter = maxMeter;
            }
        }

    }
}

