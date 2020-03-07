using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour

{
    private Rigidbody2D RigidBody;
    public float moveSpeed = 5f;
    float HorizontalMove = 0f;

    // Start is called before the first frame update
    void Start()
    {
        RigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        HorizontalMove = Input.GetAxisRaw("Horizontal") * moveSpeed;
        Vector3 movement = new Vector3(HorizontalMove, 0f, 0f);
        transform.position += movement * Time.deltaTime;
    }
}
