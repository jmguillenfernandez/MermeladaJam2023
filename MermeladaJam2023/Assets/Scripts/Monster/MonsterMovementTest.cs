using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterMovementTest : MonoBehaviour
{
    public GameObject player;
    
    [HideInInspector]
    public NavMeshAgent agent;

    public bool slipperyMonster = false;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if(player.GetComponentInChildren<BlinkManager>().isEyeClosed)
        {
            agent.isStopped = false;
            agent.SetDestination(player.transform.position);
        }
        else
        {
            agent.isStopped = true;
            if(!slipperyMonster)
            {
                agent.velocity = Vector3.zero;
            }
        }
    }
}
