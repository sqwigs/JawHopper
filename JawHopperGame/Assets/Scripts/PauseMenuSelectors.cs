using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuSelectors : MonoBehaviour {

    public string levelSelect;
    public string mainMenu;
    public bool isPaused;
    public GameObject pauseMenuCanvas;

	// Update is called once per frame

    void Start()
    {
        pauseMenuCanvas = GameObject.Find("PauseMenuCanvas");
    }
	void Update () {
		
        if (isPaused)
        {
            pauseMenuCanvas.SetActive(true);
            Time.timeScale = 0f;

        }else{
            pauseMenuCanvas.SetActive(false);
            Time.timeScale = 1f;

        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
        }

	}

    public void ResumeGame()
    {
        isPaused = false;
    }

    public void QuitToMain()
    {
        SceneManager.LoadScene(mainMenu);
    }

}
