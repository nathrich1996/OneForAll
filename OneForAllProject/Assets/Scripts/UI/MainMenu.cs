using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Image title;
    private void Start()
    {
        gameObject.SetActive(false);
    }
    public void ToggleMainMenu()
    {
        title.canvasRenderer.SetAlpha(0f);
        gameObject.SetActive(true);
        FadeIn();
    }
    void FadeIn()
    {
        title.CrossFadeAlpha(1.0f, 1.5f, false);
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);   
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    public void MeetHeroes()
    {
        SceneManager.LoadScene(5); //hardcoded val, should replace
    }
    public void Credits()
    {
        SceneManager.LoadScene(6);
    }
    public void HowToPlay()
    {
        SceneManager.LoadScene(7);
    }
}
