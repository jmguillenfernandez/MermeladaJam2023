using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Llavero : MonoBehaviour
{
    public Animator anim;
    public bool tengollavero, llavesfuera;
    public int IDkey = 0;
    public Transform llavesTransform;
    public GameObject llaveactual,llaveInstanciada;
    public GameObject[] llaves;
    //TUTORIAL
    public bool TutorialLlavero;
    public GameObject TutsacarllavesText, TutruletaText;
    void Start()
    {
        llaveactual = null;
    }

    // Update is called once per frame
    void Update()
    {
        float scrollValue = Mouse.current.scroll.y.ReadValue();

        if (tengollavero == true)
        {
            if (Mouse.current.rightButton.wasPressedThisFrame)
            {
           
                    if (TutorialLlavero == true)
                    {
                        TutruletaText.SetActive(true);
                        TutsacarllavesText.SetActive(false);
                    }
                    anim.SetTrigger("Sacarllaves");
                    llaveactual = llaves[IDkey];
                    llaveInstanciada = Instantiate(llaveactual, llavesTransform);
                    llavesfuera = true;
                

            }
            else if (Mouse.current.rightButton.wasReleasedThisFrame)
            {
                if (TutorialLlavero == true)
                {
                    TutruletaText.SetActive(false);
                    TutsacarllavesText.SetActive(true);
                }
                anim.SetTrigger("Guardarllaves");
                Destroy(llaveInstanciada);
                llavesfuera = false;
            }
        }

        if(llavesfuera == true)
        {
            if (scrollValue > 0f)
            {
                Destroy(llaveInstanciada);
                // Rueda del ratón hacia arriba
                if (IDkey < llaves.Length -1)
                {
                    IDkey += 1;
                }else if(IDkey == llaves.Length -1)
                {
                    IDkey = 0;
                }
                llaveactual = llaves[IDkey];
                llaveInstanciada = Instantiate(llaveactual, llavesTransform);
            }
            else if (scrollValue < 0f)
            {
                Destroy(llaveInstanciada);
                // Rueda del ratón hacia abajo
                if (IDkey > 0)
                {
                    IDkey -= 1;
                }else if (IDkey == 0)
                {
                    IDkey = llaves.Length - 1;
                }
                llaveactual = llaves[IDkey];
                llaveInstanciada = Instantiate(llaveactual, llavesTransform);
            }
        }
    }


        
    
}
