using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubmitPPW : MonoBehaviour
{
    public InputField ifFirstName, ifSurname, ifBirthday, ifCountry;
    public Dropdown ddlGender;
    public CharacterStats character;

	public void btnSubmit()
    {
        if ((ifFirstName.text != string.Empty) && (ifSurname.text != string.Empty) && (ifBirthday.text != string.Empty) && (ifCountry.text != string.Empty))
        {
            PlayerPrefs.SetString("playerFirstName", ifFirstName.text);
            PlayerPrefs.SetString("playerSurname", ifSurname.text);
            PlayerPrefs.SetString("playerBirthday", ifBirthday.text);
            PlayerPrefs.SetString("playerCountry", ifCountry.text);
            PlayerPrefs.SetInt("playerGender", ddlGender.value);

            GameObject.Find("PaperWork").GetComponent<Canvas>().enabled = false; // po submite sa zruší paperwork
            GameObject.Find("MenuAndStats").GetComponent<Canvas>().enabled = true; // a zapne base menu

            GameObject.Find("btnClick").GetComponent<AudioSource>().Play();
            character.SetHealth(100);
        }
    }

    public void Update()
    {
        if ((ifFirstName.text == string.Empty) || (ifSurname.text == string.Empty) || (ifBirthday.text == string.Empty) || (ifCountry.text == string.Empty))
        {
            GameObject.Find("ErrorPlease").GetComponent<Text>().enabled = true;
        }else GameObject.Find("ErrorPlease").GetComponent<Text>().enabled = false;
    }
}
