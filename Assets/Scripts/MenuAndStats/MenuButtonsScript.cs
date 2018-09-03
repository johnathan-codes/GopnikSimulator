using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.StartOfGame;

public class MenuButtonsScript : MonoBehaviour
{
    //ShopButtons shopButtons = new ShopButtons();
    public SaveLoad saveLoad;// = GameObject.Find(SaveLoad());

    public void OpenMissions()
    {
        GameObject.Find("btnClick").GetComponent<AudioSource>().Play();
        GameObject.Find("Missions").GetComponent<Canvas>().enabled = true;
        GameObject.Find("Shop").GetComponent<Canvas>().enabled = false;
        GameObject.Find("Inventory_C").GetComponent<Canvas>().enabled = false;

        GameObject.Find("btnMissions").GetComponent<Button>().interactable = false;
        GameObject.Find("btnShop").GetComponent<Button>().interactable = true;
        GameObject.Find("btnInventory").GetComponent<Button>().interactable = true;
        GameObject.Find("CurrentCanvas").GetComponent<Text>().text = "MISSIONS";


        GameObject.Find("swCanvas").GetComponent<Canvas>().enabled = false;
        GameObject.Find("lwCanvas").GetComponent<Canvas>().enabled = false;
        GameObject.Find("clCanvas").GetComponent<Canvas>().enabled = false;
        GameObject.Find("coCanvas").GetComponent<Canvas>().enabled = false;
        GameObject.Find("btnSmallWeapons").GetComponent<Button>().interactable = true;
        GameObject.Find("btnLargeWeapons").GetComponent<Button>().interactable = true;
        GameObject.Find("btnClothes").GetComponent<Button>().interactable = true;
        GameObject.Find("btnConsumables").GetComponent<Button>().interactable = true;
    }

    public void OpenShop()
    {
        GameObject.Find("btnClick").GetComponent<AudioSource>().Play();

        GameObject.Find("Missions").GetComponent<Canvas>().enabled = false;
        GameObject.Find("Shop").GetComponent<Canvas>().enabled = true;
        GameObject.Find("Inventory_C").GetComponent<Canvas>().enabled = false;

        GameObject.Find("btnMissions").GetComponent<Button>().interactable = true;
        GameObject.Find("btnShop").GetComponent<Button>().interactable = false;
        GameObject.Find("btnInventory").GetComponent<Button>().interactable = true;

        GameObject.Find("swCanvas").GetComponent<Canvas>().enabled = true;
        GameObject.Find("lwCanvas").GetComponent<Canvas>().enabled = false;
        GameObject.Find("clCanvas").GetComponent<Canvas>().enabled = false;
        GameObject.Find("coCanvas").GetComponent<Canvas>().enabled = false;
        GameObject.Find("btnSmallWeapons").GetComponent<Button>().interactable = false;
        GameObject.Find("btnLargeWeapons").GetComponent<Button>().interactable = true;
        GameObject.Find("btnClothes").GetComponent<Button>().interactable = true;
        GameObject.Find("btnConsumables").GetComponent<Button>().interactable = true;

        GameObject.Find("CurrentCanvas").GetComponent<Text>().text = "SHOP";
    }

    public void OpenInventory()
    {
        GameObject.Find("btnClick").GetComponent<AudioSource>().Play();
        GameObject.Find("Missions").GetComponent<Canvas>().enabled = false;
        GameObject.Find("Shop").GetComponent<Canvas>().enabled = false;
        GameObject.Find("Inventory_C").GetComponent<Canvas>().enabled = true;


        GameObject.Find("btnMissions").GetComponent<Button>().interactable = true;
        GameObject.Find("btnShop").GetComponent<Button>().interactable = true;
        GameObject.Find("btnInventory").GetComponent<Button>().interactable = false;

        GameObject.Find("CurrentCanvas").GetComponent<Text>().text = "INVENTORY";

        GameObject.Find("swCanvas").GetComponent<Canvas>().enabled = false;
        GameObject.Find("lwCanvas").GetComponent<Canvas>().enabled = false;
        GameObject.Find("clCanvas").GetComponent<Canvas>().enabled = false;
        GameObject.Find("coCanvas").GetComponent<Canvas>().enabled = false;
        GameObject.Find("btnSmallWeapons").GetComponent<Button>().interactable = true;
        GameObject.Find("btnLargeWeapons").GetComponent<Button>().interactable = true;
        GameObject.Find("btnClothes").GetComponent<Button>().interactable = true;
        GameObject.Find("btnConsumables").GetComponent<Button>().interactable = true;

    }

    public void SaveAndExit()
    {
        saveLoad.SaveGame();
        Application.Quit();
    }

}