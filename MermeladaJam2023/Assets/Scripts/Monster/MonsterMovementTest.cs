using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class MonsterMovementTest : MonoBehaviour
{
    public GameObject player;

    public Camera cam;

    public float slowDownRange = 15;

    [Header("Mobility values")]
    public float farSpeed = 40;
    public float farAcceleration = 20;
    public float nearSpeed = 20;
    public float nearAcceleration = 10;


    [HideInInspector]
    public NavMeshAgent agent;
    Collider col;
    Ray ray;
    RaycastHit hit;
    float dist;
    float distance;

    [Header("DEBUG")]
    public bool slipperyMonster = false;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        col = GetComponent<Collider>();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, slowDownRange);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == player)
        {
            Debug.Log("Death");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
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

        distance = Vector3.Distance(gameObject.transform.position, player.transform.position);

        if(distance < slowDownRange)
        {
            agent.speed = nearSpeed;
            agent.acceleration = nearAcceleration;
        }
        else
        {
            agent.speed = farSpeed;
            agent.acceleration = farAcceleration;
        }

        if(IsVisible() && !IsHiddenByObject())
        {
            player.GetComponentInChildren<BlinkManager>().directEyeContact = false;
        }

        else
        {
            player.GetComponentInChildren<BlinkManager>().directEyeContact = true;
        }

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
