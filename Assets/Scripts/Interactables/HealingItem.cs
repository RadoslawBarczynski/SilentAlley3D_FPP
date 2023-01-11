using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Healing Item", menuName = "Inventory/HealingItems")]
public class HealingItem : Item
{
    [SerializeField]
    private int heal = 15;
    public override void Use()
    {
        base.Use();
        //playerStats.GetHealed(25);
        HealingManager.instance.SelfHeal(heal);
        RemoveFromInventory();
    }
}
