using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformCollider : MonoBehaviour {
    MeshCollider floor;

    // Use this for initialization
    void Start()
    {
        floor = GetComponentInChildren<MeshCollider>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerEnter(Collider other)
    {
        floor.enabled = false;
    }

    private void OnTriggerExit(Collider other)
    {
        floor.enabled = true;
    }

}
