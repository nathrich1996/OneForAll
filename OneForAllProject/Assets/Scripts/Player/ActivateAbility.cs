using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player.HeroAbility;

public class ActivateAbility : MonoBehaviour
{
     public HeroSwap hs;
    //public Animator animator;
    public bool qhit = false;
    public bool ehit = false;

    // Start is called before the first frame update
    void Start()
    {
        //hs = gameObject.GetComponent<HeroSwap>();
        //animator = GetComponent<Animator>();
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
            qhit = true;
            hs.currentSet.ActivateFirstAbility();
            GameObject.FindGameObjectWithTag("RockFist").SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            ehit = true;
            hs.currentSet.ActivateSecondAbility();
        }
        if(Input.GetKeyUp(KeyCode.Q)) //Deactivate abilities that need to be held or trigger a box
        {
            GetComponent<AtlasBoulderShield>().DeactivateShield();
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            GetComponent<AtlasBoulderShield>().DeactivateShield();
            GameObject.FindGameObjectWithTag("RockFist").GetComponent<RockFist>().DeactivateRockFist();
            GameObject.FindGameObjectWithTag("RockFist").SetActive(false);
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
