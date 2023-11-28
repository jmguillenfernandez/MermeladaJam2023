using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InicioManager : MonoBehaviour
{
    public GameManager GM;
    public GameObject canvasintro, canvasrender;
    public CharacterController CharCon;
   
    void Start()
    {
        //que se prohiba mover al player
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        CharCon.enabled = false;
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        if(GM.Introterminada == false)
        {
            GM.Intro();
        }
        AudioClip llamada = GM.musicList.tracks[1].AudioClip;
        Invoke("FinDeLlamada", llamada.length);
    }

    
    void Update()
    {
        
    }
    public void FinDeLlamada()
    {
        GM.aus.Stop();
        canvasrender.SetActive(true);
        canvasintro.SetActive(false);
        CharCon.enabled = true;
        GM.FinDeLlamada();

       
    }
    
}
