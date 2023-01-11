using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoManager : MonoBehaviour
{

    #region Singleton
    public static AmmoManager instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    Inventory inventory;
    //[SerializeField]
    //GunScript gunScript;
    // Start is called before the first frame update
    void Start()
    {

        inventory = Inventory.instance;
    }

    public void AddAmmo(int AmmoRounds, GunScript gunScript)
    {

        gunScript.totalAmmo += AmmoRounds;
    }
}
