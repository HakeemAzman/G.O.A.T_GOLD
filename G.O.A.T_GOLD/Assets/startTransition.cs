using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startTransition : MonoBehaviour {

    public GameObject transitionStart;
	// Use this for initialization
	void Start () {
        StartCoroutine(disableAfter());
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator disableAfter()
    {
        yield return new WaitForSeconds(1f);
        transitionStart.gameObject.SetActive(false);
    }
}
