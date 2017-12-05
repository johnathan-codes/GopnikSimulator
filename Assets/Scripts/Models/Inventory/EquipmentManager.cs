using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentManager : MonoBehaviour {

    #region Singleton

    public static EquipmentManager instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    Equipment[] currentEquipment;

    public delegate void OnEquipmentChanged(Equipment newItem, Equipment oldItem);
    public OnEquipmentChanged onEquipmentChanged;

    void Start()
    {
        int numSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        currentEquipment = new Equipment[numSlots];
    }


    public void Equip(Equipment newItem)
    {
        int slotIndex = (int)newItem.equipmentSlot;

        Equipment oldItem = null;

        if (currentEquipment[slotIndex] != null)
        {
            oldItem = currentEquipment[slotIndex];
            Inventory.instance.Add(oldItem);
            //PlayerStats.instance.skill -= oldItem.bonusCrim;
        }

        if(onEquipmentChanged != null)
        {
            onEquipmentChanged.Invoke(newItem, oldItem);
        }

        if((int)newItem.equipmentSlot == 0)
        {
            GameObject.Find("sw_equipped").GetComponent<Text>().text = "SMALL WEAPON: \n" + newItem.name;
        }
        if ((int)newItem.equipmentSlot == 1)
        {
            GameObject.Find("lw_equipped").GetComponent<Text>().text = "LARGE WEAPON: \n" + newItem.name;
        }
        currentEquipment[slotIndex] = newItem;
        //PlayerStats.instance.skill += newItem.bonusCrim;
    }

    public void Unequip(int slotIndex)
    {
        if(currentEquipment[slotIndex] != null)
        {
            Equipment oldItem = currentEquipment[slotIndex];
            Inventory.instance.Add(oldItem);

            currentEquipment[slotIndex] = null;

            if (onEquipmentChanged != null)
            {
                onEquipmentChanged.Invoke(null, oldItem);
            }
            
        }
    }

    public void UnequipAll()
    {
        for (int i = 0; i < currentEquipment.Length; i++)
        {
            Unequip(i);
            GameObject.Find("sw_equipped").GetComponent<Text>().text = "SMALL WEAPON: \n";
            GameObject.Find("lw_equipped").GetComponent<Text>().text = "LARGE WEAPON: \n";
         
        }
    }
}
