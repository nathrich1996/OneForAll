using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MELEE_HB_CONd : MonoBehaviour
{
    public HeroSwap hs;
    public string hero;
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
            damage = 40f;
            collision.gameObject.GetComponent<BOSSHEALTH>().DecreaseHealth(damage);
        }

        else if (hero == "Justice" && collision.gameObject.tag == "Boss")
        {
            damage = 20f;
            collision.gameObject.GetComponent<BOSSHEALTH>().DecreaseHealth(damage);
        }

        else if (hero == "Calico" && collision.gameObject.tag == "Boss")
        {
            damage = 15f;
            collision.gameObject.GetComponent<BOSSHEALTH>().DecreaseHealth(damage);
        }
        
        else if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Hit Enemy");
            collision.gameObject.GetComponent<Health>().DecreaseHealth(20f);
        }

    }
}
