using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puerta : MonoBehaviour
{
    public bool abierta;
    public int IDDoor;
    public Collider colliderpuerta;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            if(col.GetComponent<Llavero>().tengollavero == true)
            {
                if(col.GetComponent<Llavero>().IDkey == IDDoor)
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
       colliderpuerta.enabled = false;
        //sonido abierta
        //
    }
    public void LLaveIncorrecta()
    {
        Debug.Log("llave incorrecta");
    }
}
