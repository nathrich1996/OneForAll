using Player.HeroAbility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static PlayerController.PlayerController;

public class AnimationController : MonoBehaviour
{
    public Animator animator;
    public PlayerController PlayerControllerScript;
    public SpriteRenderer sprite;
    public HeroSwap SwapScript;
    public ActivateAbility AbilityScript;
    public PlayerMelee MeleeScript;
    public AtlasAbility AtlasAbilityScript;

    // Start is called before the first frame update
    void Start()
    {
        PlayerControllerScript = GetComponent<PlayerController>();
        sprite = GetComponent<SpriteRenderer>();
        SwapScript = GetComponent<HeroSwap>();
        AbilityScript = GetComponent<ActivateAbility>();
        MeleeScript = GetComponent<PlayerMelee>();

        AtlasAbilityScript = AbilityScript.GetComponent<AtlasAbility>();

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("REFERENCE TEST: PLAYER IS GROUNDED?: " + PlayerControllerScript.Grounded);

        animator.SetBool("Grounded", PlayerControllerScript.Grounded);
        animator.SetFloat("MoveX", Mathf.Abs(PlayerControllerScript.HorizontalMove));
        animator.SetFloat("MoveY", PlayerControllerScript.VerticalMove);

        //Flip sprite when direction change
        if (PlayerControllerScript.HorizontalMove < 0)
        {
            sprite.flipX = true;
        }
        else if (PlayerControllerScript.HorizontalMove > 0)
        {
            sprite.flipX = false;
        }

        if (AbilityScript.qhit)
        {
            animator.SetTrigger("Q");
            AbilityScript.qhit = false;
        }
        else if (AbilityScript.ehit)
        {
            animator.SetTrigger("E");
            AbilityScript.ehit = false;
        }
        else if (MeleeScript.fhit)
        {
            animator.SetTrigger("F");
            MeleeScript.fhit = false;
        }
        if (SwapScript.GetCurrentHero() == "Atlas")
        {
            animator.SetBool("Shield", AtlasAbilityScript.isBoulderShieldActive);
            //Debug.Log("shield ref = " + AbilityScript.GetComponent<AtlasAbility>().isBoulderShieldActive);

        }
        
        //resets trigger if player attempts to activate an ability/melee while running
        if (animator.GetFloat("MoveX") > 0.01f || Mathf.Abs(animator.GetFloat("MoveY")) > 0.01)
        {
            animator.ResetTrigger("Q");
            animator.ResetTrigger("E");
            animator.ResetTrigger("F");
        }

        /* If currenthero is x and hero was recently swapped; set appropriate bools for x, and
         * set trigger for the animator to switch to the appropriate animations.
         * The trigger gets set here and then consumed by the transition (to x's animation branch) in the animator.
         * SwapScript.swapped gets set back to false, so trigger doesnt get set every frame causing animations to loop.
        */
        if (SwapScript.GetCurrentHero() == "Justice" && SwapScript.swapped)
        {
            animator.SetTrigger("swap");
            animator.SetBool("Justice", true);
            animator.SetBool("Atlas", false);
            animator.SetBool("Calico", false);
            SwapScript.swapped = false;
        }
        else if (SwapScript.GetCurrentHero() == "Atlas" && SwapScript.swapped)
        {
            animator.SetTrigger("swap");
            animator.SetBool("Justice", false);
            animator.SetBool("Atlas", true);
            animator.SetBool("Calico", false);
            SwapScript.swapped = false;
        }
        else if (SwapScript.GetCurrentHero() == "Calico" && SwapScript.swapped)
        {
            animator.SetTrigger("swap");
            animator.SetBool("Justice", false);
            animator.SetBool("Atlas", false);
            animator.SetBool("Calico", true);
            SwapScript.swapped = false;
        }

    }
}
