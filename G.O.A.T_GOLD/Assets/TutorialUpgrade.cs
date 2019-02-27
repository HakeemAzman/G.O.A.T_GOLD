using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TutorialUpgrade : MonoBehaviour {

    public Button upgradeButton;
    public bool isUpgraded = false;
    public Animator anim;
    public GameObject newSpawner;
    public GameObject oldSpawner;

    AudioSource waterAudio;

    // Use this for initialization
    void Start ()
    {
        waterAudio = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void upgrade1()
    {
        waterAudio.Play();
        anim.SetBool("isUpgrade1", true);
        oldSpawner.SetActive(false);
        newSpawner.SetActive(true);
        isUpgraded = true;
    }
}
