using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI promptText;
    [SerializeField]
    private TextMeshProUGUI ammoText;
    [SerializeField]
    private TextMeshProUGUI gunNameText;
    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    public void UpdateText(string promptMessage)
    {
        promptText.text = promptMessage;
    }

    public void UpdateGunText(string gunNameTextMesh)
    {
        gunNameText.text = gunNameTextMesh;
    }

    public void UpdateAmmoText(int ammoTextMesh, int totalAmmoMesh)
    {
        ammoText.text = ammoTextMesh + "/" + totalAmmoMesh;
    }

}
