using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InicioManager : MonoBehaviour
{
    public GameManager GM;
   
    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        if(GM.Introterminada == false)
        {
            Intro();
        }
    }

    
    void Update()
    {
        
    }
    public void Intro()
    {
        GM.
    }
}
