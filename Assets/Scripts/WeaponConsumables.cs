using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ammo Rounds", menuName = "Inventory/AmmoItems")]
public class WeaponConsumables : Item
{
    [SerializeField]
    private int AmmoAmount = 9;
    public string GunTag;
    public GameObject Gun;
    public override void Use()
    {
        //trzeba mieæ ubran¹ broñ aby dodaæ ammo
        base.Use();
        Gun = GameObject.FindWithTag(GunTag);
        if (Gun == null) {
            Debug.Log("Equip this weapon first...");
            return; }
        else { 
        AmmoManager.instance.AddAmmo(AmmoAmount, Gun.GetComponent<GunScript>());
        RemoveFromInventory();
    }
    }
}