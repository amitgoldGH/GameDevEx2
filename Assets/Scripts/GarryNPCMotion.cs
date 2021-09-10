using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GarryNPCMotion : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator NPCAnimator;
    private NavMeshAgent agent;
    public GameObject target1;
    public GameObject target2;
    public GameObject[] targets;
    private GameObject MainTarget;
    private int targetNum;

    void NextTarget()
    {
        targetNum++;
        if (targetNum > 2)
        {
            targetNum = 1;
        }
        MainTarget = targets[targetNum - 1];
        /*switch(targetNum)
        {
            case 1:
                MainTarget = target1;
                break;
            case 2:
                MainTarget = target2;
                break;
        }*/
    }
    IEnumerator StopAndSitThenChangeTarget()
    {
        // before delay
        agent.enabled = false; // stop walking

        NPCAnimator.SetInteger("state", 0); // stopping and going idle

        //delay
        yield return new WaitForSeconds(1);
        //after delay
        NPCAnimator.SetInteger("state", 4); // idle to sitting down
        //more delay
        yield return new WaitForSeconds(3);
        //after delay
        NPCAnimator.SetInteger("state", 5); // sitting down idle
        // sit for a while
        yield return new WaitForSeconds(5);
        NPCAnimator.SetInteger("state", 6); // sit to stand idle
        // animation delay
        yield return new WaitForSeconds(3);
        NPCAnimator.SetInteger("state", 0); // idle
        yield return new WaitForSeconds(1);

        NextTarget();
        
        agent.enabled = true;
        agent.SetDestination(MainTarget.transform.position);

    }
    void Start()
    {
        NPCAnimator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        targetNum = 1;
        MainTarget = targets[0];
        agent.SetDestination(MainTarget.transform.position);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.enabled)
        {
            if (MainTarget != null)
            {
                if (agent.remainingDistance < 0.5)
                {
                    this.gameObject.transform.rotation = MainTarget.transform.rotation;
                    StartCoroutine(StopAndSitThenChangeTarget());
                }
                else
                {
                    NPCAnimator.SetInteger("state", 1);
                }
            }
        }
/*        if (Input.GetKeyDown(KeyCode.Z))
        {
            NPCAnimator.SetInteger("state", 1); // 
        }*/

    }
}
/*
Idle: state = 0

Walking: state = 1

Ascending: state = 2

Descending: state = 3

Stand to sit : state = 4

Sitting idle : state = 5

Sit to stand : state = 6
*/