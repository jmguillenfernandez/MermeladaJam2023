using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RaycastController : MonoBehaviour
{
    public ControlPuertas controlPuertas;
    public string digitoActual;
    public float maxRaycastDistance = 10f;
    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            // Obt�n la posici�n de la c�mara
            Vector3 rayOrigin = Camera.main.transform.position;

            // Obt�n la direcci�n de la mira de la c�mara
            Vector3 rayDirection = Camera.main.transform.forward;

            // Configura la longitud m�xima del Raycast (ajusta seg�n sea necesario)
           

            // Crea el rayo
            Ray ray = new Ray(rayOrigin, rayDirection);

            // Declara el hit (la informaci�n sobre la colisi�n)
            RaycastHit hit;

            // Realiza el Raycast
            if (Physics.Raycast(ray, out hit, maxRaycastDistance))
            {
                Debug.Log("Objeto detectado: " + hit.collider.gameObject.name);
                // Verifica si el objeto golpeado tiene la etiqueta deseada
                 if (hit.collider.CompareTag("1"))
                 {
                    digitoActual = "1";
                    AgregarD�gito();
                 }
                 else if (hit.collider.CompareTag("2"))
                {
                    digitoActual = "2";
                    AgregarD�gito();
                }
                else if (hit.collider.CompareTag("3"))
                {
                    digitoActual = "3";
                    AgregarD�gito();
                }
                else if (hit.collider.CompareTag("4"))
                {
                    digitoActual = "4";
                    AgregarD�gito();
                }
                else if (hit.collider.CompareTag("5"))
                {
                    digitoActual = "5";
                    AgregarD�gito();
                }
                else if (hit.collider.CompareTag("6"))
                {
                    digitoActual = "6";
                    AgregarD�gito();
                }
                else if (hit.collider.CompareTag("7"))
                {
                    digitoActual = "7";
                    AgregarD�gito();
                }
                else if (hit.collider.CompareTag("8"))
                {
                    digitoActual = "8";
                    AgregarD�gito();
                }
                else if (hit.collider.CompareTag("9"))
                {
                    digitoActual = "9";
                    AgregarD�gito();
                }

                 if (hit.collider.CompareTag("BotonRojo"))
                {
                    controlPuertas.BotonRojo();
                }

            }
        }
    }
    void AgregarD�gito()
    {
        controlPuertas.codigoIntroducido += digitoActual;
    }
}
