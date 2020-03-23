using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player.HeroAbility;

public class ActivateAbility : MonoBehaviour
{
     public HeroSwap hs;
    // Start is called before the first frame update
    void Start()
    {
        //hs = gameObject.GetComponent<HeroSwap>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        CheckForSwap();
        ChecktoActivateAbility();
    }
    void ChecktoActivateAbility()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            hs.currentSet.ActivateFirstAbility();
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            hs.currentSet.ActivateSecondAbility();
        }
    }
    void CheckForSwap()
    {
        if (Input.GetKey(KeyCode.Alpha1) && hs.GetCurrentHero() != "Justice") //Activate Old Justice
        {
            hs.SwitchAbility("Justice");
        }
        else if (Input.GetKey(KeyCode.Alpha2) && hs.GetCurrentHero() != "Atlas") //Activate Atlas
        {
            hs.SwitchAbility("Atlas");
        }
        else if (Input.GetKey(KeyCode.Alpha3) && hs.GetCurrentHero() != "Calico") //Activate Calico 
        {
            hs.SwitchAbility("Calico");
        }
    }
}
