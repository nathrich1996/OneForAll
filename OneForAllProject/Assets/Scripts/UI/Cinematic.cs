using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cinematic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("WaitCinematic");
    }

    IEnumerator WaitCinematic()
    {
        yield return new WaitForSeconds(4);
        SceneController.LoadNextLevel();
    }
}
