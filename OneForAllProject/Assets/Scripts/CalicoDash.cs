using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalicoDash : MonoBehaviour
{

    bool activated;
    float dashDistance;
    Rigidbody2D rb;
    PlayerController pc;
    void Start()
    {
        activated = false;
        dashDistance = 100f;
        rb = GetComponent<Rigidbody2D>();
        pc = GetComponent<PlayerController>();
    }
    public bool PounceActivity()
    {
        return activated;
    }
    public void ActivatePounce()
    {
        activated = true;
        StartCoroutine("WaitForAnim");
        if (pc.GetMoveState() == PlayerMove.right)
        {
            rb.AddForce(new Vector2(dashDistance * Time.deltaTime, 0));
        }
        if (pc.GetMoveState() == PlayerMove.left)
        {
            rb.AddForce(new Vector2(-1f*dashDistance * Time.deltaTime, 0));
        }
        StartCoroutine("DeActivate");
    }

    IEnumerator DeActivate()
    {
        yield return new WaitForSeconds(2);
        activated = false;
    }
    IEnumerator WaitForAnim()
    {
        yield return new WaitForSeconds(1);
    }
    
}
