using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.HeroAbility
{
    public class OlJusticeAbility : HeroAbilityBase
    {
        public GameObject justarang;
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

        }
        void ThrowJustarang()
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            GameObject thrownRang = Instantiate(justarang, transform) as GameObject;
            thrownRang.transform.position = player.transform.position;
            thrownRang.GetComponent<Justarang>().SetDirection(2f);

        }
    }
}
