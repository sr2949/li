using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class RoofScript : MonoBehaviour
{
    //public Animator anim;
    public GameObject roof;
    public GameObject props;
    public GameObject myCamera;
    public GameObject door;
    public bool tavern = true;
    public bool wizard = false;
    public bool blacksmith = false;
    public InputField codeEnter;
    public float rotationSpeed = 10f;
    public float targetRotation = 102.401f;
    public GameObject doorCollider1;
    public GameObject doorCollider2;
    private Quaternion targetQuaternion;


    //public GameObject GamehintBox;
    //public Text title;
    //public Text info;
    //public string enterTitle;
    //public string enterInfo;
    // Start is called before the first frame update
    void Start()
    {
        roof.SetActive(true);
        props.SetActive(false);
        targetQuaternion = Quaternion.Euler(0f, targetRotation, 0f);
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            codeEnter.onEndEdit.AddListener(SubmitInput);
            //title.text = enterTitle;
            //info.text = enterInfo;
            //GamehintBox.SetActive(true);
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //anim.SetBool("Open", false);
            door.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            door.SetActive(true);
            roof.SetActive(true);
            doorCollider1.SetActive(true);
            doorCollider2.SetActive(true);
            props.SetActive(false);
            myCamera.GetComponent<AudioManager>().musicState = 1;
            myCamera.GetComponent<AudioManager>().canPlay = true;
        }
    }

    public void SubmitInput(string Input)
    {
        if (Input == "cd")
        {
            //anim.SetBool("Open", true);
            door.SetActive(false);
            doorCollider1.SetActive(false);
            doorCollider2.SetActive(false);
            //transform.rotation = Quaternion.RotateTowards(transform.rotation, targetQuaternion, rotationSpeed * Time.deltaTime);
            roof.SetActive(false);
            props.SetActive(true);
            if (tavern == true)
            {
                myCamera.GetComponent<AudioManager>().musicState = 2;
                myCamera.GetComponent<AudioManager>().canPlay = true;
            }
            if (wizard == true)
            {
                myCamera.GetComponent<AudioManager>().musicState = 4;
                myCamera.GetComponent<AudioManager>().canPlay = true;
            }
            if (blacksmith == true)
            {
                myCamera.GetComponent<AudioManager>().musicState = 5;
                myCamera.GetComponent<AudioManager>().canPlay = true;
            }
        }
        //codeEnter.text = "";
    }
    public void onSubmit(BaseEventData eventData)
    {
        SubmitInput(codeEnter.text);
    }
}