using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Justarang : MonoBehaviour
{
    public float projSpeed = 300f;
    Rigidbody2D rb;
    float timer = 0;
    bool isDestroyed;
    void Start()
    {
        isDestroyed = false;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDestroyed)
        {
            timer += Time.deltaTime;
            if (timer >= 6f)
            {
                timer = 0;
                Destroy(this.gameObject);
                isDestroyed = true;
            }
        }
    }
    private void FixedUpdate()
    {
        if (!isDestroyed)
        {
            rb.AddForce(new Vector2(projSpeed * Time.deltaTime, 0));
            transform.Rotate(0, 0, 800f * Time.deltaTime);
        }
    }
    
    public void SetDirection(float speed) //Positive for right, negative for left.
    {
        projSpeed *= speed;
    }
}
