using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadAristides()
    {
        //SceneManager.LoadScene();
    }
    public void LoadHeroPuzzle()
    {
        SceneManager.LoadScene(1);
    }
    public void LoadAFOPuzzle()
    {
        //SceneManager.LoadScne();
    }
}
