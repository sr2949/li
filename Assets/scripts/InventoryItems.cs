//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class InventoryItems : MonoBehaviour
//{
//    public GameObject inventoryMenu;
//    public GameObject openBook;
//    public GameObject closedBook;
//    public GameObject potionBook;
//    public GameObject thisCanvas;

//    public GameObject messageBox;

//    public Image[] emptySlots;
//    public Sprite[] icons;
//    public Sprite emptyIcon;

//    public static int redMushrooms = 0;
//    public static int purpleMushrooms = 0;
//    public static int brownMushrooms = 0;
//    public static int blueFlowers = 0;
//    public static int redFlowers = 0;
//    public static int roots = 0;
//    public static int leafDew = 0;
//    public static int dragonEgg = 0;
//    public static int redPotion = 0;
//    public static int bluePotion = 0;
//    public static int greenPotion = 0;
//    public static int purplePotion = 0;
//    public static int bread = 0;
//    public static int cheese = 0;
//    public static int meat = 0;
//    public static bool key = true;


//    public static int newIcon = 0;
//    public static int gold = 30000;
//    public static bool iconUpdate = false;
//    private int max;

//    public GameObject theCanvas;
//    [HideInInspector]
//    public string entry;
//    public string[] items;
//    [HideInInspector]
//    public int currentID = 0;
//    [HideInInspector]
//    public int checkAmt = 0;
//    private int maxTwo;
//    private int maxThree;
//    public Image[] UISlots;
//    public Sprite[] magicIcons;
//    public Sprite[] spellIcons;
//    public KeyCode[] keys;
//    public bool set = false;
//    public bool setTwo = false;
//    [HideInInspector]
//    public int selected = 0;
//    public int[] magicAttack;
//    public GameObject[] magicParticles;
//    public AudioClip[] magicSounds;
//    public Image manaBar;
//    public Image staminaBar;
//    public Image healthImage;
//    public bool[] weapons;
//    public Text[] messages;
//    private int maxFour;
//    private GameObject miniMapView;
//    private GameObject miniMapCompass;
//    public GameObject mapScreen;
//    public GameObject mapCam;


//    // Start is called before the first frame update
//    void Start()
//    {
//        inventoryMenu.SetActive(false);
//        openBook.SetActive(false);
//        closedBook.SetActive(true);
//        potionBook.SetActive(false);
//        max = emptySlots.Length;
//        maxTwo = items.Length;
//        maxThree = emptySlots.Length;
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        if(iconUpdate == true)
//        {
//            for(int i =0; i < max; i++)
//            {
//                if(emptySlots[i].sprite == emptyIcon)
//                {
//                    max = i;
//                    emptySlots[i].sprite = icons[newIcon];
//                    emptySlots[i].transform.gameObject.GetComponent<HintMessage>().objectType = newIcon;
//                }
//            }
//            StartCoroutine(Reset());
//        }
//        if (set == true)
//        {
//            for (int i = 0; i < UISlots.Length; i++)
//            {
//                if (Input.GetKeyDown(keys[i]))
//                {
//                    set = false;
//                    UISlots[i].sprite = magicIcons[selected];
//                    magicAttack[i] = selected;
//                    theCanvas.GetComponent<CreatePotion>().Removed(selected);
//                }
//            }
//        }
//        if (setTwo == true)
//        {
//            for (int i = 0; i < UISlots.Length; i++)
//            {
//                if (Input.GetKeyDown(keys[i]))
//                {
//                    setTwo = false;
//                    UISlots[i].sprite = spellIcons[selected];
//                    magicAttack[i] = selected += 6;
//                }
//            }
//        }


//    }

//    public void CheckStatics()
//    {
//        for (int i = 0; i < maxTwo; i++)
//        {
//            if (i == currentID)
//            {
//                maxTwo = i;
//                entry = items[i];
//                checkAmt = System.Convert.ToInt32(typeof(InventoryItems).GetField(entry).GetValue(null));
//                checkAmt--;
//                typeof(InventoryItems).GetField(entry).SetValue(null,checkAmt);
//                if (checkAmt == 0)
//                {
//                    RemoveIcon(i);
//                }
//            }
//        }
//        maxTwo = items.Length;
//    }
//    public void RemoveIcon(int iconType)
//    {
//        for (int i = 0; i < maxThree; i++)
//        {
//            if (emptySlots[i].sprite == icons[iconType])
//            {
//                maxThree = i;
//                emptySlots[i].sprite = icons[0];
//                emptySlots[i].transform.gameObject.GetComponent<HintMessage>().objectType = 0;
//            }
//        }
//        maxThree = emptySlots.Length;
//    }


//    public void OpenMenu()
//    {
//        messageBox.SetActive(false);
//        inventoryMenu.SetActive(true);
//        openBook.SetActive(true);
//        closedBook.SetActive(false);
//        Time.timeScale = 0;
//    }

//    public void CloseMenu()
//    {
//        inventoryMenu.SetActive(false);
//        openBook.SetActive(false);
//        closedBook.SetActive(true);
//        Time.timeScale = 1;
//    }

//    public void openPotionBook()
//    {
//        potionBook.SetActive(true);
//    }

//    public void closePotionBook()
//    {
//        theCanvas.GetComponent<CreatePotion>().value = 0;
//        theCanvas.GetComponent<CreatePotion>().thisValue = 0;
//        potionBook.SetActive(false);
//    }


//    public void UpdateMessages(string message)
//    {
//        for (int i = 0; i < maxFour; i++)
//        {
//            if (messages[i].text == "blank")
//            {
//                maxFour = i;
//                messages[i].text = message;
//            }
//        }
//        maxFour = messages.Length;
//    }

//    IEnumerator Reset()
//    {
//        yield return new WaitForSeconds(0.1f);
//        iconUpdate = false;
//        max = emptySlots.Length;
//    }
//}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class InventoryItems : MonoBehaviour
{
    public GameObject inventoryMenu;
    public GameObject openBook;
    public GameObject closedBook;
    public GameObject potionBook;
    public GameObject messageBox;
    public AudioSource audioPlayer;
    public AudioClip bookOpenSound;
    public AudioClip selectSound;
    public AudioClip buySound;
    public AudioClip createPotionSound;
    public AudioClip pickupSound;


    public Image[] emptySlots;
    public Sprite[] icons;
    public Sprite emptyIcon;
    public static int redMushrooms = 0;
    public static int purpleMushrooms = 0;
    public static int brownMushrooms = 0;
    public static int blueFlowers = 0;
    public static int redFlowers = 0;
    public static int roots = 0;
    public static int leafDew = 0;
    public static int dragonEgg = 0;
    public static int redPotion = 0;
    public static int bluePotion = 0;
    public static int greenPotion = 0;
    public static int purplePotion = 0;
    public static int bread = 0;
    public static int cheese = 0;
    public static int meat = 0;
    public static bool key = false;
    public static int newIcon = 0;
    public static int gold = 30000;
    public static bool iconUpdate = false;
    private int max;
    public GameObject theCanvas;
    [HideInInspector]
    public string entry;
    public string[] items;
    [HideInInspector]
    public int currentID = 0;
    [HideInInspector]
    public int checkAmt = 0;
    private int maxTwo;
    private int maxThree;
    public Image[] UISlots;
    public Sprite[] magicIcons;
    public Sprite[] spellIcons;
    public KeyCode[] keys;
    public bool set = false;
    public bool setTwo = false;
    [HideInInspector]
    public int selected = 0;
    public static bool canUseWeapon = false;
    public GameObject WeaponObject;
    public bool weapons;
    public bool updateWeapons = true;
    public bool weaponAvailable = false;
    public InputField codeEnter;
    public bool weaponToggle;
    public int[] magicAttack;

    public GameObject mapScreen;
    public GameObject helpCommands;
    public GameObject mapCam;
    public GameObject inventoryScreen;
    public GameObject GamePlayerForPortal;
    public GameObject portal1;


    public GameObject GamehintBox;
    public Text title;
    public Text info;

    public bool magicCollectedS;


    //private bool invToggle = false;


    //private Animator playerAnim;
    private float weightAmt = 1.0f;
    private bool changeWeight = false;
    private AnimatorStateInfo playerInfo;

    // Start is called before the first frame update
    void Start()
    {

        codeEnter.onEndEdit.AddListener(SubmitInput);
        inventoryMenu.SetActive(false);
        openBook.SetActive(false);
        closedBook.SetActive(true);
        potionBook.SetActive(false);
        max = emptySlots.Length;
        maxTwo = items.Length;
        maxThree = emptySlots.Length;
        audioPlayer = GetComponent<AudioSource>();
        //Temp
        redMushrooms = 0;
        purpleMushrooms = 0;
        brownMushrooms = 0;
        blueFlowers = 0;
        redFlowers = 0;
        roots = 0;
        leafDew = 0;
        bluePotion = 0;
        greenPotion = 0;
        purplePotion = 0;
        redPotion = 0;
        bread = 0;
        cheese = 0;
        meat = 0;
    }
    // Update is called once per frame
    void Update()
    {
        //magicCollectedS = BookCollect.
        
        if (magicCollectedS == true)
        {
            // inventoryObj.GetComponent<InventoryItems>().magicUI.SetActive(true);
        }
        // playerInfo = playerAnim.GetCurrentAnimatorStateInfo(1);
        if (iconUpdate == true)
        {
            for (int i = 0; i < max; i++)
            {
                if (emptySlots[i].sprite == emptyIcon)
                {
                    max = i;
                    emptySlots[i].sprite = icons[newIcon];
                    emptySlots
                   [i].transform.gameObject.GetComponent<HintMessage>().objectType = newIcon;
                }
            }
            StartCoroutine(Reset());
        }

        if (set == true)
        {
            for (int i = 0; i < UISlots.Length; i++)
            {
                if (Input.GetKeyDown(keys[i]))
                {
                    set = false;
                    UISlots[i].sprite = magicIcons[selected];
                    magicAttack[i] = selected;
                    theCanvas.GetComponent<CreatePotion>().Removed(selected);
                }
            }
        }
        if (setTwo == true)
        {
            for (int i = 0; i < UISlots.Length; i++)
            {
                if (Input.GetKeyDown(keys[i]))
                {
                    setTwo = false;
                    UISlots[i].sprite = spellIcons[selected];
                    magicAttack[i] = selected += 6;
                }
            }
        }

        //if(weaponAvailable == true)
        //{

        //    WeaponObject.SetActive(true);
        //    Debug.Log("Weapon set active");
        //}


        //if (updateWeapons == true)
        //{
            if(weaponAvailable == true)
            {
            showMessage();
            WeaponObject.SetActive(true);
            weaponAvailable = false;
            }
        //}
        //if (this.isActiveAndEnabled)
        //{
        //    updateWeapons = false;
        //}
    }

    public void showMessage()
    {
        Time.timeScale = 0;
        codeEnter.Select();
        title.text = "Usage";
        info.text = "use 'mount sword' to carry weapon use 'unmount sword' to store weapon";
        GamehintBox.SetActive(true);
    }

    public void SubmitInput(string Input)
    {
        if (Input == "ls")
        {
            OpenMenu();
        }
        else if (Input == "clear")
        {
            CloseMenu();
        }
        else if (Input == "pwd")
        {
            inventoryMenu.SetActive(true);
            OpenMapScreen();
        }
        else if (Input == "help -commands")
        {
            inventoryMenu.SetActive(true);
            OpenCommandsHelp();
        }
        //else if (Input == "ping w")
        //{
        //    //Vector3 pos = portal1.transform.position;
        //    //GamePlayerForPortal.transform.position = pos;
        //    StartCoroutine(MoveToTarget());
        //    PlayerMove.canMove = true;
        //}
        codeEnter.text = "";
    }
    public void onSubmit(BaseEventData eventData)
    {
        SubmitInput(codeEnter.text);
    }
    public void CheckStatics()
    {
        for (int i = 0; i < maxTwo; i++)
        {
            if (i == currentID)
            {
                maxTwo = i;
                entry = items[i];
                checkAmt = System.Convert.ToInt32(typeof
               (InventoryItems).GetField(entry).GetValue(null));
                checkAmt--;
                typeof(InventoryItems).GetField(entry).SetValue(null,
               checkAmt);
                if (checkAmt == 0)
                {
                    RemoveIcon(i);
                }
            }
        }
        maxTwo = items.Length;
    }
    public void RemoveIcon(int iconType)
    {
        for (int i = 0; i < maxThree; i++)
        {
            if (emptySlots[i].sprite == icons[iconType])
            {
                maxThree = i;
                emptySlots[i].sprite = icons[0];
                emptySlots[i].transform.gameObject.GetComponent<HintMessage>
               ().objectType = 0;
            }
        }
        maxThree = emptySlots.Length;
    }
    public void OpenMenu()
    {
        OpenInventoryScreen();
        Time.timeScale = 0;
        audioPlayer.clip = bookOpenSound;
        audioPlayer.Play();

    }
    public void CloseMenu()
    {
        inventoryMenu.SetActive(false);
        openBook.SetActive(false);
        GamehintBox.SetActive(false);
        closedBook.SetActive(true);
        mapScreen.SetActive(false);
        mapCam.SetActive(false);
        Time.timeScale = 1;
        audioPlayer.clip = bookOpenSound;
        audioPlayer.Play();

    }
    public void OpenPotionBook()
    {
        potionBook.SetActive(true);
    }
    public void ClosePotionBook()
    {
        theCanvas.GetComponent<CreatePotion>().value = 0;
        theCanvas.GetComponent<CreatePotion>().thisValue = 0;
        potionBook.SetActive(false);
    }

    public void OpenInventoryScreen()
    {
        helpCommands.SetActive(false);
        messageBox.SetActive(false);
        inventoryMenu.SetActive(true);
        inventoryScreen.SetActive(true);
        openBook.SetActive(true);
        closedBook.SetActive(false);
        mapScreen.SetActive(false);
        mapCam.SetActive(false);
    }

    public void OpenMapScreen()
    {
        helpCommands.SetActive(false);
        inventoryScreen.SetActive(false);
        mapScreen.SetActive(true);
        mapCam.SetActive(true);
    }

    public void OpenCommandsHelp()
    {
        inventoryScreen.SetActive(false);
        mapScreen.SetActive(false);
        helpCommands.SetActive(true);

    }

    IEnumerator Reset()
    {
        yield return new WaitForSeconds(0.1f);
        iconUpdate = false;
        max = emptySlots.Length;
    }

    //private IEnumerator MoveToTarget()
    //{
    //    // Move to a position with y = 30
    //    Vector3 targetPosition = new Vector3(transform.position.x, 30f, transform.position.z);
    //    while (GamePlayerForPortal.transform.position != targetPosition)
    //    {
    //        GamePlayerForPortal.transform.position = Vector3.MoveTowards(transform.position, targetPosition, 10f * Time.deltaTime);
    //        yield return null;
    //    }

    //    // Wait for a second
    //    yield return new WaitForSeconds(1f);

    //    // Move to the target position with y = 30
    //    targetPosition = new Vector3(portal1.transform.position.x, 30f, portal1.transform.position.z);
    //    while (GamePlayerForPortal.transform.position != targetPosition)
    //    {
    //        GamePlayerForPortal.transform.position = Vector3.MoveTowards(transform.position, targetPosition, 10f * Time.deltaTime);
    //        yield return null;
    //    }

    //    // Wait for a second
    //    yield return new WaitForSeconds(1f);

    //    // Move to the exact target position
    //    targetPosition = portal1.transform.position;
    //    while (GamePlayerForPortal.transform.position != targetPosition)
    //    {
    //        GamePlayerForPortal.transform.position = Vector3.MoveTowards(transform.position, targetPosition, 10f * Time.deltaTime);
    //        yield return null;
    //    }
    //}
}