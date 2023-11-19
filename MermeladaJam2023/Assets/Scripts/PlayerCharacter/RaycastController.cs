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
            // Obtén la posición de la cámara
            Vector3 rayOrigin = Camera.main.transform.position;

            // Obtén la dirección de la mira de la cámara
            Vector3 rayDirection = Camera.main.transform.forward;

            // Configura la longitud máxima del Raycast (ajusta según sea necesario)
           

            // Crea el rayo
            Ray ray = new Ray(rayOrigin, rayDirection);

            // Declara el hit (la información sobre la colisión)
            RaycastHit hit;

            // Realiza el Raycast
            if (Physics.Raycast(ray, out hit, maxRaycastDistance))
            {
                Debug.Log("Objeto detectado: " + hit.collider.gameObject.name);
                // Verifica si el objeto golpeado tiene la etiqueta deseada
                 if (hit.collider.CompareTag("1"))
                 {
                    digitoActual = "1";
                    AgregarDígito();
                 }
                 else if (hit.collider.CompareTag("2"))
                {
                    digitoActual = "2";
                    AgregarDígito();
                }
                else if (hit.collider.CompareTag("3"))
                {
                    digitoActual = "3";
                    AgregarDígito();
                }
                else if (hit.collider.CompareTag("4"))
                {
                    digitoActual = "4";
                    AgregarDígito();
                }
                else if (hit.collider.CompareTag("5"))
                {
                    digitoActual = "5";
                    AgregarDígito();
                }
                else if (hit.collider.CompareTag("6"))
                {
                    digitoActual = "6";
                    AgregarDígito();
                }
                else if (hit.collider.CompareTag("7"))
                {
                    digitoActual = "7";
                    AgregarDígito();
                }
                else if (hit.collider.CompareTag("8"))
                {
                    digitoActual = "8";
                    AgregarDígito();
                }
                else if (hit.collider.CompareTag("9"))
                {
                    digitoActual = "9";
                    AgregarDígito();
                }

                 if (hit.collider.CompareTag("BotonRojo"))
                {
                    controlPuertas.BotonRojo();
                }

            }
        }
    }
    void AgregarDígito()
    {
        controlPuertas.codigoIntroducido += digitoActual;
    }
}
