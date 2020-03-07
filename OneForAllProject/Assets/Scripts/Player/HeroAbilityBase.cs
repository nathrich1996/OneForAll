using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Player.HeroAbility
{
    public abstract class HeroAbilityBase : MonoBehaviour, IHeroAbility
    {
        public abstract void ActivateFirstAbility();
        public abstract void ActivateSecondAbility();
    }
}
