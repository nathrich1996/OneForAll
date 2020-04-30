using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleZone : MonoBehaviour
{
    HeroSwap hs;
    GrappleHook gh;
    public GameObject grappleTarget;
    // Start is called before the first frame update
    void Start()
    {
        hs = GameObject.FindGameObjectWithTag("Player").GetComponent<HeroSwap>();
        gh = GameObject.FindGameObjectWithTag("Player").GetComponent<GrappleHook>();
        grappleTarget.SetActive(false);
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag== "Player") //if OJ enters zone
        {
            Debug.Log("Player in Zone");
            grappleTarget.SetActive(true); //Show icon
            gh.ToggleHookZone(true); //Tell Player is in a Grapple Hook Zone
            gh.SetTargetPosition(grappleTarget.transform); //Put Grapple Icon to Target Location of the Player
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>().orthographicSize = 6f;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && hs.GetCurrentHero() == "Justice") //if OJ leaves zone
        {
            Debug.Log("Player Left Zone");
            grappleTarget.SetActive(false); //Make grapple icon disappear
            gh.ToggleHookZone(false); //Make sure player is not in a hook zone
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>().orthographicSize = 6f;

        }
    }
}
