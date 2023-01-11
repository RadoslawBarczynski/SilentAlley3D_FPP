using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Equpment")]
public class Equipment : Item
{
    public EquipmentSlot equipSlot;
    public int WeaponSlot = 0;
    //public int damageModifier;

    public override void Use()
    {
        base.Use();
        EquipmentManager.instance.Equip(this);
        RemoveFromInventory();
    }
}


public enum EquipmentSlot { Weapon }
