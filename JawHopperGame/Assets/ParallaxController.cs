using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxController : MonoBehaviour {

    List<Transform> backgrounds = new List<Transform>();

    float moveSpeed = 1;
    
	void Start () {
		foreach(Transform child in transform)
        {
            backgrounds.Add(child);
        }

        backgrounds.Reverse();
	}
	
	// Update is called once per frame
	void Update () {

        int i = 0;

        Camera cam = Camera.main;

        foreach(Transform obj in backgrounds)
        {
            i++;


            Vector3 pos = new Vector3(transform.position.x, -cam.transform.position.y * (0.1f * i), obj.transform.position.z);

            obj.position = pos;



        }


	}
}
