using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BtnManager : MonoBehaviour {
    public GameObject spawner;
    public AudioSource audio;
    public GameObject deploy;
    public GameObject tutorialtext;
    
    public bool isReady = false;

    bool isFastForward;
    public GameObject fastForwardButton;
    public AudioSource ffAudio;
    public Text ffText;

    private void Awake()
    {
        fastForwardButton.SetActive(false);
    }

    private void Start()
    {
        ffAudio = ffAudio.GetComponent<AudioSource>();
    }

    private void Update()
    {
      if(isReady == true)
        {
            fastForwardButton.SetActive(true);
        }
    }

    public void ready()
    {
        deploy.SetActive(false);
        audio.Play();
        spawner.SetActive(true);
        isReady = true;
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void fastForward()
    {
        if(!isFastForward)
        {
            ffText.text = "Normal Battle Speed!";
            ffAudio.Play();
            Time.timeScale = 2;
            isFastForward = true;
        }

        else if (isFastForward)
        {
            ffText.text = "Fast Forward Battle!";
            ffAudio.Play();
            Time.timeScale = 1f;
            isFastForward = false;
        }
    }

    public void hidePanel()
    {
        tutorialtext.SetActive(false);
    }
}
