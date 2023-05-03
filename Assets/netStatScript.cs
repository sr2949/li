using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class netStatScript : MonoBehaviour
{
    public InputField codeEnter;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (CreatePotion.canExitGame == false)
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

    public void SubmitInput(string Input)
    {
        if (Input == "netstat")
        {

        }
        codeEnter.text = "";
    }
    public void onSubmit(BaseEventData eventData)
    {
        SubmitInput(codeEnter.text);
    }
}
