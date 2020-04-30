﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
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
        SceneManager.LoadScene(2); //hardcoded val, should replace
    }
    public void Credits()
    {
        SceneManager.LoadScene(3);
    }
    public void HowToPlay()
    {
        SceneManager.LoadScene(4);
    }
}
