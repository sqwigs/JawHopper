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
    public float speedModifier = 0.0f;
    public float jumpModifier = 0.0f;

    private float dir = 1;
    private bool grounded;
    private bool jumpKeyDown;
    private bool jumpKeyReleased;
    private int jumpFrames;
    private bool jumping;


    void Start()
    {
        body = GetComponent<Rigidbody>();
        body.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY;
        jumpKeyDown = false;
        jumpFrames = 0;
    }

    private void Update()
    {
        jumpKeyDown = Input.GetKey(KeyCode.Space);
        if (jumpKeyDown)
        {
            if (jumpFrames == 0 && grounded)
            {
                jumpKeyReleased = false;
                jumpFrames = 1;
                dir = -dir;
            }

            if (jumpFrames < 11 && jumpFrames > 0)
            {
                jumping = true;
            }
            else
            {
                jumping = false;
            }
        }
        else
        {
            jumpFrames = 0;
            jumpKeyReleased = true;
            jumping = false;
        }
    }

    void FixedUpdate()
    {
        grounded = false;
        if (CheckCollision(Vector3.down))
            grounded = true;

        float x = sideSpeed * dir;
        if (CheckCollision(Vector3.right) || CheckCollision(Vector3.left))
            x = 0f;

        float y = body.velocity.y; 
        if (jumping)
        {
            jumpFrames++;
            y += (jumpSpeed + jumpModifier);
        }

        body.velocity = new Vector3(x, y, 0f);
        Vector3 gravity = gravityScale * Vector3.down;
        body.AddForce(gravity, ForceMode.Acceleration);
    }

    private bool CheckCollision(Vector3 direction)
    {
        RaycastHit hit;
        if (direction == Vector3.up || direction == Vector3.down)
        {
            if (Physics.Raycast(transform.position, direction, out hit, 0.51f))
            {
                if (hit.collider != null && hit.collider.gameObject.tag == "Map")
                {
                    return true;
                }
            }
        }
        else if (direction == Vector3.right || direction == Vector3.left)
        {
            if (Physics.Raycast(new Vector3(transform.position.x, transform.position.y + 0.49f, transform.position.z), direction, out hit, 0.51f))
            {
                if (hit.collider != null && hit.collider.gameObject.tag == "Map")
                {
                    return true;
                }
            }
            RaycastHit hit2;
            if (Physics.Raycast(new Vector3(transform.position.x, transform.position.y - 0.49f, transform.position.z), direction, out hit2, 0.51f))
            {
                if (hit2.collider != null && hit2.collider.gameObject.tag == "Map")
                {
                    return true;
                }
            }
            RaycastHit hit3;
            if (Physics.Raycast(new Vector3(transform.position.x, transform.position.y, transform.position.z), direction, out hit3, 0.51f))
            {
                if (hit3.collider != null && hit3.collider.gameObject.tag == "Map")
                {
                    return true;
                }
            }
        }
        return false;
    }
}
