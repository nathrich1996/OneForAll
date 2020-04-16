using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMelee : MonoBehaviour
{
    public GameObject meleeHB;

    void Start()
    {
        
    }

    void Update()
    {
        Attack();
    }

    void Attack()
    {
        StartCoroutine("Lag");
    }
    IEnumerator Lag()
    {
        // Insert Aninmation Condition Here//
        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("Basic Melee");
            float meatk = 10;
            meleeHB.GetComponent<CollisionKey>().trueDamage = meatk;
            meleeHB.SetActive(true);
            yield return new WaitForSeconds(1);
            meleeHB.SetActive(false);
        }
        else
        {
            meleeHB.SetActive(false);
        }
        
    }
}
