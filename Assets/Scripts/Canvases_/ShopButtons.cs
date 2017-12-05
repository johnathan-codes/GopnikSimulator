using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopButtons : MonoBehaviour
{
    public void Start()
    {
        GameObject.Find("swCanvas").GetComponent<Canvas>().enabled = false;
        GameObject.Find("lwCanvas").GetComponent<Canvas>().enabled = false;
        GameObject.Find("clCanvas").GetComponent<Canvas>().enabled = false;
        GameObject.Find("coCanvas").GetComponent<Canvas>().enabled = false;

        //itemom priradiť Sprite.
    }


    public void SmallWeapons()
    {
        GameObject.Find("btnClick").GetComponent<AudioSource>().Play();

        GameObject.Find("swCanvas").GetComponent<Canvas>().enabled = true;
        GameObject.Find("lwCanvas").GetComponent<Canvas>().enabled = false;
        GameObject.Find("clCanvas").GetComponent<Canvas>().enabled = false;
        GameObject.Find("coCanvas").GetComponent<Canvas>().enabled = false;

        GameObject.Find("btnSmallWeapons").GetComponent<Button>().interactable = false;
        GameObject.Find("btnLargeWeapons").GetComponent<Button>().interactable = true;
        GameObject.Find("btnClothes").GetComponent<Button>().interactable = true;
        GameObject.Find("btnConsumables").GetComponent<Button>().interactable = true;
    }
    public void LargeWeapons()
    {
        GameObject.Find("btnClick").GetComponent<AudioSource>().Play();

        GameObject.Find("swCanvas").GetComponent<Canvas>().enabled = false;
        GameObject.Find("lwCanvas").GetComponent<Canvas>().enabled = true;
        GameObject.Find("clCanvas").GetComponent<Canvas>().enabled = false;
        GameObject.Find("coCanvas").GetComponent<Canvas>().enabled = false;

        GameObject.Find("btnSmallWeapons").GetComponent<Button>().interactable = true;
        GameObject.Find("btnLargeWeapons").GetComponent<Button>().interactable = false;
        GameObject.Find("btnClothes").GetComponent<Button>().interactable = true;
        GameObject.Find("btnConsumables").GetComponent<Button>().interactable = true;
    }
    public void Clothes()
    {
        GameObject.Find("btnClick").GetComponent<AudioSource>().Play();

        GameObject.Find("swCanvas").GetComponent<Canvas>().enabled = false;
        GameObject.Find("lwCanvas").GetComponent<Canvas>().enabled = false;
        GameObject.Find("clCanvas").GetComponent<Canvas>().enabled = true;
        GameObject.Find("coCanvas").GetComponent<Canvas>().enabled = false;

        GameObject.Find("btnSmallWeapons").GetComponent<Button>().interactable = true;
        GameObject.Find("btnLargeWeapons").GetComponent<Button>().interactable = true;
        GameObject.Find("btnClothes").GetComponent<Button>().interactable = false;
        GameObject.Find("btnConsumables").GetComponent<Button>().interactable = true;
    }
    public void Consumables()
    {
        GameObject.Find("btnClick").GetComponent<AudioSource>().Play();

        GameObject.Find("swCanvas").GetComponent<Canvas>().enabled = false;
        GameObject.Find("lwCanvas").GetComponent<Canvas>().enabled = false;
        GameObject.Find("clCanvas").GetComponent<Canvas>().enabled = false;
        GameObject.Find("coCanvas").GetComponent<Canvas>().enabled = true;

        GameObject.Find("btnSmallWeapons").GetComponent<Button>().interactable = true;
        GameObject.Find("btnLargeWeapons").GetComponent<Button>().interactable = true;
        GameObject.Find("btnClothes").GetComponent<Button>().interactable = true;
        GameObject.Find("btnConsumables").GetComponent<Button>().interactable = false;
    }
}
