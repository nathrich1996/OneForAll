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
        Debug.Log("Scene: " + currentScene.ToString());
        if (currentScene == 3)//boss scene 
        {
            SceneManager.LoadScene(9);//load boss game over scene
        }
        else //load regular game over
        {
            SceneManager.LoadScene(8); //load regular game over
        }
    }
}
