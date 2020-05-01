using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockFist : MonoBehaviour
{
    float dmg;
    bool activated;
    void Start()
    {
        activated= false;
    }

    
    void Update()
    {
        
    }
    public void ActivateRockFist(float damage)
    {
        activated = true;
        dmg = damage;
        Debug.Log("Fist Acivated");
        StartCoroutine("WaitToDeactivate");
    }
    public void DeactivateRockFist()
    {
        //StartCoroutine("WaitToDeactivate");
        activated = false;
        dmg = 1;
        Debug.Log("Fist DeAcivated");
    }
    IEnumerator WaitToDeactivate()
    {
        yield return new WaitForSeconds(1f);
        activated = false;
        dmg = 1;
        Debug.Log("Fist DeAcivated");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Boss" && activated)
        {
            //dmg //= //get rock fist value
            collision.gameObject.GetComponent<BOSSHEALTH>().DecreaseHealth(dmg);
        }
        else if (collision.gameObject.tag == "Enemy" && activated)
        {
            //dmg //= //get rock fist value
            collision.gameObject.GetComponent<Health>().DecreaseHealth(dmg);
        }
        else if (collision.gameObject.tag == "Obstacle" && activated)
        {
            Destroy(collision.gameObject);
            Debug.Log("Destroyed Wall");
        }
    }
}
