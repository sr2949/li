using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyWeapons : MonoBehaviour
{
    public int weaponNumber;
    public int cost;
    public Text currencyText;
    public GameObject inventoryObj;
    public AudioSource audioPlayer;
    public GameObject shopUI;
    // Start is called before the first frame update
    void Start()
    {
        currencyText.text = InventoryItems.gold.ToString();
        audioPlayer = inventoryObj.GetComponent<AudioSource>();

    }
    public void CloseShop()
    {
        shopUI.SetActive(false);
    }

    public void BuyWeaponButton()
    {
        if (InventoryItems.gold >= cost)
        {
            InventoryItems.gold -= cost;
            inventoryObj.GetComponent<InventoryItems>().weapons =true;
            inventoryObj.GetComponent<InventoryItems>().weaponAvailable = true;
            InventoryItems.canUseWeapon = true;
            audioPlayer.clip = inventoryObj.GetComponent<InventoryItems>().buySound;
            audioPlayer.Play();
            currencyText.text = InventoryItems.gold.ToString();
        }
    }
}
