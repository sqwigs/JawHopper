using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformControllerVertical : MonoBehaviour
{

    Rigidbody body;
    Vector3 velocity;    

    public float jumpSpeed = 10;
    public float sideSpeed = 5;
    public float gravityScale = 10f;
    public BasicItem currentItem;

    private float dir = 1;
    private bool grounded;
    private bool jumpKeyDown;
    private bool jumpKeyReleased;


    void Start()
    {
        body = GetComponent<Rigidbody>();
        body.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY;

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Platform") {
            transform.parent = other.gameObject.transform;
        }
    }

    void OnTriggerExit(Collider other)
    {
        transform.parent = null;
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

        float x = body.velocity.x;

        float bodyy = body.transform.position.y;

        if (bodyy > 15)
        {
            dir = -1;
        }
        else if (bodyy < 1) {
            dir = 1;
        }
   

        body.velocity = new Vector3(0f, sideSpeed * dir, 0f);
        //Vector3 gravity = gravityScale * Vector3.down;
        //body.AddForce(gravity, ForceMode.Acceleration);
    }
}
