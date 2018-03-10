using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Button startButton = GameObject.Find("startButton").GetComponent<Button>();
        Button endButton = GameObject.Find("endButton").GetComponent<Button>();

        startButton.onClick.AddListener(startGame);
        endButton.onClick.AddListener(endGame);

    }

    private void endGame()
    {
        //Button endButton = GameObject.Find("endButton").GetComponent<Button>();
        //ColorBlock theColor = endButton.colors;
        //theColor.highlightedColor = Color.blue;
        //theColor.normalColor = Color.cyan;
        //theColor.pressedColor = Color.red;

        //endButton.colors = theColor;

        Application.Quit();
    }

    private void startGame()
    {
        //Button startButton = GameObject.Find("startButton").GetComponent<Button>();
        //ColorBlock theColor = startButton.colors;
        //theColor.highlightedColor = Color.blue;
        //theColor.normalColor = Color.cyan;
        //theColor.pressedColor = Color.red;

        //startButton.colors = theColor;

        SceneManager.LoadScene("Level1");
    }
}
