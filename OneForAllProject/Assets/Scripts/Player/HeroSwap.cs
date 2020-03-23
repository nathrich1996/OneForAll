﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player.HeroAbility;

//namespace Player.HeroAbility
//{
    public class HeroSwap : MonoBehaviour //Class to maintain what needs to be swapped
    {
        //List of Each Hero's Necessities
        List<IHeroAbility> abilitySets =  new List<IHeroAbility>();
        public Sprite[] heroSprites;
        public GameObject[] heroObjects;

        //Current Hero Active Variables
        [HideInInspector]
        public IHeroAbility currentSet;
        [HideInInspector]
        public SpriteRenderer currentSprite;
        string currentHero; //Either Justice, Atlas, or Calico
        

        //Cooldown Variables
        bool onCooldown;
        bool[] heroCooldown = new bool[3];
        float cooldownTimer = 0f;
        int heroIndex;
        // Start is called before the first frame update
        void Start()
        {
            onCooldown = false;
            InitializeHeroSet();
            currentHero = "Justice";
            currentSprite = GetComponent<SpriteRenderer>();
            heroIndex = 0;
            for (int i= 0; i < heroCooldown.Length; i++)
            {
                heroCooldown[i] = false;
            }
        }

        // Update is called once per frame
        void Update()
        {
            //if (onCooldown)
            //{
            //    cooldownTimer += Time.deltaTime;
            //    if (cooldownTimer >= 3)
            //    {
            //        DisableCooldown();
            //    }
            //}
        }
        void InitializeHeroSet()
        {
            for(int i = 0; i < heroObjects.Length; i++)
            {
            Debug.Log(heroObjects[i].gameObject.name + " in hero set");
                abilitySets.Add(heroObjects[i].gameObject.GetComponent<IHeroAbility>()); 
            }
            currentSet = abilitySets[0];
    }
        public void SwitchAbility(string heroName)
        {
            switch(heroName)
            {
                case "Justice":
                    //if (!heroCooldown[0])
                    //{
                        currentSet = abilitySets[0];
                        heroCooldown[0] = true;
                        onCooldown = true;
                        currentSprite.sprite = heroSprites[0];
                        heroIndex = 0;
                    //}
                    break;
                case "Atlas":
                    //if (!heroCooldown[1])
                    //{
                        currentSet = abilitySets[1];
                        heroCooldown[1] = true;
                        onCooldown = true;
                        currentSprite.sprite = heroSprites[1];
                        heroIndex = 1;
                    //}
                    break;
                case "Calico":
                    //if (!heroCooldown[2])
                    //{
                        currentSet = abilitySets[2];
                        heroCooldown[2] = true;
                        onCooldown = true;
                        currentSprite.sprite = heroSprites[2];
                    //}
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
                    heroCooldown[i] = false;
                }
            }
        }
    public string GetCurrentHero()
    {
        return currentHero;
    }
    }
//}
