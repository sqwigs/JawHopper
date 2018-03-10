using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuSelectors : MonoBehaviour {

    
    public bool isPaused;
    public GameObject pauseMenuCanvas;

	// Update is called once per frame
	void Update () {
		
        if (isPaused)
        {
            pauseMenuCanvas.SetActive(true);
            Time.timeScale = 0f;

        }else{
            pauseMenuCanvas.SetActive(false);
            Time.timeScale = 1f;

        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            isPaused = !isPaused;
        }

	}

    public void ResumeGame()
    {
        isPaused = false;
    }

    public void LevelSelect()
    {
        SceneManager.LoadScene("LevelSelect");
    }

    public void QuitToMain()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
