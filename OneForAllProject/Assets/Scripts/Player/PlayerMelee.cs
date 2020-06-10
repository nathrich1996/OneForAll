using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMelee : MonoBehaviour
{
    private GameObject Gpcontroller;
    public GameObject meleeHB;
    public bool fhit = false;

    void Start()
    {
        Gpcontroller = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (Gpcontroller.GetComponent<PlayerController>().playerMoveState == PlayerMove.right)
        {
            meleeHB.transform.position = new Vector2(Gpcontroller.transform.position.x + 50, Gpcontroller.transform.position.y);
        }
        else
        {
            meleeHB.transform.position = new Vector2(Gpcontroller.transform.position.x - 50, Gpcontroller.transform.position.y);
        }

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
