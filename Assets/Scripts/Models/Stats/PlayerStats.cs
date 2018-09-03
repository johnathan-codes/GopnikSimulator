using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*
namespace Playerino
{*/
public class PlayerStats : CharacterStats
{/*
    void Update()
    {
        //brubles
        brublesText.text = brubles.ToString(); //konvert float na string
        wantedImage.fillAmount = wantedLVL / 5; //každý jeden wanted je 20 %
        //health
        hpImage.fillAmount = currentHealth / 100;
        hpText.text = "HP: " + currentHealth;
        //cancer
        cancerImage.fillAmount = cancer / 100;
        cancerText.text = "CANCER: " + cancer;
        //drunk
        drunkImgae.fillAmount = drunk / 100;
        drunkText.text = "DRUNK: " + drunk;
        //skill
        skillImage.fillAmount = skill.GetValue() / 250;
        skillText.text = "SKILL: " + skill;
    }

    /*
    public static PlayerStats instance;
    public bool startedDecreaseDrunk = false;
    public float brubles, wantedLVL, hp, cancer, drunk, skill;
    public Text brublesText, hpText, cancerText, drunkText, skillText, popUp;
    public Image wantedImage, hpImage, cancerImage, drunkImgae, skillImage;

    //achievements
    public int numberOfMissions;


	void Start () {
        StartCoroutine(DecreaseHealth());
        //StartCoroutine(DecreaseDrunk());
	}

    // Update is called once per frame
    void Update() {
        //brubles
        brublesText.text = brubles.ToString(); //konvert float na string
        wantedImage.fillAmount = wantedLVL / 5; //každý jeden wanted je 20 %
        //health
        hpImage.fillAmount = hp / 100;
        hpText.text = "HP: " + hp;
        //cancer
        cancerImage.fillAmount = cancer / 100;
        cancerText.text = "CANCER: " + cancer;
        //drunk
        drunkImgae.fillAmount = drunk / 100;
        drunkText.text = "DRUNK: " + drunk;
        //skill
        skillImage.fillAmount = skill / 250;
        skillText.text = "SKILL: " + skill;
    #region podmienky hry
        //ak wanted je 5 a viac - reduce money 
        if(wantedLVL >= 5)
        {
            popUp.text = "You were catched" + "\n Money Reduced";
            brubles = brubles / 2;
        }
        //max skill cap je 250
        if (skill > 250) skill = 250;
        //ak padne health pod nulu tak resetni hru
        if(hp <= 0)
        {
            popUp.text = "You died!" ;
            StartUp start = new StartUp();

            start.HideAllCanvases();
            //PlayerPrefs.DeleteAll();
        }

        //ak nezacal odpocitavat drunk lvl tak zacni
        if ((drunk > 0) && (startedDecreaseDrunk))
        {
            StartCoroutine(DecreaseDrunk());
        }
        else if (startedDecreaseDrunk)
        {
            StopCoroutine(DecreaseDrunk());
        }
        //
    #endregion

    }

    public void Save()
    {
        PlayerPrefs.SetFloat("brubles", brubles);
        PlayerPrefs.SetFloat("wantedLVL", wantedLVL);
        PlayerPrefs.SetFloat("hp", hp);
        PlayerPrefs.SetFloat("drunk", drunk);
    }

    public void Load()
    {
        brubles = PlayerPrefs.GetFloat("brubles");
        wantedLVL = PlayerPrefs.GetFloat("wantedLVL");
        hp = PlayerPrefs.GetFloat("hp");
        drunk= PlayerPrefs.GetFloat("drunk");
    }

    IEnumerator DecreaseHealth()
    {
        yield return new WaitForSecondsRealtime(10);
        hp -= 1+(1*cancer);
        StartCoroutine(DecreaseHealth());
    }

    IEnumerator DecreaseDrunk()
    {
        yield return new WaitForSecondsRealtime(10);
        drunk -= 1;
        StartCoroutine(DecreaseDrunk());
    }*/
}

