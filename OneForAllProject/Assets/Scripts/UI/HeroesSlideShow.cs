using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class HeroesSlideShow : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] sections; //first element should always be enabled 
    int enabledIndex;
    void Start()
    {
        sections[0].SetActive(true);
        enabledIndex = 0;
    }

    public void NextSection()
    {
        sections[enabledIndex].SetActive(false); //set current section to be inactive 
        enabledIndex += 1; //move to the next section
        if (enabledIndex >= sections.Length ) //if count goes over length
        {
            enabledIndex = 0; //go back to the first
        }
        sections[enabledIndex].SetActive(true); //enable next section
        EventSystem.current.GetComponent<EventSystem>().SetSelectedGameObject(null);
        Debug.Log("Next Section");
    }
    public void PrevSection()
    {
        sections[enabledIndex].SetActive(false); //set current section to be inactive 
        enabledIndex -= 1; //move to the prev section
        if (enabledIndex < 0) //if count goes under the least index zero
        {
            enabledIndex = sections.Length - 1; //go back to the last
        }
        sections[enabledIndex].SetActive(true); //enable prev section
        EventSystem.current.SetSelectedGameObject(null);
        Debug.Log("Prev Section");
    }
    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
