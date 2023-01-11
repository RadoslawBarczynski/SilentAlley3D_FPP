using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingManager : MonoBehaviour
{

    #region Singleton
    public static HealingManager instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    Inventory inventory;
    [SerializeField]
    PlayerStats playerStats;
    // Start is called before the first frame update
    void Start()
    {

        inventory = Inventory.instance;
    }

    public void SelfHeal(int heal)
    {
        playerStats.GetHealed(heal);
    }
    
}
