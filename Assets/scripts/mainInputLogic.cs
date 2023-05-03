using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mainInputLogic : MonoBehaviour
{
    public GameObject inventoryObj;
    public GameObject CreatScript;
    public Text codeEnter;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
            //if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
            //{
            //    if(codeInput.text == "weapon")
            //    {
            //        weaponToggle = !weaponToggle;
            //        inventoryObj.GetComponent<InventoryItems>().WeaponObject.SetActive(weaponToggle);
            //    }
            //}
            if (inventoryObj.GetComponent<InventoryItems>().weapons == true)
            {
                if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
                {
                    if (codeEnter.text == "mount sword")
                    {
                        inventoryObj.GetComponent<InventoryItems>().audioPlayer.clip = inventoryObj.GetComponent<InventoryItems>().bookOpenSound;
                        inventoryObj.GetComponent<InventoryItems>().audioPlayer.Play();
                        inventoryObj.GetComponent<InventoryItems>().weaponToggle = true;
                        inventoryObj.GetComponent<InventoryItems>().WeaponObject.SetActive(inventoryObj.GetComponent<InventoryItems>().weaponToggle);
                        inventoryObj.GetComponent<InventoryItems>().weaponAvailable = false;
                    }
                else if (codeEnter.text == "unmount sword")
                {
                    inventoryObj.GetComponent<InventoryItems>().audioPlayer.clip = inventoryObj.GetComponent<InventoryItems>().bookOpenSound;
                    inventoryObj.GetComponent<InventoryItems>().audioPlayer.Play();
                    inventoryObj.GetComponent<InventoryItems>().weaponToggle = false;
                    inventoryObj.GetComponent<InventoryItems>().WeaponObject.SetActive(inventoryObj.GetComponent<InventoryItems>().weaponToggle);
                    inventoryObj.GetComponent<InventoryItems>().weaponAvailable = false;
                }
            }
            }

        //if (codeEnter.text == "cd")
        //{
        //    CreatScript.GetComponent<ChestScript>().isCreateOpen = true;
        //    //inventoryObj.GetComponent<InventoryItems>().audioPlayer.Play();
        //    //inventoryObj.GetComponent<InventoryItems>().weaponToggle = !inventoryObj.GetComponent<InventoryItems>().weaponToggle;
        //    //inventoryObj.GetComponent<InventoryItems>().WeaponObject.SetActive(inventoryObj.GetComponent<InventoryItems>().weaponToggle);
        //    //inventoryObj.GetComponent<InventoryItems>().weaponAvailable = false;
        //}
    }
    }
