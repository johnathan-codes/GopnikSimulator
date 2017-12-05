using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Equipment")]
public class Equipment : Item {

    public EquipmentSlot equipmentSlot;

    public override void Use()
    {
        base.Use();
        EquipmentManager.instance.Equip(this);
        RemoveFromInventory();
    }
}

public enum EquipmentSlot { SmallWeapon, LargeWeapon, Null}