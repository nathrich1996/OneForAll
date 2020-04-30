using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMelee : MonoBehaviour
{
    public GameObject meleeHB;
    public bool fhit = false;

    void Start()
    {
        
    }

    void Update()
    {
        Attack();
    }

    void Attack()
    {
        // Insert Aninmation Condition Here//
        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("Basic Melee");
            fhit = true;
            meleeHB.SetActive(true);

        }
        else
        {
            fhit = false;
            meleeHB.SetActive(false);
        }
    }
}
