using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverTrigger : MonoBehaviour {

    public GameObject player;
    public GameObject gameOver;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        gameOver.SetActive(true);
        Destroy(player);
    }
}
