using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    // Start is called before the first frame update
    public void ExitToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
