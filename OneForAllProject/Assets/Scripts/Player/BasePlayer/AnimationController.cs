using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static PlayerController.PlayerController;

public class AnimationController : MonoBehaviour
{
    public Animator animator;
    public PlayerController PlayerControllerScript;
    public SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        PlayerControllerScript = GetComponent<PlayerController>();
        sprite = GetComponent<SpriteRenderer>();
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
    }
}
