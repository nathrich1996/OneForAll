using Player.HeroAbility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtlasBoulderShield : MonoBehaviour
{
    float shieldParryVal;
    public GameObject self;

    void Start()
    {   
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(self.GetComponent<AtlasAbility>().isBoulderShieldActive == true)
        {
            self.GetComponent<AtlasAbility>().AddToRockFistMeter(shieldParryVal);
            collision.gameObject.SetActive(false);
        }
    }
}
