using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class Pickups : MonoBehaviour
{
    public int number;
    public bool redMushroom = false;
    public bool purpleMushroom = false;
    public bool brownMushroom = false;
    public bool blueFlower = false;
    public bool redFlower = false;
    public bool dragonEggBool = false;
    public bool key = false;
    public bool coins = false;
    public bool isDragon = false;
    public GameObject inventoryObject;
    public AudioSource audioPlayer;
    public InputField codeEnter;

    private void Start()
    {
        inventoryObject = GameObject.Find("InventoryCanvas");
        audioPlayer = inventoryObject.GetComponent<AudioSource>();
        if (coins == true)
        {
            Destroy(gameObject, 5);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            codeEnter.onEndEdit.AddListener(SubmitInput);
            codeEnter.interactable = true;

        }
    }

    void DisplayIcons()
    {
        InventoryItems.newIcon = number;
        InventoryItems.iconUpdate = true;
    }

     public void SubmitInput(string Input)
    {
        if (Input == "mv mushroom /inv")
        {
                audioPlayer.clip = inventoryObject.GetComponent<InventoryItems>().pickupSound;
                audioPlayer.Play();
                if (redMushroom == true)
                {
                    if (InventoryItems.redMushrooms == 0)
                    {
                        DisplayIcons();
                    }
                    InventoryItems.redMushrooms++;
                DestroyObj();
                }
                else if (purpleMushroom == true)
                {
                    if (InventoryItems.purpleMushrooms == 0)
                    {
                        DisplayIcons();
                    }
                    InventoryItems.purpleMushrooms++;
                DestroyObj();
            }
                else if (brownMushroom == true)
                {
                    if (InventoryItems.brownMushrooms == 0)
                    {
                        DisplayIcons();
                    }
                    InventoryItems.brownMushrooms++;
                DestroyObj();
            }
            }
        else if (Input == "mv flower /inv")
        {
            audioPlayer.clip = inventoryObject.GetComponent<InventoryItems>().pickupSound;
            audioPlayer.Play();
            if (blueFlower == true)
            {
                if (InventoryItems.blueFlowers == 0)
                {
                    DisplayIcons();
                }
                InventoryItems.blueFlowers++;
                DestroyObj();
            }
            else if (redFlower == true)
            {
                if (InventoryItems.redFlowers == 0)
                {
                    DisplayIcons();
                }
                InventoryItems.redFlowers++;
                DestroyObj();
            }
        }
        else if (Input == "mv egg /inv")
        {
                audioPlayer.clip = inventoryObject.GetComponent<InventoryItems>().pickupSound;
                audioPlayer.Play();
                if (dragonEggBool == true)
                {
                    if (InventoryItems.dragonEgg == 0)
                    {
                        DisplayIcons();
                    }
                    InventoryItems.dragonEgg++;
                }
            
        }
        else if (Input == "mv key /inv")
        {
            audioPlayer.clip = inventoryObject.GetComponent<InventoryItems>().pickupSound;
            audioPlayer.Play();
            //if (redMushroom == true)
            //{
            //    if (InventoryItems.redMushrooms == 0)
            //    {
            //        DisplayIcons();
            //    }
            //    InventoryItems.redMushrooms++;
            //    DestroyObj();
            //}
            //    else if (blueFlower == true)
            //    {
            //        if (InventoryItems.blueFlowers == 0)
            //        {
            //            DisplayIcons();
            //        }
            //        InventoryItems.blueFlowers++;
            //    DestroyObj();
            //}
            //else if (purpleMushroom == true)
            //{
            //    if (InventoryItems.purpleMushrooms == 0)
            //    {
            //        DisplayIcons();
            //    }
            //    InventoryItems.purpleMushrooms++;
            //    DestroyObj();
            //}
            //else if (brownMushroom == true)
            //{
            //    if (InventoryItems.brownMushrooms == 0)
            //    {
            //        DisplayIcons();
            //    }
            //    InventoryItems.brownMushrooms++;
            //    DestroyObj();
            //}
            //    else if (redFlower == true)
            //    {
            //        if (InventoryItems.redFlowers == 0)
            //        {
            //            DisplayIcons();
            //        }
            //        InventoryItems.redFlowers++;
            //    DestroyObj();
            //}
            if (key == true)
            {
                DisplayIcons();
                InventoryItems.key = true;
                DestroyObj();
            }
            //else if (coins == true)
            //{
            //    if (isDragon == true)
            //    {
            //        InventoryItems.gold += 500;
            //    DestroyObj();
            //}
            //    else
            //    {
            //        InventoryItems.gold += Random.Range(5, 250);
            //    DestroyObj();
            //    }
            //}
            //else
            //{
            //DisplayIcons();
            //DestroyObj();
            //}
        }
        codeEnter.text = "";
    }
    public void onSubmit(BaseEventData eventData)
    {
        SubmitInput(codeEnter.text);
    }

    public void DestroyObj()
    {
        Destroy(gameObject);
        codeEnter.interactable = true;
    }

}