using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour

{
    //Components
    private Rigidbody2D RigidBody;
    private BoxCollider2D boxCollider;

    //raycast variables
    [SerializeField] private LayerMask platformLayerMask;
    public Color rayColor;

    public float moveSpeed = 5f;
    public float HorizontalMove = 0f;
    public bool Grounded = true;


    //base jump
    [Range(1, 10)]
    public float jumpVelocity;

    //better jump variables
    public float fallMultiplier = 2f;
    public float lowJumpMultiplier = 2f;

    // Start is called before the first frame update
    void Start()
    {
        RigidBody = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private bool isGrounded()
    {
        //cast ray down from center of boxcollider, at a distance half the length of box collider (+ extraHeight). Only hits platfrom layer.
        float extraHeight = .5f;
        RaycastHit2D hit = Physics2D.Raycast(boxCollider.bounds.center, Vector2.down, boxCollider.bounds.extents.y + extraHeight, platformLayerMask);

        //if something is hit, check if it's tagged "Ground" to return true and false if tagged different. If hit is null (still airbourne), then return false.
        if (hit.collider != null)
        {
            Debug.Log("colliding with " + hit.collider.tag);
            if (hit.collider.tag == "Ground")
            {
                rayColor = Color.green;
                return true;
            } else
            {
                return false;
            }
        }
        else
        {
            rayColor = Color.red;
            return false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //movement
        HorizontalMove = Input.GetAxisRaw("Horizontal") * moveSpeed;
        Vector3 movement = new Vector3(HorizontalMove, 0f, 0f);
        transform.position += movement * Time.deltaTime;

        //update whether the player is grounded
        Grounded = isGrounded();

        Debug.DrawRay(transform.position, Vector2.down, rayColor);
        Debug.Log("Grounded = " + Grounded);

        //base jump
        if (Input.GetButtonDown("Jump") && Grounded)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpVelocity;
        }

        Debug.Log("Player velocity " + RigidBody.velocity.y);

        //better jump
        if (RigidBody.velocity.y < 0)
        {
            RigidBody.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (RigidBody.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            RigidBody.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }
}