using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [SerializeField]
    private InputManager inputManager;
    [SerializeField]
    public Image panel;
    public Transform itemsParent;
    public GameObject inventoryUI;
    Inventory inventory;
    public static bool isInventoryActive = false;

    InventorySlot[] slots;

    // Start is called before the first frame update
    void Start()
    {
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if (inputManager.onFoot.Equipment.triggered)
        {
            inventoryUI.SetActive(inventoryUI.activeSelf);
        }*/
        if (Input.GetButtonDown("Inventory"))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
            if (isInventoryActive == false)
            {
                Cursor.visible = true;
                UnityEngine.Cursor.lockState = CursorLockMode.None;
                isInventoryActive = true;
            }
            else if (isInventoryActive == true)
            {
                Cursor.visible = false;
                UnityEngine.Cursor.lockState = CursorLockMode.Locked;
                isInventoryActive = false;
                panel.enabled = false;
            }
        }
    }

    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if(i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }

}
