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

    // Start is called before the first frame update
    void Start()
    {
        PlayerControllerScript = GetComponent<PlayerController>();
        sprite = GetComponent<SpriteRenderer>();
        SwapScript = GetComponent<HeroSwap>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("REFERENCE TEST: PLAYER IS GROUNDED?: " + PlayerControllerScript.Grounded);

        animator.SetBool("Grounded", PlayerControllerScript.Grounded);
        animator.SetFloat("MoveX", Mathf.Abs(PlayerControllerScript.HorizontalMove));

        //Flip sprite when direction change
        if (PlayerControllerScript.HorizontalMove < 0)
        {
            sprite.flipX = true;
        }
        else if (PlayerControllerScript.HorizontalMove > 0)
        {
            sprite.flipX = false;
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
