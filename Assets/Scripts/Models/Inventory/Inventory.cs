using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory:MonoBehaviour {

    #region Singleton

    public static Inventory instance;
    public Text popup;
    public CharacterStats character;

    //save path
    //private string gameDataProjectFilePath = "/StreamingAssets/data.json";
    //

    void Awake()
    {
        if(instance != null)
        {
            popup.text = "Viac ako jeden inventár";
            return;
        }
        instance = this;
    }

    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;
    public string jsonPath;
    public int space = 16;

    public List<Item> items;

    public bool Add(Item item)
    {
        if (items.Count >= space)
        {
            //popup.text = "Nie je miesto";
            return false;
        }
        item.isBought = true;
        items.Add(item);

        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
        return true;
    }

    public void Sell (Item item)
    {
        items.Remove(item);
        character.AddMoney(item.cost / 2);
        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
        item.isBought = false;
    }

    public void RemoveEquip(Item item)
    {
        items.Remove(item);
        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
    }
    
    public void SaveItems()
    {
        //SaveGame.Save("inventory", items);
        for (int i =0; i < items.Count; i++)
        {
            PlayerPrefs.SetString("item"+i, items[i].name);
        }
        PlayerPrefs.SetInt("pocetItemov", items.Count);
    }

    public void LoadItems()
    {
        Item[] itemiky = (Item[]) Resources.FindObjectsOfTypeAll(typeof(Item));
        //SaveGame.LoadInto("inventory", items);
        int j;
        for (int i = 0; i < PlayerPrefs.GetInt("pocetItemov");i++)
        {
            string helper = PlayerPrefs.GetString("item" + i);
            //helper = helper.Remove(helper.Length - 1);
            for(j=0; j<itemiky.Length;j++)
            { 
               if (itemiky[j].name==helper)
               {
                    Add(itemiky[j]);
                    break;
               }
            }
        }
        //odmazanie po načítaní
        for (int k = 0; k < PlayerPrefs.GetInt("pocetItemov"); k++)
        {
            PlayerPrefs.DeleteKey("item"+k);
        }

    }
}
