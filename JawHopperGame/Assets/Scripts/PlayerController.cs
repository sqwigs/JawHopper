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
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 0.55f))
        {
            if (hit.collider.gameObject != null && hit.collider.gameObject.tag == "Map")
            {
                grounded = true;
            }
        }

        float y = body.velocity.y;
        if (jumpKeyDown && jumpKeyReleased && grounded)
        {
            jumpKeyReleased = false;
            dir = -dir;
            y = jumpSpeed;
        }

        body.velocity = new Vector3(sideSpeed * dir, y, 0f);
        Vector3 gravity = gravityScale * Vector3.down;
        body.AddForce(gravity, ForceMode.Acceleration);
    }
}
