using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Rigidbody body;
    Vector3 velocity;    

    public float jumpSpeed = 10;
    public float sideSpeed = 5;
    public float gravityScale = 10f;

    private float dir = 1;
    private bool grounded;
    private bool jumpKeyDown;
    private bool jumpKeyReleased;


    void Start()
    {
        body = GetComponent<Rigidbody>();
        body.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY;
        jumpKeyDown = false;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            jumpKeyDown = true;
        }
        else
        {
            jumpKeyDown = false;
            if (grounded)
                jumpKeyReleased = true;
        }
    }

    void FixedUpdate()
    {
        grounded = false;
        RaycastHit hit;
        Vector3 pos = new Vector3(transform.position.x + (0.5f * -dir), transform.position.y, transform.position.z);
        if (Physics.Raycast(pos, Vector3.down, out hit, 0.55f))
        {
            if (hit.collider.gameObject.tag == "Map")
            {
                grounded = true;
            }
        }

        if (jumpKeyDown && jumpKeyReleased && grounded)
        {
            Jump();
        }
        else if (grounded)
        {
            Walk();
        }

        Vector3 gravity = gravityScale * Vector3.down;
        body.AddForce(gravity, ForceMode.Acceleration);
    }

    void Jump()
    {
        jumpKeyReleased = false;
        dir = -dir;
        velocity = new Vector3(sideSpeed * dir, jumpSpeed, 0);
        body.velocity = velocity;
    }

    void Walk()
    {
        velocity = new Vector3(sideSpeed * dir, 0, 0);
        body.velocity = velocity;
    }
}
