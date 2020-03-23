using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Player.HeroAbility
{
    
    public class CircleAbility : HeroAbilityBase
    {
        public GameObject red;
        public GameObject blue;
        public override void ActivateFirstAbility()
        {
            GameObject newRed = Instantiate(red, GameObject.FindGameObjectWithTag("Player").transform) as GameObject;
            newRed.transform.position = GameObject.FindGameObjectWithTag("Player").transform.position;
            Debug.Log("Red Fired");
        }
        public override void ActivateSecondAbility()
        {
            GameObject newBlue = Instantiate(blue, GameObject.FindGameObjectWithTag("Player").transform) as GameObject;
            newBlue.transform.position = GameObject.FindGameObjectWithTag("Player").transform.position;
            Debug.Log("Blue Fired");
        }
    }
}
