﻿using System.Collections;
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
        if (player != null)
        {
            float newY = player.transform.position.y;
            if (newY < 7.5)
                newY = 7.5f;
            transform.position = new Vector3(transform.position.x, newY, -10);
        }
	}
}
