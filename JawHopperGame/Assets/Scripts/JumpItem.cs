using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpItem : MonoBehaviour, BasicItem  {
    public float SpeedModifier
    {
        get
        {
            return 0.0f;
        }
    }

    public float JumpModifier {
        get
        {
            return 1.0f;
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
            //set current Item
            Destroy(this);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}
}
