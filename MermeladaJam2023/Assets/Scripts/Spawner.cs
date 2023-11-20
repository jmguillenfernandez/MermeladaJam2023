using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameManager GM;
    public GameObject Player;
    public GameObject[] PuntoDeSpawn;
    public GameObject CurrentSpawn;
    public int indexSpawn;
    public float tiempoSpawn = 0.1f;

    private void Awake()
    {   Player = GameObject.Find("PlayerCapsule");
         GM = GameObject.Find("GameManager").GetComponent<GameManager>();
       
    }
    void Start()
    {
       StartCoroutine (Spawnear());
        
    }

    IEnumerator Spawnear()
    {
        yield return new WaitForSeconds(tiempoSpawn);
        InstanciarPlayer();
    }
    public void InstanciarPlayer()
    {
        Debug.Log("instanciando Player");
        indexSpawn = GM.puntosdepawn;
        CurrentSpawn = PuntoDeSpawn[indexSpawn];
        Player.transform.rotation = CurrentSpawn.transform.rotation;
        Player.transform.position = CurrentSpawn.transform.position;
        

    }
    
    void Update()
    {
        
    }
}
