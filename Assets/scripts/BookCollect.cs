using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class BookCollect : MonoBehaviour
{
    public GameObject spellsUI;
    public GameObject magicUI;
    public  bool magicCollected = false;
    public  bool spellsCollected = false;
    public bool magicBook = false;
    public bool spellsBook = false;
    public InputField codeEnter;
    // Start is called before the first frame update
    void Start()
    {
        spellsUI.SetActive(false);
        magicUI.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            codeEnter.onEndEdit.AddListener(SubmitInput);
            if (magicBook == true)
            {
                if (magicCollected == false)
                {

                }
            }
            if (spellsBook == true)
            {
                if (spellsCollected == false)
                {
                    spellsUI.SetActive(true);
                    spellsCollected = true;
                }
            }
        }
    }
    public void SubmitInput(string Input)
    {
        if (Input == "cat book")
        {
            //anim.SetBool("Open", true);
            magicUI.SetActive(true);
            magicCollected = true;

        }
        codeEnter.text = "";
    }
    public void onSubmit(BaseEventData eventData)
    {
        SubmitInput(codeEnter.text);
    }
}