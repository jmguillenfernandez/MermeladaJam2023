using Cinemachine;
using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class MonsterMovementTest : MonoBehaviour
{
    public GameObject player;

    public Camera cam;
    
    public Mesh[] meshes;

    public float slowDownRange = 15;

    public float killDistance = 4.5f;

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
    MeshFilter meshFilter;
    bool changedMesh = false;

    [Header("DEBUG")]
    public bool slipperyMonster = false;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        col = GetComponent<Collider>();
        meshFilter = GetComponent<MeshFilter>();
        player = FindObjectOfType<FirstPersonController>().gameObject;
        cam = FindObjectOfType<CinemachineBrain>().gameObject.GetComponent<Camera>();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, slowDownRange);
    }

    public void Death()
    {
            Debug.Log("Death");
            FindObjectOfType<GameManager>().Bloqueo = false;
            FindObjectOfType<GameManager>().MonstruoActivo = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene(0);
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

    public void ChangeMesh()
    {
        meshFilter.mesh = meshes[Random.Range(0, meshes.Length - 1)];
        changedMesh = true;
    }

    void Update()
    {
        IsHiddenByObject();
        bool eyeState = player.GetComponentInChildren<BlinkManager>().isEyeClosed;

        distance = Vector3.Distance(gameObject.transform.position, player.transform.position);

        if (distance < killDistance)
        {
            Death();
        }

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

        if (IsVisible() || eyeState || !IsHiddenByObject())
        {
           // Debug.Log("No me ven porque IsVisible es " + IsVisible() + ", eyeState es " + eyeState + " y IsHiddenByObject es " + IsHiddenByObject());
            if(!changedMesh)
            {
                ChangeMesh();
            }
            agent.isStopped = false;
            agent.SetDestination(player.transform.position);
        }
        else
        {
            //Debug.Log("Me ven");
            agent.isStopped = true;
            changedMesh = false;
            if(!slipperyMonster)
            {
                agent.velocity = Vector3.zero;
            }
        }
    }
}
