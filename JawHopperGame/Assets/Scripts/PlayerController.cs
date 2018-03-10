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
    public float jumpModifier = 0.0f;
    public float speedModifier = 0.0f;

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
        if (CheckCollision(Vector3.down))
            grounded = true;

        float x = sideSpeed * dir;
        if (CheckCollision(Vector3.right) || CheckCollision(Vector3.left))
            x = 0f;

        float y = body.velocity.y + jumpModifier; 
        if (jumpKeyDown && jumpKeyReleased && grounded)
        {
            jumpKeyReleased = false;
            dir = -dir;
            y = jumpSpeed;
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
            if (Physics.Raycast(new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), direction, out hit, 0.51f))
            {
                if (hit.collider != null && hit.collider.gameObject.tag == "Map")
                {
                    return true;
                }
            }
            RaycastHit hit2;
            if (Physics.Raycast(new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z), direction, out hit2, 0.51f))
            {
                if (hit2.collider != null && hit2.collider.gameObject.tag == "Map")
                {
                    return true;
                }
            }
        }
        return false;
    }
}
