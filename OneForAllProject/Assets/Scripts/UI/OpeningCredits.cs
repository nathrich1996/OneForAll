using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class OpeningCredits : MonoBehaviour
{
    // Start is called before the first frame update
    public MainMenu mm;
    public Image teamImage;
    public Image clubImage;
    private IEnumerator Start()
    {
        //teamImage.GetComponent<Image>();
        //clubImage.GetComponent<Image>();
        teamImage.canvasRenderer.SetAlpha(0f);
        clubImage.canvasRenderer.SetAlpha(0f);
        FadeIn();
        yield return new WaitForSeconds(2f);
        FadeOut();
        yield return new WaitForSeconds(2f);
        mm.ToggleMainMenu();

    }

    // Update is called once per frame
    void FadeIn()
    {
        teamImage.CrossFadeAlpha(1.0f, 1.5f, false);
        clubImage.CrossFadeAlpha(1.0f, 1.5f, false);
    }
    void FadeOut()
    {
        teamImage.CrossFadeAlpha(0f, 2.5f, false);
        clubImage.CrossFadeAlpha(0f, 2.5f, false);
    }
}
