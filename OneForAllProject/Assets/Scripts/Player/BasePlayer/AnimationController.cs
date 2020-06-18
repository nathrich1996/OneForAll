using Player.HeroAbility;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static PlayerController.PlayerController;

public class AnimationController : MonoBehaviour
{
    public Animator animator;
    protected AnimatorOverrideController animatorOverideController;
    public PlayerController PlayerControllerScript;
    public SpriteRenderer sprite;
    public HeroSwap SwapScript;
    public ActivateAbility AbilityScript;
    public PlayerMelee MeleeScript;
    public Health HealthScript;
    //private AnimationClip[] DamageAnim;
    //public AnimationClip[] SwapAnim = new AnimationClip[3];
    //public AnimationClip SwapClip;

    // Start is called before the first frame update
    void Start()
    {
        // overide animator's runtime animator controller with animator overide controller
        //animatorOverideController = new AnimatorOverrideController(animator.runtimeAnimatorController);
        //animator.runtimeAnimatorController = animatorOverideController;

        PlayerControllerScript = GetComponent<PlayerController>();
        sprite = GetComponent<SpriteRenderer>();
        SwapScript = GetComponent<HeroSwap>();
        AbilityScript = GetComponent<ActivateAbility>();
        MeleeScript = GetComponent<PlayerMelee>();
        HealthScript = GetComponent<Health>();
        //load swap and switch Anim clips from inspector
        //DamageAnim = new AnimationClip[3];
        

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

        //Set triggers for animator transitions if their respective hits are true. Reset hits.
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

        if (HealthScript.isDamaged)
        {
            animator.SetTrigger("Damaged");
            HealthScript.isDamaged = false;
        }

        //Atlas Boulder shield hold (adding cooldown condition may enable us to lock him whenever he uses shield if needed)
        if (SwapScript.GetCurrentHero() == "Atlas")
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                animator.SetBool("Shield", true);
                //PlayerControllerScript.MoveLock = true;
               
            }
            else if (Input.GetKeyUp(KeyCode.Q))
            {
                animator.SetBool("Shield", false);
                //PlayerControllerScript.MoveLock = false;
            }
        }

        //resets trigger for melee if player attempts it airbourne
        if (Mathf.Abs(animator.GetFloat("MoveY")) > 0.01f) 
        { 
            animator.ResetTrigger("F"); 

        }


        //prev hero was OJ
        //if (SwapScript.GetCurrentHero() == "Justice" && (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Alpha3)))
        //{
        //    animator.SetTrigger("OJSwitch");
        //    //animatorOverideController.[SwapClip] = SwapAnim[0];
        //}
        ////prev hero was Atlas
        //else if (SwapScript.GetCurrentHero() == "Atlas" && (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Alpha3)))
        //{
        //    //animator.SetTrigger("AtlasSwitch");
        //    //animatorOverideController.[SwapClip] = SwapAnim[0];
        //}
        ////prev hero was Calico
        //else if (SwapScript.GetCurrentHero() == "Calico" && (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Alpha2)))
        //{
        //    animator.SetTrigger("CalicoSwitch");
        //    //animatorOverideController.[SwapClip] = SwapAnim[0];
        //}


        /* If currenthero is x and hero was recently swapped; set appropriate bools for x, and
         * set trigger for the animator to switch to the appropriate animations.
         * The trigger gets set here and then consumed by the transition (to x's animation branch) in the animator.
         * SwapScript.swapped gets set back to false, so trigger doesnt get set every frame causing animations to loop.
         * CURRENT & PREV HERO GETS SET WHEN SWAPPED TRIGGER GETS SET IN SWAPSCRIPT *
         * Switch animation trigger is set using prevhero from swapscript
         */
        if (SwapScript.GetCurrentHero() == "Justice" && SwapScript.swapped)
        {
            animator.SetTrigger("swap");
            animator.SetBool("Justice", true);
            animator.SetBool("Atlas", false);
            animator.SetBool("Calico", false);
            if (SwapScript.GetPrevHero() == "Atlas")
            {
                animator.SetTrigger("AtlasSwitch");
            } else if (SwapScript.GetPrevHero() == "Calico")
            {
                animator.SetTrigger("CalicoSwitch");
            }
                    SwapScript.swapped = false;
        }
        else if (SwapScript.GetCurrentHero() == "Atlas" && SwapScript.swapped)
        {
            animator.SetTrigger("swap");
            animator.SetBool("Justice", false);
            animator.SetBool("Atlas", true);
            animator.SetBool("Calico", false);
            if (SwapScript.GetPrevHero() == "Justice")
            {
                animator.SetTrigger("OJSwitch");
            }
            else if (SwapScript.GetPrevHero() == "Calico")
            {
                animator.SetTrigger("CalicoSwitch");
            }
            SwapScript.swapped = false;
        }
        else if (SwapScript.GetCurrentHero() == "Calico" && SwapScript.swapped)
        {
            animator.SetTrigger("swap");
            animator.SetBool("Justice", false);
            animator.SetBool("Atlas", false);
            animator.SetBool("Calico", true);
            if (SwapScript.GetPrevHero() == "Justice")
            {
                animator.SetTrigger("OJSwitch");
            }
            else if (SwapScript.GetPrevHero() == "Atlas")
            {
                animator.SetTrigger("AtlasSwitch");
            }
            SwapScript.swapped = false;
        }

    }
}
