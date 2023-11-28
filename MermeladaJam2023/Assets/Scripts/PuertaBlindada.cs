using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertaBlindada : MonoBehaviour
{
    GameManager GM;
    public Vector3 posicioncerrada;
    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        if(GM.Bloqueo == true) { Cerrada(); }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Cerrada()
    {
        transform.position = posicioncerrada;
    }
}
