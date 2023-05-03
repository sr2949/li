using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class EnemyAttack : MonoBehaviour
{
    NavMeshAgent agent;
    public GameObject player;
    Transform playerPos;
    public Animator anim;
    float distance;
    public float chaseRange = 10;
    public Image healthImage;
    public InputField codeEnter;
    private int killCount;
    public GameObject egg;
    public GameObject portal;
    public GameObject portalMap;
    // Start is called before the first frame update
    void Start()
    {
        playerPos = player.transform;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        //if(distance > 5)
        //{
        //    anim.SetTrigger("attack");
        //    anim.SetBool("IsChasing", false);
        //    anim.SetBool("IsPatrolling", false);
        //    player.GetComponent<PlayerMove>().currentHealth = player.GetComponent<PlayerMove>().currentHealth - 0.4f;
        //    healthImage.fillAmount -= 0.4f;
        //}
        //else
        //{
        //    anim.SetBool("IsChasing", false);
        //    anim.SetBool("IsPatrolling", true);
        //}
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (InventoryItems.key == true)
            {
                codeEnter.onEndEdit.AddListener(SubmitInput);

            }
        }
    }
    public void SubmitInput(string Input)
    {
        if (Input == "kill")
        {
            if(killCount == 5)
            {
                Destroy(gameObject);
                portal.SetActive(true);
                portalMap.SetActive(true);
            }
            else
            {
                killCount++;
            }
        }
        codeEnter.text = "";
    }
    public void onSubmit(BaseEventData eventData)
    {
        SubmitInput(codeEnter.text);
    }
}
