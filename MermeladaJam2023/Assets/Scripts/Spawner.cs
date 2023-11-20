using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameManager GM;
    public GameObject Player;
    public GameObject[] PuntoDeSpawn;
    public int indexSpawn;
    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        Player = GameObject.Find("PlayerCapsule");
        indexSpawn = GM.puntosdepawn;
        Player.transform.position = PuntoDeSpawn[indexSpawn].transform.position;
        Player.transform.rotation = PuntoDeSpawn[indexSpawn].transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
