using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{

    #region Singleton
    public static EquipmentManager instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    Equipment[] currentEquipment;
    public WeaponSwitching weaponSwitching;
    [SerializeField]
    private PlayerUI playerUI;

    public delegate void OnEquipmentChanged(Equipment newItem, Equipment oldItem);
    public OnEquipmentChanged onEquipmentChanged;

    Inventory inventory;

    void Start()
    {

  
        
        inventory = Inventory.instance;

        int numSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        currentEquipment = new Equipment[numSlots];
    }

    public void Equip(Equipment newItem)
    {
        int slotIndex = (int)newItem.equipSlot;

        Equipment oldItem = null;

        if (currentEquipment[slotIndex] != null)
        {
            oldItem = currentEquipment[slotIndex];
            inventory.Add(oldItem);
        }

        if(onEquipmentChanged != null)
        {
            onEquipmentChanged.Invoke(newItem, oldItem);
        }
        currentEquipment[slotIndex] = newItem;

        if (currentEquipment[slotIndex].WeaponSlot == 1)
        {
            weaponSwitching.selectedWeapon = 1;
        }
        else if(currentEquipment[slotIndex].WeaponSlot == 2)
        {
            weaponSwitching.selectedWeapon = 2;
        }
        else if (currentEquipment[slotIndex].WeaponSlot == 3)
        {
            weaponSwitching.selectedWeapon = 3;
        }
        else if (currentEquipment[slotIndex].WeaponSlot == 0)
        {
            weaponSwitching.selectedWeapon = 0;
        }

        playerUI.UpdateGunText(currentEquipment[slotIndex].name);
    }
}
