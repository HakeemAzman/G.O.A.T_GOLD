using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour
{
    public Animator anim;
    public Animator transitionToBlack;
    public Animator arcticZen;
    public Animator click;

    public AudioSource audio;

    public int i = 0;
    
	// Use this for initialization
	void Start ()
    {
        click = click.GetComponent<Animator>();
        arcticZen = arcticZen.GetComponent<Animator>();
        transitionToBlack = transitionToBlack.GetComponent<Animator>();
        anim = anim.GetComponent<Animator>();

        audio = audio.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(Input.GetMouseButtonDown(0))
        {
            i++;

            StartCoroutine(Proceed());
            audio.Play();
            anim.Play("CameraMove");
            click.Play("Fade");
            arcticZen.Play("ArcticZen");
            transitionToBlack.Play("TransitionToBlack");
        }

        if(Input.GetMouseButtonDown(0) && i == 2)
        {
            StartCoroutine(Skip());
        }
	}

    IEnumerator Proceed()
    {
        yield return new WaitForSeconds(45f);

        SceneManager.LoadScene("MainMenu");
    }

    IEnumerator Skip()
    {
        transitionToBlack.Play("SkipCutscene");

        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene("MainMenu");
    }
}
