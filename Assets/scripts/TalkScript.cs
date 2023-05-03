using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class TalkScript : MonoBehaviour
{
    public GameObject messageBox;
    public int tavernNumber = 0;
    public GameObject levelToUnlock;
    public GameObject mapKeyObj;
    public GameObject unlockCommands;
    //public string answer;
    //public GameObject question;
    //private bool haveRead = false;
    //private GameObject miniMapView;
    //private GameObject miniMapCompass;
    //private GameObject inventoryObj;
    public Dialogue dialogue;
    public InputField codeEnter;

    public GameObject dragonSpawn;

    public Text buyButtonText;
    private void Start()
    {
        codeEnter.onEndEdit.AddListener(SubmitInput);
        //inventoryObj = GameObject.Find("InventoryCanvas");
        // miniMapView = GameObject.FindGameObjectWithTag("minimapItem");
        //miniMapCompass = GameObject.FindGameObjectWithTag("compass");
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            messageBox.SetActive(true);
            // miniMapView.SetActive(false);
            // miniMapCompass.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(tavernNumber == 6)
            {
                buyButtonText.text = "Buy Weapon";
            }
            else if (tavernNumber == 4)
            {
                buyButtonText.text = "Buy Items";
            }
            messageBox.GetComponentInChildren<MessageScript>().shopNum = tavernNumber;
            messageBox.GetComponentInChildren<MessageScript>().StartDialogue(dialogue);
            if (dragonSpawn == null) { }
            else
                dragonSpawn.SetActive(true);
            unlockCommands.SetActive(true);
            //for (int i = 0; i < inventoryObj.GetComponent<InventoryItems>().messages.Length; i++)
            //{
            //    if (answer == inventoryObj.GetComponent<InventoryItems>
            //   ().messages[i].text)
            //    {
            //        haveRead = true;
            //    }
            //}
            //if (haveRead == false)
            //{
            //    haveRead = false;
            //    question.GetComponent<MessageScript>().shopMessage = answer;

            //}
            //else if (haveRead == true)
            //{
            //    question.GetComponent<MessageScript>().shopMessage = "not much going on around here";
            //}
        }
    }

    public void SubmitInput(string Input)
    {
        if (Input == "clear")
        {
            messageBox.SetActive(false);
        }
        //codeEnter.text = "";
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            //messageBox.SetActive(false);
            levelToUnlock.SetActive(false);
            mapKeyObj.SetActive(true);
            PlayerMove.canMove = true;
            // miniMapView.SetActive(true);
            // miniMapCompass.SetActive(true);
        }
    }
    public void onSubmit(BaseEventData eventData)
    {
        SubmitInput(codeEnter.text);
    }
}