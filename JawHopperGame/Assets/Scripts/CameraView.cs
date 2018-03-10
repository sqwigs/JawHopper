using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraView : MonoBehaviour {

    public GameObject player;

    private Vector3 offset;

	// Use this for initialization
	void Start () {
        offset = new Vector3(0, transform.position.y - player.transform.position.y, 0);
        
	}
	
	// Update is called once per frame
	void LateUpdate () {
       offset = new Vector3 (0, player.transform.position.y + offset.y, 0);
		
	}
}
