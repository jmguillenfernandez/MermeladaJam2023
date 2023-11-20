using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameManager GM;
    public GameObject Player;
    public GameObject[] PuntoDeSpawn;
    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        Player.transform.position = PuntoDeSpawn[GM.puntosdepawn].transform.position;
        Player.transform.rotation = PuntoDeSpawn[GM.puntosdepawn].transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
