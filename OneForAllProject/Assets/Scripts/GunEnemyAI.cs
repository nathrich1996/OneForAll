using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunEnemyAI : MonoBehaviour
{
    public Transform shootSpot;
    public GameObject laser;
    public GameObject self;
    public Camera playerView;
    Rigidbody2D rb;
    private IEnumerator coroutine;
    

    void Start()
    {
       
    }

    
    void Update()
    {
        ICanSee();
    }

    private void ICanSee()
    {
        Vector2 screenpoint = playerView.WorldToScreenPoint(self.transform.position);
        if (screenpoint.x > 0 && screenpoint.x < Screen.width)
        {
            coroutine = attackDelay();
            StartCoroutine(coroutine);
        }
    }

    IEnumerator attackDelay()
    {
        yield return new WaitForSecondsRealtime(2);
        Debug.Log("I can see you!");
        GameObject pewlaser = Instantiate(laser, shootSpot);
        Debug.Log("Delay");
        yield return new WaitForSecondsRealtime(2);
    }
}
