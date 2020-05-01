using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public static class SceneController
{
    // Start is called before the first frame update
    public static void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Update is called once per frame
    public static void LoadGameOver()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        if (currentScene != 2)//boss scene 
        {
            SceneManager.LoadScene(6);//load boss game over scene
        }
        else //load regular game over
        {
            SceneManager.LoadScene(5); //load regular game over
        }
    }
}
