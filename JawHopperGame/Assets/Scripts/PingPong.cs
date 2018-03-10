using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingPong : MonoBehaviour {
    private Transform attacher;
    public int height = 10;
    public float yCenter = 0f;

	// Use this for initialization
	void Start () {
        attacher = this.transform.Find("SmashBoxAttacher");
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(transform.position.x, yCenter + Mathf.PingPong(Time.time * 2, height) - height / 2f, 0f);
	}
}
