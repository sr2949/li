using UnityEngine.AI;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : StateMachineBehaviour
{
    float timer;
    List<Transform> wayPoints = new List<Transform>();
     public GameObject[] dragonWayPoints;
    NavMeshAgent Agent;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Agent = animator.GetComponent<NavMeshAgent>();
        timer = 0;
        dragonWayPoints = GameObject.FindGameObjectsWithTag("WayPoints");
        //foreach (Transform t in dragonWayPoints[].transform)
        for (int i = 0; i < dragonWayPoints.Length; i++) {
            Transform t = dragonWayPoints[i].transform;
            wayPoints.Add(t);
                }
        Agent.SetDestination(wayPoints[Random.Range(0, wayPoints.Count)].position);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Agent.remainingDistance <= Agent.stoppingDistance)
        {
            Agent.SetDestination(wayPoints[Random.Range(0, wayPoints.Count)].position);
        }
        timer += Time.deltaTime;
        if (timer > 10)
        {
            animator.SetBool("IsPatrolling", false);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Agent.SetDestination(Agent.transform.position);
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
