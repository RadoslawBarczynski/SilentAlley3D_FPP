using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{

    [SerializeField]
    public Image panel;
    public Image icon;
    public TextMeshProUGUI itemName;
    public Button removeButton;
    Item item;

    public void AddItem(Item newItem)
    {
        item = newItem;

        //panel.sprite = item.icon;
        //icon.sprite = item.icon;
        itemName.text = item.name;
        itemName.enabled = true;
        icon.enabled = true;
        removeButton.interactable = true;
    }

    public void ClearSlot()
    {
        item = null;

        //icon.sprite = null;
        itemName.text = null;
        itemName.enabled = false;
        removeButton.interactable = false;
    }

    public void OnRemoveButton()
    {
        Inventory.instance.Remove(item);
    }

    public void UseItem()
    {
        if(item != null)
        {
            item.Use();
        }
    }

    public void DisplayItemImage()
    {
        if (item != null)
        {
            panel.enabled = true;
            panel.sprite = item.icon;
        }
        else
        {
            return;
        }
    }

    public void HideItemImage()
    {
        panel.sprite = null;
        panel.enabled = false;
    }



}
