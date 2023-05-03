using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameHintMessages : MonoBehaviour
{
    public GameObject GamehintBox;
    public Text title;
    public Text info;
    public string enterTitle;
    public string enterInfo;
    public InputField codeEnter;
    public bool singleTime;
    public static int alreadyShown =0;
    public bool portal;
    public static bool exited = false;
    // Start is called before the first frame update

    private void Start()
    {
        alreadyShown = 0;
        codeEnter.onEndEdit.AddListener(SubmitInput);
    }
    private void OnTriggerEnter(Collider other)
    {


            if (other.CompareTag("Player"))
            {
            if (singleTime)
            {
                if (alreadyShown == 0)
                {
                    alreadyShown++;
                    showMessage();
                }
            }
            else
            {
                showMessage();
            }
        }

    }

    public void showMessage()
    {
        Time.timeScale = 0;
        codeEnter.Select();
        title.text = enterTitle;
        info.text = enterInfo;
        GamehintBox.SetActive(true);
        if (portal == true)
        {
            if (CreatePotion.canExitGame == false)
            {
                Time.timeScale = 0;
                codeEnter.Select();
                title.text = "Craft the final command!!";
                info.text = "Please go into the magicbook and craft the netstat command to exit this island";
                GamehintBox.SetActive(true);
            }
        }
        else
        {
            Time.timeScale = 0;
            codeEnter.Select();
            title.text = enterTitle;
            info.text = enterInfo;
            GamehintBox.SetActive(true);
        }
    }
    public void SubmitInput(string Input)
    {
        if (Input == "clear")
        {
            close();
        }

        if(Input == "netstat -a")
        {
            if (CreatePotion.canExitGame == true)
            {
                exited = true;
                SceneManager.LoadScene(3);
            }
        }
        codeEnter.text = "";
    }

            // Update is called once per frame
            void Update()
    {
        
    }

    public void close()
    {
        GamehintBox.SetActive(false);
        Time.timeScale = 1;
    }
    public void onSubmit(BaseEventData eventData)
    {
        SubmitInput(codeEnter.text);
    }
}
