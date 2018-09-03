using UnityEngine;
using UnityEngine.UI;
//using Playerino;

public class InventorySlot : MonoBehaviour {

    public Image icon;
    public Button removeButton, itemik;
    public CharacterStats player;
    public Text description2, descr_cost_inv;

    Item item;

    public void AddItem(Item newItem)
    {
        item = newItem;
        icon.sprite = item.icon;
        icon.enabled = true;
        removeButton.interactable = true;
    }

    public void ClearSlot()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
        removeButton.interactable = false;
    }

    public void UseItem()
    {
        if(item != null)
        {
            item.Use();
        }
    }

    public void OnRemoveButton()
    {
        Inventory.instance.Sell(item);
    }

    public void OnMouseOver()
    {
        if (item != null)
        { 
        description2.text = "NAME: " + item.name + "\nSKILL BONUS: " + (item.bonusCrim) + "\nADDS HEALTH: " + item.plusHealth + "\nRESTORE HEALTH: "
        + item.restoreHealth + "\nADDS CANCER: " + item.plusCancer + "\nADDS DRUNK: " + item.plusDrunk;
        GameObject.Find("descr_cost_inv").GetComponent<Text>().text = "SELL COST: " + item.cost / 2;
        }
    }

    public void OnMouseExit()
    {
        description2.text = "NAME: " + "\nSKILL BONUS: " + "\nADDS HEALTH: " + "\nRESTORE HEALTH: " + "\nADDS CANCER: " + "\nADDS DRUNK: ";
        GameObject.Find("descr_cost_inv").GetComponent<Text>().text = "SELL COST: ";
    }
}
