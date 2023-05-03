using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class MessageScript : MonoBehaviour, IPointerEnterHandler,
IPointerExitHandler
{
    public Text buttonText;
    public Text shopOwnerMessage;
    public Color32 messageOff;
    public Color32 messageOn;
    public GameObject[] shopUI;
    [HideInInspector]
    public int shopNum = 0;

    private Queue<string> sentences;
    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonText.color = messageOn;
        PlayerMove.canMove = false;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        buttonText.color = messageOff;
        PlayerMove.canMove = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        //shopOwnerMessage.text = "hello " + SaveScript.pname + " how can i help you";
    }
    //public void Message1()
    //{
    //    shopOwnerMessage.text = "not much going on around here";
    //}
    public void Message2()
    {
        shopOwnerMessage.text = "select items from the list";
        shopUI[shopNum].SetActive(true);
        if (shopNum < 6)
        {
            shopUI[shopNum].GetComponent<BuyScript>().UpdateGold();
        }
    }
    void Update()
    {
        if (PlayerMove.canMove == true && PlayerMove.moving == true)
        {
            if (shopUI != null)
            {
                shopUI[shopNum].SetActive(false);
            }
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        Debug.Log("Starting Conversation With" + dialogue.name);

        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }
    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        shopOwnerMessage.text = sentence;
    }
    void EndDialogue()
    {
        Debug.Log("End of coversation.");
    }
}