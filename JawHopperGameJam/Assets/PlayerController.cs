using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    Rigidbody body;
    public Vector3 velocity = new Vector3();
    public Transform raycastTarget;

    public float jumpSpeed = 10;
    public float sideSpeed = 5;

    float dir = 1;


	void Start () {
        body = GetComponent<Rigidbody>();
        body.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationZ;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        bool grounded = false;
        RaycastHit hit;


        if (Physics.Raycast(transform.position, Vector3.down, out hit, 0.55f))
        {
            if (hit.collider.gameObject.tag == "Map")
            {
                grounded = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            Jump();          
        }
        else if (grounded)
        {
            Walk();
        }
		
	}

    void Jump()
    {
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
