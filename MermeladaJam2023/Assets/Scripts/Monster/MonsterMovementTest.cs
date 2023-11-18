using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterMovementTest : MonoBehaviour
{
    public GameObject player;

    public Camera cam;

    [HideInInspector]
    public NavMeshAgent agent;
    Collider col;
    Ray ray;
    RaycastHit hit;
    float dist;

    [Header("DEBUG")]
    public bool slipperyMonster = false;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        col = GetComponent<Collider>();
    }

    private bool IsVisible()
    {
        var bounds = col.bounds;
        if(GeometryUtility.TestPlanesAABB(GeometryUtility.CalculateFrustumPlanes(cam), bounds))
        {
            return false;
        }
        return true;
    }

    private bool IsHiddenByObject()
    {
        ray = new Ray(cam.transform.position, transform.position - cam.transform.position);

        if(Physics.Raycast(ray, out hit))
        {
            if(hit.collider ==gameObject.GetComponent<Collider>())
            {
                return false;
            }
        }
        return true;
    }

    void Update()
    {
        IsHiddenByObject();
        bool eyeState = player.GetComponentInChildren<BlinkManager>().isEyeClosed;

        if (IsVisible() || eyeState || IsHiddenByObject())
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
