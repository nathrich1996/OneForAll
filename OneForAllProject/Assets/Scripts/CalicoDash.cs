using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalicoDash : MonoBehaviour
{

    public GameObject controllerSource;
    private float getSpeed, dashStop = 0.05f, dashmaxtimer, dashtimer;

    void Start()
    {
        dashmaxtimer = 1;
        dashtimer = dashmaxtimer;
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            dashtimer = 0;
        }
        if (dashtimer < dashmaxtimer)
        {
            controllerSource.GetComponent<PlayerController>().moveSpeed = 20f;
            dashtimer += dashStop;
        }
        else
        {
            controllerSource.GetComponent<PlayerController>().moveSpeed = 5f;
        }
    }
}
