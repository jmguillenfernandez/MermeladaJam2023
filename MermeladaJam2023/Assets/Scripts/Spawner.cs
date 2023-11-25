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
    {  // Player = GameObject.Find("PlayerCapsule");
         GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        indexSpawn = GM.puntosdepawn;
        CurrentSpawn = PuntoDeSpawn[indexSpawn];
    }
    void Start()
    {
        
       /* indexSpawn = GM.puntosdepawn;
        CurrentSpawn = PuntoDeSpawn[indexSpawn];*/

    }


    
    void Update()
    {
        
    }
}
