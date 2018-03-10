﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class LevelSelect : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        Button backButton = GameObject.Find("backButton").GetComponent<Button>();
        Button level1 = GameObject.Find("level1").GetComponent<Button>();

        backButton.onClick.AddListener(goBack);
        level1.onClick.AddListener(loadLevel(level1.name));
    }

    private void goBack()
    {
        //SceneManager.LoadScene();
    }

    private UnityAction loadLevel(string name)
    {
        throw new NotImplementedException();
    }
}