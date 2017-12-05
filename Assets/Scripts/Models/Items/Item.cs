using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

[CreateAssetMenu (fileName ="New Item", menuName = "Inventory/Item")]
[Serializable]
public class Item: ScriptableObject
{
    public static Item instance;
    //PlayerStats playerStats;

    new public string name = "New Item";
    public Sprite icon = null;
    public int cost = 0;
    public float bonusCrim = 0;
    public bool isBought = false;
    public int plusHealth = 0;
    public int plusDrunk = 0;
    public int plusCancer = 0;
    public bool isWearable = false;
    public bool isFood = false;
    public float restoreHealth = 0;

    public virtual void Use()
    {
        //použi item
        Debug.Log("Using "+ name);
    }

    public void RemoveFromInventory()
    {
        Inventory.instance.RemoveEquip(this);
    }
}
