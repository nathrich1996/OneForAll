using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LWCol : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "LaserWall")
        {
            Debug.Log("Collide!");
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
