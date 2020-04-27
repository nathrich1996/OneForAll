using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorLoader : MonoBehaviour //Loads a section of level at time to hopefully get faster loading
{
    public GameObject floorToLoad;
    // Start is called before the first frame update
    void Start()
    {
        floorToLoad.SetActive(false); //don't spawn at start
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag =="Player")//if player walks in
        {
            floorToLoad.SetActive(true); //load section
            Debug.Log("Floor loaded: " + floorToLoad.name);
        }
    }
}
