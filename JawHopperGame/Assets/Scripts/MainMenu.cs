using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string levelSelect;

    // Update is called once per frame
    void Update()
    {
        Button startButton = GameObject.Find("startButton").GetComponent<Button>();
        Button endButton = GameObject.Find("endButton").GetComponent<Button>();
        Button loadButton = GameObject.Find("loadButton").GetComponent<Button>();

        startButton.onClick.AddListener(StartGame);
        endButton.onClick.AddListener(EndGame);
        loadButton.onClick.RemoveAllListeners();
        loadButton.onClick.AddListener(LoadLevel);

    }

    private void LoadLevel()
    {
        SceneManager.LoadScene(levelSelect);
    }

    private void EndGame()
    {
        //Button endButton = GameObject.Find("endButton").GetComponent<Button>();
        //ColorBlock theColor = endButton.colors;
        //theColor.highlightedColor = Color.blue;
        //theColor.normalColor = Color.cyan;
        //theColor.pressedColor = Color.red;

        //endButton.colors = theColor;

        Application.Quit();
    }

    private void StartGame()
    {
        //Button startButton = GameObject.Find("startButton").GetComponent<Button>();
        //ColorBlock theColor = startButton.colors;
        //theColor.highlightedColor = Color.blue;
        //theColor.normalColor = Color.cyan;
        //theColor.pressedColor = Color.red;

        //startButton.colors = theColor;

        SceneManager.LoadScene("LevelRedux");
    }
}
