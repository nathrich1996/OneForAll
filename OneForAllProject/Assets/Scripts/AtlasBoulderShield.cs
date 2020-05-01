using Player.HeroAbility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtlasBoulderShield : MonoBehaviour //will be attached to player and feed into Atlas Ability
{
    float shieldParryVal = 2f;
    bool isShieldActive;
    public AtlasAbility ab;
    void Start()
    {
        isShieldActive = false;
    }

    void Update()
    {
        
    }
    public void ActivateShield()
    {
        isShieldActive = true;
    }
    public void DeactivateShield()
    {
        isShieldActive = false;
    }
    public bool ShieldActivity()
    {
        return isShieldActive;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(isShieldActive == true)
        {
            ab.AddToRockFistMeter(shieldParryVal);
            Debug.Log("Building to Sheild");
        }
    }
}
