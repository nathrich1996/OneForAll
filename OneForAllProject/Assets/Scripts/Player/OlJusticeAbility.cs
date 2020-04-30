using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.HeroAbility
{
    public class OlJusticeAbility : HeroAbilityBase
    {
        public GameObject justarang;
        public GrappleHook gh;
        public override void ActivateFirstAbility()
        {
            GrappleHook();
        }
        public override void ActivateSecondAbility()
        {
            ThrowJustarang();
        }
        void GrappleHook()
        {
            if(gh.IsInZone())
            {
                gh.ActivateGrappleHook();
            }
        }
        void ThrowJustarang()
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            GameObject throwzone = GameObject.FindGameObjectWithTag("AbilityProjectile");
            GameObject thrownRang = Instantiate(justarang, transform) as GameObject;
            thrownRang.transform.position = throwzone.transform.position;
            if(player.GetComponent<PlayerController>().GetMoveState() == PlayerMove.right)
            {
                thrownRang.GetComponent<Justarang>().SetDirection(1f);
            }
            else if(player.GetComponent<PlayerController>().GetMoveState() == PlayerMove.left)
            {
                thrownRang.GetComponent<Justarang>().SetDirection(-1f);
            }

        }
    }
}
