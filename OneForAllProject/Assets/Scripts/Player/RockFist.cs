using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockFist : MonoBehaviour
{
    public GameObject player;
    float dmg;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Boss")
        {
            //dmg //= //get rock fist value
            collision.gameObject.GetComponent<BOSSHEALTH>().DecreaseHealth(dmg);
        }
        else if (collision.gameObject.tag == "Enemy")
        {
            //dmg //= //get rock fist value
            collision.gameObject.GetComponent<Health>().DecreaseHealth(dmg);
        }
    }
}
