using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionKey : MonoBehaviour
{
    string[] TagContainter = { "PlayerAttack", "EnemyAttack"};
    string[] AttackName = { "PMelee" /*Insert Ability names here*/ };
    float[] DamageContainer = { 10/*Insert ability damage values here*/ };
    public GameObject self;
    public float trueDamage;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {

        for(int i = 0; i < TagContainter.Length; i++)
        {
            if (collision.gameObject.tag == TagContainter[i])
            {
                if (collision.gameObject.tag == "PlayerAttack" && self.tag == "Player")
                {
                    Debug.Log("Cannot damage self (Player)");
                    break;
                }
                else if (collision.gameObject.tag == "EnemyAttack" && self.tag == "Enemy")
                {
                    Debug.Log("Cannot damage self (Enemy)");
                    break;
                }
                for (int j = 0; j < AttackName.Length; j++)
                {
                    if (collision.gameObject.name == AttackName[j])
                    {
                        trueDamage = DamageContainer[j];
                        self.GetComponent<Health>().DecreaseHealth(trueDamage);
                        Debug.Log("HIT!");
                        StartCoroutine(briefInvincibility());
                        break;
                    }
                }
            }
        }
    }

    IEnumerator briefInvincibility()
    {
        yield return new WaitForSeconds(2);
    }
}
