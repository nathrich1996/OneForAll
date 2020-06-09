using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*dialogue text box is attached to the canvas and disabled by default, and enabled when needed.*/
public class TextPopUp : MonoBehaviour
{
    //set in inspector
    public GameObject TextBoxPopUp;
    public GameObject Dialogue;
    private Text PopUpTxt;
    public Image CharPortrait;

    public Sprite charSprite;
    public string txt;

    // Start is called before the first frame update
    void Start()
    {
        //////////
        /////////
        PopUpTxt = Dialogue.GetComponent<Text>();
        /////////

        //Initialize in inspector (optional)
        PopUpTxt.text = string.Copy(txt);
        CharPortrait.sprite = charSprite;

        //Hide PopUp
        TextBoxPopUp.GetComponent<Image>().canvasRenderer.SetAlpha(0f);
        PopUpTxt.canvasRenderer.SetAlpha(0f);
        CharPortrait.canvasRenderer.SetAlpha(0f);
    }

    public void SetSprite(Sprite SpriteImg)
    {
        CharPortrait.sprite = SpriteImg;
    }

    public void SetText(string txt)
    {
        PopUpTxt.text = string.Copy(txt);
       
    }

    public void FadeIn()
    {
        TextBoxPopUp.GetComponent<Image>().CrossFadeAlpha(1.0f, 1.5f, false);
        PopUpTxt.CrossFadeAlpha(1.0f, 1.5f, false);
        CharPortrait.CrossFadeAlpha(1.0f, 1.5f, false);
    }

    public void FadeOut()
    {
        TextBoxPopUp.GetComponent<Image>().CrossFadeAlpha(0f, 1.5f, false);
        PopUpTxt.CrossFadeAlpha(0f, 1.5f, false);
        CharPortrait.CrossFadeAlpha(0f, 1.5f, false);
    }
}