using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public static bool GameIsPaused = false;

    public GameObject pauseMenuScreen;
    public GameObject transition;
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
	}

    public void Resume ()
    {
        pauseMenuScreen.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause ()
    {
        pauseMenuScreen.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void ToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void ToEncyclopedia()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Encyclopedia");
    }

    public void ToMainLevel()
    {
        transition.gameObject.SetActive(true);
        Time.timeScale = 1f;
        StartCoroutine(waitTransition());
    }

    public void SkipTutorial()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainLevel");
    }

    IEnumerator waitTransition()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("MainLevel");
    }
}
