using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
public class ChestScript : MonoBehaviour
{
    private Animator anim;
    public int goldAmt = 50;

    public GameObject particleEfffect;
    public GameObject spawnPoint;
    public GameObject canvasText;
    public Text goldAmtText;
    public float speed = 1.0f;
    public GameObject mainCam;
    private int goldDisplay;
    public GameObject inventoryObj;
    public AudioClip openChest;
    public bool crate = false;
    public bool isCreateOpen = false;
    public InputField codeEnter;


    // Start is called before the first frame update
    void Start()
    {
        if (crate == false)
        {
            anim = GetComponent<Animator>();
        }

        canvasText.SetActive(false);
        goldDisplay = goldAmt;

    }

    private void Update()
    {
        if (canvasText.activeSelf == true)
        {
            canvasText.transform.Translate(Vector3.up * speed *Time.deltaTime);
            goldAmtText.text = goldDisplay.ToString();
            canvasText.transform.LookAt(mainCam.transform.position);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (crate == false)
        {
            if (other.CompareTag("Player"))
            {
                if (InventoryItems.key == true)
                {
                    codeEnter.onEndEdit.AddListener(SubmitInput);
                    //if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
                    //{
                        //if (codeEnter.text == "cd")
                        //{

                        //}
                    //}

                }
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (crate == false)
        {
            if (other.CompareTag("Player"))
            {
                if (InventoryItems.key == true)
                {
                    anim.SetTrigger("close");
                }
            }
        }
    }
    public void DestroyChest()
    {
        Destroy(gameObject);
    }

    public void Particles()
    {
        Instantiate(particleEfffect, spawnPoint.transform.position,spawnPoint.transform.rotation);
        canvasText.SetActive(true);
        if (crate == true)
        {
            InventoryItems.gold += goldAmt;
            goldAmt = 0;
            inventoryObj.GetComponent<AudioSource>().clip = openChest;
            inventoryObj.GetComponent<AudioSource>().Play();
        }
    }

    public void SubmitInput(string Input)
    {
        if(Input == "tar")
        {
            anim.SetTrigger("open");
            InventoryItems.gold += goldAmt;
            goldAmt = 0;
            inventoryObj.GetComponent<AudioSource>().clip = openChest;
            inventoryObj.GetComponent<AudioSource>().Play();
        }
        codeEnter.text = "";
    }

    public void onSubmit(BaseEventData eventData)
    {
        SubmitInput(codeEnter.text);
    }

}