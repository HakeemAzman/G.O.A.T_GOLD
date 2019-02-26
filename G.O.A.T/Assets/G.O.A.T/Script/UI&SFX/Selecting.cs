﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Selecting : MonoBehaviour
{
    public GameObject currentlySelected;

    public Vector3 placementPos;
    public Quaternion placementRot;

    public Vector3 turretPos;
    public Quaternion turretRot;

    public FakeCameraMovement fcm;

    [Header ("Deploy and Upgrade Panel")]
    public GameObject deploymentPanel;
    public GameObject upgradeSnowballPanel;
    public GameObject upgradeFishDispencerPanel;
    public GameObject upgradePistonPanel;

    Deployment dScript;
    public bool hasDeleted = true;
    public bool hasHit = false;

    public bool hitButton;

    private void Start()
    {
        deploymentPanel.SetActive(false);
        upgradeSnowballPanel.SetActive(false);
        upgradeFishDispencerPanel.SetActive(false);
        upgradePistonPanel.SetActive(false);
        dScript = FindObjectOfType<Deployment>();
    }

    #region Selection/Deselection
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitGrid = new RaycastHit();
            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitGrid, Mathf.Infinity);
            
            if (hit)
            {               
                 //Debug.Log(hitGrid.collider.name);
                 //Debug.Log(placementRot);
             
                    //Finding object with "deploy" as child
                    if (hitGrid.collider.transform.Find("Deploy"))
                    {
                    hasHit = true;
                    placementPos = hitGrid.collider.transform.position;
                    placementRot = hitGrid.collider.transform.rotation;

                    hasDeleted = true;
                    fcm.enabled = false;

                    //Selecting another object?
                      if (currentlySelected != hitGrid.collider.gameObject)
                      {
                        deploymentPanel.SetActive(true);
                        
                        upgradeSnowballPanel.SetActive(false);
                        upgradeFishDispencerPanel.SetActive(false);
                        upgradePistonPanel.SetActive(false);

                        currentlySelected = hitGrid.collider.gameObject;
                      }
                    }
                
                //Finding object with "Snowball" and deploying Turret
                if (hitGrid.collider.tag == "Snowball")
                {
                    hasDeleted = true;
                    fcm.enabled = false;

                    upgradeFishDispencerPanel.SetActive(false);
                    upgradePistonPanel.SetActive(false);

                    if (currentlySelected != hitGrid.collider.gameObject)
                    {
                        turretPos = hitGrid.collider.transform.position;
                        turretRot = hitGrid.collider.transform.rotation;

                        upgradeSnowballPanel.SetActive(true);

                        if (currentlySelected != null)
                        {
                            upgradeSnowballPanel.SetActive(false);
                        }

                        currentlySelected = hitGrid.collider.gameObject;
                    }
                }


                //Finding object with "Snowball" and deploying Turret
                if (hitGrid.collider.transform.Find("xUpgrade"))
                {
                    Deployment.deployScript.snowUpgradeButton.GetComponent<Button>().interactable = false;
                    Deployment.deployScript.fishUpgradeButton.GetComponent<Button>().interactable = false;
                    Deployment.deployScript.blastUpgradeButton.GetComponent<Button>().interactable = false;
                }

                //Finding object with "PoisonFish" and deploying Turret
                if (hitGrid.collider.tag == "PoisonFish")
                {
                    hasDeleted = true;
                    fcm.enabled = false;

                    upgradeSnowballPanel.SetActive(false);
                    upgradePistonPanel.SetActive(false);

                    if (currentlySelected != hitGrid.collider.gameObject)
                    {
                        turretPos = hitGrid.collider.transform.position;
                        turretRot = hitGrid.collider.transform.rotation;

                        upgradeFishDispencerPanel.SetActive(true);

                        if (currentlySelected != null)
                        {
                            upgradeFishDispencerPanel.SetActive(false);
                        }

                        currentlySelected = hitGrid.collider.gameObject;
                    }
                }

                //Finding object with "Blast Furnace" and deploying Turret
                if (hitGrid.collider.tag == "Piston")
                {
                    hasDeleted = true;
                    fcm.enabled = false;

                    upgradeSnowballPanel.SetActive(false);
                    upgradeFishDispencerPanel.SetActive(false);

                    if (currentlySelected != hitGrid.collider.gameObject)
                    {
                        turretPos = hitGrid.collider.transform.position;
                        turretRot = hitGrid.collider.transform.rotation;

                        upgradePistonPanel.SetActive(true);

                        if (currentlySelected != null)
                        {
                            upgradePistonPanel.SetActive(false);
                        }

                        currentlySelected = hitGrid.collider.gameObject;
                    }
                }

                if (hitButton) return;
             
                if (hitGrid.collider.tag == "Deselect")
                {
                    fcm.enabled = true;

                    upgradeSnowballPanel.SetActive(false);
                    upgradeFishDispencerPanel.SetActive(false);
                    upgradePistonPanel.SetActive(false);
                    deploymentPanel.SetActive(false);

                    if (currentlySelected != null)
                    {
                        deploymentPanel.SetActive(false);

                        currentlySelected = null;
                    }
                }
            }
        }
    }
    #endregion
}
