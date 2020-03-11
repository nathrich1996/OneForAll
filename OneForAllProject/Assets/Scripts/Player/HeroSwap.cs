using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.HeroAbility
{
    public class HeroSwap : MonoBehaviour //Class to maintain what needs to be swapped
    {
        //List of Each Hero's Necessities
        public IHeroAbility[] abilitySets;
        public Sprite[] heroSprites;

        //Current Hero Active Variables
        [HideInInspector]
        public IHeroAbility currentSet;
        public SpriteRenderer currentSprite;
        public string currentHero; //Either Justice, Atlas, or Calico
        

        //Cooldown Variables
        bool onCooldown;
        bool[] heroCooldown;
        float cooldownTimer = 0f;
        // Start is called before the first frame update
        void Start()
        {
            onCooldown = false;
            currentSet = abilitySets[0];
            currentHero = "Justice";
            currentSprite = GetComponent<SpriteRenderer>();
        }

        // Update is called once per frame
        void Update()
        {
            if (onCooldown)
            {
                cooldownTimer += Time.deltaTime;
                if (cooldownTimer >= 3)
                {
                    DisableCooldown();
                }
            }
        }
        public void SwitchAbility(string heroName)
        {
            switch(heroName)
            {
                case "Justice":
                    if (heroCooldown[0])
                    {
                        currentSet = abilitySets[0];
                        heroCooldown[0] = true;
                        onCooldown = true;
                        currentSprite.sprite = heroSprites[0];
                    }
                    break;
                case "Atlas":
                    if (heroCooldown[1])
                    {
                        currentSet = abilitySets[1];
                        heroCooldown[1] = true;
                        onCooldown = true;
                        currentSprite.sprite = heroSprites[1];
                    }
                    break;
                case "Calico":
                    if (heroCooldown[2])
                    {
                        currentSet = abilitySets[2];
                        heroCooldown[2] = true;
                        onCooldown = true;
                        currentSprite.sprite = heroSprites[2];
                    }
                    break;
                  
            }
        }
        public void DisableCooldown()
        {
            cooldownTimer = 0;
            onCooldown = false;
            for (int i = 0; i < heroCooldown.Length; i++)
            {
                if (!heroCooldown[i])
                {
                    heroCooldown[i] = true;
                }
            }
        }
    }
}
