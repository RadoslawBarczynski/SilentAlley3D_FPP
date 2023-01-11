using UnityEngine;

public class WeaponSwitching : MonoBehaviour
{
    [SerializeField]
    private PlayerUI playerUI;

    public int selectedWeapon = 0;
    public GunScript gunScriptTrue;
    // Start is called before the first frame update
    void Start()
    {
        SelectWeapon();
    }

    // Update is called once per frame
    void Update()
    {
        if (InventoryUI.isInventoryActive == true)
            SelectWeapon();

        playerUI.UpdateAmmoText(gunScriptTrue.currentAmmo, gunScriptTrue.totalAmmo);
    }

    public void SelectWeapon()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            //i++;
            if (i == selectedWeapon)
            { 
                weapon.gameObject.SetActive(true);
                gunScriptTrue = weapon.gameObject.GetComponent<GunScript>();
                GunScript Ammo = weapon.gameObject.GetComponent<GunScript>();
                playerUI.UpdateAmmoText(Ammo.currentAmmo, Ammo.totalAmmo);
            }
            else
                weapon.gameObject.SetActive(false);
            i++;
        }
    }
}
