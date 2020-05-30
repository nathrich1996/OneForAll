using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace   Player.HeroAbility
{
    public class AtlasAbility : HeroAbilityBase
    {

        float rockFistMeter; //multiplier
        float maxMeter; //value to cap meter
        float shieldParryVal;
        public  bool isBoulderShieldActive = false;

        public AtlasBoulderShield abs;
        public RockFist rf; //belongs to empty transform with 
        private void Start()
        {
            //fistHB.SetActive(false);
            shieldParryVal = 1;
            rockFistMeter = 1f;
            maxMeter = 15;
        }
        public override void ActivateFirstAbility()
        {
            BoulderShield();
        }
        public override void ActivateSecondAbility()
        {
            RockFist();
            rockFistMeter = 1;
        }

        void BoulderShield()
        {
            abs.ActivateShield();
        }
        void RockFist()
        {
            Debug.Log("Punch");
            float fistDmg = 30 * rockFistMeter;
            rockFistMeter = 1; //meter is back to 1;
            rf.ActivateRockFist(fistDmg);
        }
        public void AddToRockFistMeter(float damageValue)//add to meter when Boulder Shield hits projectiles
        {
            rockFistMeter += damageValue;
            if (rockFistMeter>maxMeter)
            {
                rockFistMeter = maxMeter;
            }
        }

       

    }
}

