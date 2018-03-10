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
	void Update () {
		
        if (isPaused)
        {
            pauseMenuCanvas.SetActive(true);
        }else{
            pauseMenuCanvas.SetActive(false);
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
        SceneManager.LoadScene(levelSelect);
    }

    public void quitToMain()
    {
        SceneManager.LoadScene(mainMenu);
    }

}
