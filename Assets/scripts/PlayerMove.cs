using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Cinemachine;
using UnityEngine.SceneManagement;



public class PlayerMove : MonoBehaviour
{
    private NavMeshAgent nav;
    private Animator anim;
    private Ray ray;
    private RaycastHit hit;

    private float x;
    private float z;
    private float velocitySpeed;

    CinemachineTransposer ct;
    CinemachineOrbitalTransposer cot;
    private Vector3 pos;
    private Vector3 currPos;
    private string axisNamed = "Mouse X";
    public static bool canMove = true;
    public static bool moving = false;
    public LayerMask moveLayer;
    public GameObject freeCam;
    public GameObject staticCam;
    private bool freeCamActive = true;
    public GameObject spawnPoint;
    private WaitForSeconds approachEnemy = new WaitForSeconds(0.3f);
    public GameObject[] playerObjs;
    public GameObject[] weapons;
    public string[] attacks;
    public GameObject inventoryObj;
    private AnimatorStateInfo playerInfo;
    public AudioSource audioPlayer;
    public AudioClip[] weaponSounds;
    private GameObject trailObj;
    private WaitForSeconds trailOffTime = new WaitForSeconds(0.1f);
    public float[] staminaCost;
    public float currentHealth = 1.0f;
    public GameObject hitEffect;
    private WaitForSeconds hitOff = new WaitForSeconds(0.5f);

    private int randomNumber;



    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        ct = freeCam.gameObject.GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineTransposer>();
        cot = staticCam.gameObject.GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineOrbitalTransposer>();
        currPos = ct.m_FollowOffset;
        freeCam.SetActive(true);
        staticCam.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        playerInfo = anim.GetCurrentAnimatorStateInfo(0);
        //calculating velocity speed
        x = nav.velocity.x;
        z = nav.velocity.z;
        velocitySpeed = x + z;

        // Getting mouse position

        pos = Input.mousePosition;
        ct.m_FollowOffset = currPos;

        if (Input.GetKeyDown(KeyCode.Z))
        {
            if(inventoryObj.GetComponent<InventoryItems>().weaponToggle == true)
            {
                randomNumber = Random.Range(0, 2);
                anim.SetTrigger(attacks[randomNumber]);
                audioPlayer.clip = weaponSounds[0];
                audioPlayer.Play();
                //anim.SetBool("S1", true);
                //anim.SetBool("S1", false);
            }
        }

        if (Input.GetMouseButtonDown(0) && playerInfo.IsTag("nonAttack") && !anim.IsInTransition(0))
        {
            if (canMove == true)
            {
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit,300, moveLayer))
                {
                    nav.destination = hit.point;
                }
            }
        }

        if (velocitySpeed != 0)
        {
                anim.SetBool("sprinting", true);
            moving = true;
        }
        if (velocitySpeed == 0)
        {
            anim.SetBool("sprinting", false);
            moving = false;
        }

        if (Input.GetMouseButton(1))
        {
            cot.m_XAxis.m_InputAxisName = axisNamed;
            if (pos.x !=0 || pos.y != 0)
            {
                currPos = pos/200;
            }
        }

        if (Input.GetMouseButtonUp(1))
        {
            cot.m_XAxis.m_InputAxisName = null;
            cot.m_XAxis.m_InputAxisValue = 0;
        }

            if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            if (freeCamActive == true)
            {
                freeCam.SetActive(false);
                staticCam.SetActive(true);
                freeCamActive = false;
            }
            else if (freeCamActive == false)
            {
                freeCam.SetActive(true);
                staticCam.SetActive(false);
                freeCamActive = true;
            }
        }


    }
}
