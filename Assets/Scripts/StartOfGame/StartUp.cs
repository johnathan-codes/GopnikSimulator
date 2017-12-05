using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.StartOfGame;

public class StartUp : MonoBehaviour {

    /* List of Canvases
     * StartUp
     * PaperWork
     * MenuAndStats
     * Missions
     * Shop
     * Inventory
     * Achievements
     */
    public StartUp start;
    public SaveLoad saveLoad;

    #region CanvasDisabler
    public void Start() {
        HideAllCanvases();

        GameObject.Find("Load Game").GetComponent<Button>().interactable = (PlayerPrefs.HasKey("playerFirstName")) ? true : false;
        //PlayerStats playerStats = new PlayerStats(0,0,100,0,0,0);
    }
    #endregion

    #region MenuButtons
    public void NewGame()
    {
        GameObject.Find("btnClick").GetComponent<AudioSource>().Play();

        GameObject.Find("PaperWork").GetComponent<Canvas>().enabled = true;
        GameObject.Find("StartUp").GetComponent<Canvas>().enabled = false;
        //var saveLoad = GetComponent<SaveLoad>();

        //saveLoad.NewGame();
    }

    public void LoadGame()
    {
        if(PlayerPrefs.HasKey("playerFirstName"))
        { 
            GameObject.Find("btnClick").GetComponent<AudioSource>().Play();

            GameObject.Find("MenuAndStats").GetComponent<Canvas>().enabled = true;
            GameObject.Find("PaperWork").GetComponent<Canvas>().enabled = false;
            GameObject.Find("Missions").GetComponent<Canvas>().enabled = false;
            GameObject.Find("Shop").GetComponent<Canvas>().enabled = false;
            GameObject.Find("Inventory_C").GetComponent<Canvas>().enabled = false;
            GameObject.Find("Achievements").GetComponent<Canvas>().enabled = false;
            GameObject.Find("StartUp").GetComponent<Canvas>().enabled = false;
        }
        //var saveLoad = GetComponent<SaveLoad>();

        //else GameObject.Find("Load Game").GetComponent<Button>().interactable = (PlayerPrefs.HasKey("playerFirstName")) ? true : false;
        saveLoad.LoadGame();

    }

    public void HideAllCanvases()
    {
        GameObject.Find("PaperWork").GetComponent<Canvas>().enabled = false;
        GameObject.Find("MenuAndStats").GetComponent<Canvas>().enabled = false;
        GameObject.Find("Missions").GetComponent<Canvas>().enabled = false;
        GameObject.Find("Shop").GetComponent<Canvas>().enabled = false;
        GameObject.Find("Inventory_C").GetComponent<Canvas>().enabled = false;
        GameObject.Find("Achievements").GetComponent<Canvas>().enabled = false;

        GameObject.Find("StartUp").GetComponent<Canvas>().enabled = true;

    }

    public void Credits()
    {

    }
    #endregion
}
