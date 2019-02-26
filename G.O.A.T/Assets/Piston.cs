﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Piston : MonoBehaviour
{
    [Header ("Blast Furnace Settings")]
    public float pushForce;
    public float pushUpgrade;
    public GameObject spawnHereBox;
    public GameObject spawnHereBox2;
    public BoxCollider boxColl;
    public GameObject gustVFX;
    public GameObject gustVFX2;
    private float spawnHereTimer = 10f;
    public AudioSource audio;
    // Use this for initialization
    void Start ()
    {
        gustVFX.SetActive(false);
        //timeDelay();
        boxColl = GetComponent<BoxCollider>();
        StartCoroutine(timetoWait());
	}

    private void Update()
    {
        spawnHereTimer -= Time.deltaTime;

        if (spawnHereTimer <= 0)
        {
            spawnHereBox.GetComponent<MeshRenderer>().enabled = false;
            spawnHereBox2.GetComponent<MeshRenderer>().enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemies")
        {
            other.GetComponent<Rigidbody>().isKinematic = false;
            other.GetComponent<NavMeshAgent>().enabled = false;
            other.GetComponent<Rigidbody>().AddForce(transform.right * pushForce, ForceMode.Acceleration);
        }
    }

    void timeDelay()
    {
        boxColl.GetComponent<BoxCollider>().enabled = true;
        StartCoroutine(timetoWait());
    }

    IEnumerator timetoWait()
    {
        yield return new WaitForSeconds(1);

        boxColl.gameObject.GetComponent<BoxCollider>().enabled = false;
        gustVFX.SetActive(false);
        gustVFX2.SetActive(false);

        yield return new WaitForSeconds(pushUpgrade);

        audio.Play();
        gustVFX.SetActive(true);
        gustVFX2.SetActive(true);
        timeDelay();
    }
}
