using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puerta : MonoBehaviour
{
    public bool abierta;
    public int IDDoor;
    public Collider colliderpuerta;
    public Animator anim;
    public Llavero llavero;
    void Start()
    {
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
           llavero = col.GetComponent<Llavero>();
            if(llavero.tengollavero == true)
            {
                if(llavero.IDkey == IDDoor)
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
}
