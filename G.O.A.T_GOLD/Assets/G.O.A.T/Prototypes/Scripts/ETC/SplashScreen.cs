using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour {

    Animator anim;
    bool hasClicked = false;

	// Use this for initialization
	void Start ()
    {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(Input.GetMouseButtonDown(0) && !hasClicked)
        {
            anim.Play("CameraMove");
            hasClicked = true;
        }

        if(Input.GetMouseButtonDown(0) && hasClicked == true)
        {
            StartCoroutine(Skip());
        }
	}

    IEnumerator Skip()
    {
        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene("MainMenu");
    }
}
