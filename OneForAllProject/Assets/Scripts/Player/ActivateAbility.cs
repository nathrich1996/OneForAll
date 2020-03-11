using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player.HeroAbility;

public class ActivateAbility : MonoBehaviour
{
     HeroSwap hs;
    // Start is called before the first frame update
    void Start()
    {
        hs = gameObject.GetComponent<HeroSwap>();
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
        if (Input.GetKeyDown("Q"))
        {
            hs.currentSet.ActivateFirstAbility();
        }
        else if (Input.GetKeyDown("E"))
        {
            hs.currentSet.ActivateSecondAbility();
        }
    }
    void CheckForSwap()
    {
        if (Input.GetKeyDown("1") && hs.currentHero != "Justice") //Activate Old Justice
        {
            hs.SwitchAbility("Justice");
        }
        else if (Input.GetKeyDown("2") && hs.currentHero != "Atlas") //Activate Atlas
        {
            hs.SwitchAbility("Atlas");
        }
        else if (Input.GetKeyDown("3") && hs.currentHero != "Calico") //Activate Calico 
        {
            hs.SwitchAbility("Calico");
        }
    }
}
