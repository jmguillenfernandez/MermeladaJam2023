using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Puerta : MonoBehaviour
{
    public GameManager GM;

    public bool PuertaInMapa;
    public bool abierta;

    public int IDDoor;
    public Collider colliderpuerta;
    public Animator anim;
    public Llavero llavero;

    //Destino
    public int DestinoIndex;
    public int puntoDeSpawn;

    // inmapa
    public GameObject spawnpoint;
    public GameObject Player;


    void Start()
    {
        if(PuertaInMapa == true)
        {
            Player = GameObject.Find("PlayerCapsule");
        }
           
    GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {

            if (PuertaInMapa == true)
            {
                Destino();
            }
            else
            {
                if (abierta == true)
                {
                    if (GM != null)
                    {
                        GM.puntosdepawn = puntoDeSpawn;
                    }

                    Destino();
                }
                llavero = col.GetComponent<Llavero>();
                if (llavero.tengollavero == true)
                {
                    if (llavero.IDkey == IDDoor)
                    {
                        AbrirPuerta();
                    }
                    else
                    {
                        LLaveIncorrecta();
                    }
                }
                else
                {
                    Debug.Log("No tienes llaves");
                }
            }
        }
    }

    public void AbrirPuerta()
    {
        Debug.Log("puerta " + IDDoor + " abierta");
        abierta = true;

        if(colliderpuerta != null)
        {
            colliderpuerta.enabled = false;
        }
      

        if (anim != null)
        {
            anim.SetBool("Abrir", true);
        }
        if(llavero.TutorialLlavero == true)
        {
            llavero.TutorialLlavero = false;
            llavero.TutruletaText.SetActive(false);
            llavero.TutsacarllavesText.SetActive(false);
        }
        //sonido abierta
        //
    }
    public void LLaveIncorrecta()
    {
        Debug.Log("llave incorrecta");
    }

    public void Destino()
    {
        if (PuertaInMapa == false)
        {
            SceneManager.LoadScene(DestinoIndex);
        }
        else
        {
            Player.transform.position = spawnpoint.transform.position;
            Player.transform.rotation = spawnpoint.transform.rotation;
        }
    }
}
