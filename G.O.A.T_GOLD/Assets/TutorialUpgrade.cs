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
    public GameObject thingsToHide;
    public GameObject bossSpawning;
    AudioSource waterAudio;
    public Text seaLvl;

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
        seaLvl.text = ("Sea Level: 2/2");
        anim.SetBool("isUpgrade1", true);
        oldSpawner.SetActive(false);
        newSpawner.SetActive(true);
        isUpgraded = true;
        StartCoroutine(DisableUpgrade());
        StartCoroutine(bossSpawnPanelFalse());
    }

    IEnumerator bossSpawnPanelFalse()
    {
        bossSpawning.SetActive(true);
        yield return new WaitForSeconds(5f);
        bossSpawning.SetActive(false);
    }

    IEnumerator DisableUpgrade()
    {
        yield return new WaitForSeconds(0.3f);
        thingsToHide.gameObject.SetActive(false);
    }
}


