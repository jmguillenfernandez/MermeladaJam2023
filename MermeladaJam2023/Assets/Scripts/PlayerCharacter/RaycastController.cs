using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastController : MonoBehaviour
{
    void Update()
    {
        // Obt�n la posici�n de la c�mara
        Vector3 rayOrigin = Camera.main.transform.position;

        // Obt�n la direcci�n de la mira de la c�mara
        Vector3 rayDirection = Camera.main.transform.forward;

        // Configura la longitud m�xima del Raycast (ajusta seg�n sea necesario)
        float maxRaycastDistance = 10f;

        // Crea el rayo
        Ray ray = new Ray(rayOrigin, rayDirection);

        // Declara el hit (la informaci�n sobre la colisi�n)
        RaycastHit hit;

        // Realiza el Raycast
        if (Physics.Raycast(ray, out hit, maxRaycastDistance))
        {
            Debug.Log("Objeto detectado: " + hit.collider.gameObject.name);
            // Verifica si el objeto golpeado tiene la etiqueta deseada
           /* if (hit.collider.CompareTag(objectTag))
            {
                // Aqu� puedes realizar acciones con el objeto detectado
                Debug.Log("Objeto detectado: " + hit.collider.gameObject.name);
            }*/
        }
    }
}
