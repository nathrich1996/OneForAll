using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeBullet : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rb;
    float timer;
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (timer>= 5.0f)
        {
            Destroy(gameObject);
        }
        else
        {
            timer += Time.deltaTime;
        }

    }
    private void FixedUpdate()
    {
        rb.AddForce(new Vector2(30f * Time.deltaTime, 0));
    }
}
