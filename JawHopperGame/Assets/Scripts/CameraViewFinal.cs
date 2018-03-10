using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraViewFinal : MonoBehaviour {

    public GameObject player;

    private Vector3 offset;

    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate () {
        float newY = player.transform.position.y;
        if (newY < 8)
            newY = 8;
        transform.position = new Vector3(transform.position.x, newY, -10);
	}
}
