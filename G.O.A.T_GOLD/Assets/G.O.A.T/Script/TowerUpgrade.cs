using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerUpgrade : MonoBehaviour
{
    CurrencySystem cs;
    public Animator anim;
    public bool isUpgradable;
    public bool isUpgradable2;
    public bool isUpgradable3;
    public bool isUpgradable4;
    public bool isNewSpawner;
    public GameObject upgrade;
    public GameObject upgrade2;
    public GameObject upgrade3;
    public GameObject upgrade4;
    public GameObject newSpawner;
    public GameObject oldSpawner;
    public GameObject thingsToHide;
    public GameObject bossSpawning;
    public Text upgradeText;
    public Text seaLevel;

    AudioSource waterAudio;

    // Use this for initialization
    void Start()
    {
        waterAudio = GetComponent<AudioSource>();
        cs = FindObjectOfType<CurrencySystem>();
        anim = GetComponent<Animator>();
        isUpgradable = false;
        isUpgradable2 = false;
        isUpgradable3 = false;
        isUpgradable4 = false;
        isNewSpawner = false;
        upgradeText.text = "100";
    }

    private void Update()
    {
        if (isUpgradable2)
            upgradeText.text = "250";
        if (isUpgradable3)
            upgradeText.text = "400";
        if (isUpgradable4)
            upgradeText.text = "550";

        if (isNewSpawner)
        {
            newSpawner.SetActive(true);
        }
    }

    public void Upgrade1()
    {
        if (cs.bubblesCount >= 100)
        {
            isUpgradable = true;

            if (isUpgradable == true)
            {
                waterAudio.Play();
                cs.bubblesCount -= 100;
                anim.SetBool("canUpgrade", true);
                isUpgradable2 = true;
                StartCoroutine(coolDown());
                upgrade.gameObject.SetActive(false);
                seaLevel.text=("Sea Level: 2/5");
            }
        }
    }

    public void Upgrade2()
    {
        if (cs.bubblesCount >= 250 && isUpgradable2)
        {
            waterAudio.Play();
            anim.SetBool("canUpgrade", false);
            cs.bubblesCount -= 250;
            anim.SetBool("canUpgrade2", true);
            isUpgradable3 = true;
            StartCoroutine(coolDown2());
            upgrade2.gameObject.SetActive(false);
            seaLevel.text = ("Sea Level: 3/5");
        }
    }

    public void Upgrade3()
    {
        if (cs.bubblesCount >= 400 && isUpgradable3)
        {
            waterAudio.Play();
            anim.SetBool("canUpgrade2", false);
            cs.bubblesCount -= 400;
            anim.SetBool("canUpgrade3", true);
            isUpgradable4 = true;
            StartCoroutine(coolDown4());
            upgrade3.gameObject.SetActive(false);
            seaLevel.text = ("Sea Level: 4/5");
        }
    }

    public void Upgrade4()
    {
        if (cs.bubblesCount >= 550 && isUpgradable4)
        {
            waterAudio.Play();
            anim.SetBool("canUpgrade3", false);
            cs.bubblesCount -= 550;
            anim.SetBool("canUpgrade4", true);
            StartCoroutine(DisableUpgrade4());
            isNewSpawner = true;
            oldSpawner.SetActive(false);
            seaLevel.text = ("Sea Level: 5/5");
            
            StartCoroutine(bossSpawnPanelFalse());
        }
    }

    IEnumerator DisableUpgrade4()
    {
        yield return new WaitForSeconds(0.3f);
        thingsToHide.gameObject.SetActive(false);
    }
    IEnumerator bossSpawnPanelFalse()
    {
        bossSpawning.SetActive(true);
        yield return new WaitForSeconds(5f);
        bossSpawning.SetActive(false);
    }

    IEnumerator coolDown()
    {
        yield return new WaitForSeconds(5f);
        upgrade2.gameObject.SetActive(true);
    }

    IEnumerator coolDown2()
    {
        yield return new WaitForSeconds(5f);
        upgrade3.gameObject.SetActive(true);
    }

    IEnumerator coolDown3()
    {
        yield return new WaitForSeconds(5f);
        upgrade3.gameObject.SetActive(true);
    }

    IEnumerator coolDown4()
    {
        yield return new WaitForSeconds(5f);
        upgrade4.gameObject.SetActive(true);
    }
}
