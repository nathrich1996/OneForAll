using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*dialogue text box is attached to the canvas and disabled by default, and enabled when needed.*/
public class TextPopUpTrigger : MonoBehaviour
{

    public TextPopUp PopUp;

    void Start()
    {
        //PopUp = FindObjectOfType<TextPopUp>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag =="Player")
        {
            //Debug.Log("Trigger entered.");
            PopUp.FadeIn();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //Debug.Log("Trigger exited");
            PopUp.FadeOut();
        }
    }
}