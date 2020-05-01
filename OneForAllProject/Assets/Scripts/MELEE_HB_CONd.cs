using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MELEE_HB_CONd : MonoBehaviour
{
    public HeroSwap hs;
     string hero;
    public float damage;

    void Start()
    {
        hs = GameObject.FindGameObjectWithTag("Player").GetComponent<HeroSwap>();
    }

    
    void Update()
    {
        hero = hs.GetCurrentHero();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (hero == "Atlas" && collision.gameObject.tag == "Boss")
        {
            collision.gameObject.GetComponent<BOSSHEALTH>().DecreaseHealth(damage);
        }

        else if (hero == "Justice" && collision.gameObject.tag == "Boss")
        {
            collision.gameObject.GetComponent<BOSSHEALTH>().DecreaseHealth(damage);
        }

        else if (hero == "Calico" && collision.gameObject.tag == "Boss")
        {
            collision.gameObject.GetComponent<BOSSHEALTH>().DecreaseHealth(damage);
        }
        
        else if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Hit Enemy");
            collision.gameObject.GetComponent<Health>().DecreaseHealth(damage);
        }
        else if (collision.gameObject.tag == "Station")
        {
            Debug.Log("Hit Station");
            Destroy(collision.gameObject);
        }

    }
}
