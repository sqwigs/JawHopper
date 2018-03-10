using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraView3 : MonoBehaviour {

    public GameObject player;

    private Vector3 offset;

    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate () {
        transform.position = new Vector3(transform.position.x, player.transform.position.y, -27);
	}
}
