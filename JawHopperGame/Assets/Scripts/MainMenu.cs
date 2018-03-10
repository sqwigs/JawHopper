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

        startButton.onClick.AddListener(StartGame);
        endButton.onClick.AddListener(EndGame);

    }

    private void EndGame()
    {
        Application.Quit();
    }

    private void StartGame()
    {
        SceneManager.LoadScene("LevelRedux");
    }
}
