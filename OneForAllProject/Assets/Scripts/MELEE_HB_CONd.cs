using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MELEE_HB_CONd : MonoBehaviour
{
    HeroSwap hs;
    string hero;
    float damage;

    void Start()
    {
        hs = GameObject.FindGameObjectWithTag("Player").GetComponent<HeroSwap>();
    }

    
    void Update()
    {
        hero = hs.GetCurrentHero();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (hero == "Atlas" && collision.gameObject.tag == "Boss")
        {
            damage = 40f;
            collision.gameObject.GetComponent<BOSSHEALTH>().DecreaseHealth(damage);
        }

        if (hero == "Justice" && collision.gameObject.tag == "Boss")
        {
            damage = 20f;
            collision.gameObject.GetComponent<BOSSHEALTH>().DecreaseHealth(damage);
        }

        if (hero == "Calico" && collision.gameObject.tag == "Boss")
        {
            damage = 15f;
            collision.gameObject.GetComponent<BOSSHEALTH>().DecreaseHealth(damage);
        }
    }
}
