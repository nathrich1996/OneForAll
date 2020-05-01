using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.HeroAbility
{
    public class CalicoAbility : HeroAbilityBase
    {   
        //Cat in a Hat variables
        public GameObject cat;
         GameObject currentCat;
        GameObject player ;
        float timer = 0f;
        bool spawned = false;

        //Cat Dash variables
        public GameObject controllerSource;
        private float getSpeed, dashStop = 0.05f, dashmaxtimer, dashtimer;
        bool dashed = false;
        Rigidbody2D rb;

        public override void ActivateFirstAbility()
        {
            CatinAHat();
        }
        public override void ActivateSecondAbility()
        {
            CalicoDash();
        }
        private void Awake()
        {
            player = GameObject.FindGameObjectWithTag("Player");
            dashmaxtimer = 1;
            dashtimer = dashmaxtimer;
            rb = player.GetComponent<Rigidbody2D>();
        }
        private void Update()
        {
            if(spawned)
            {
                timer += Time.deltaTime;
                if (timer >= 3f)
                {
                    Destroy(currentCat);
                    timer = 0;
                    spawned = false;
                }
            }
            if (dashed)
            {
                 rb.MovePosition(new Vector2(transform.position.x + 3, transform.position.y));
                 dashed = false;
            }
        }
        void CatinAHat()
        {
            if (!spawned)
            {
                SpawnCat();
            }
            else
            {
                player.GetComponent<Rigidbody2D>().MovePosition(currentCat.transform.position);
                Destroy(currentCat);
            }
        }
        void SpawnCat()
        {
            currentCat = Instantiate(cat, transform) as GameObject;
            currentCat.transform.position = player.transform.position;
            if (player.GetComponent<PlayerController>().GetMoveState() == PlayerMove.right)
            {
                currentCat.GetComponent<CatInAHat>().SetDirection(1f);
            }
            else if (player.GetComponent<PlayerController>().GetMoveState() == PlayerMove.left)
            {
                currentCat.GetComponent<CatInAHat>().SetDirection(-1f);
                currentCat.transform.Rotate(new Vector3 (0, 180, 000));
            }
            spawned = true;
        }
        void CalicoDash()
        {
            dashed = true;
        }
    }
}


