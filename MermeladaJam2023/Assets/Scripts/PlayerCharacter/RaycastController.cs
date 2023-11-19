using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastController : MonoBehaviour
{
    void Update()
    {
        // Obtén la posición de la cámara
        Vector3 rayOrigin = Camera.main.transform.position;

        // Obtén la dirección de la mira de la cámara
        Vector3 rayDirection = Camera.main.transform.forward;

        // Configura la longitud máxima del Raycast (ajusta según sea necesario)
        float maxRaycastDistance = 10f;

        // Crea el rayo
        Ray ray = new Ray(rayOrigin, rayDirection);

        // Declara el hit (la información sobre la colisión)
        RaycastHit hit;

        // Realiza el Raycast
        if (Physics.Raycast(ray, out hit, maxRaycastDistance))
        {
            Debug.Log("Objeto detectado: " + hit.collider.gameObject.name);
            // Verifica si el objeto golpeado tiene la etiqueta deseada
           /* if (hit.collider.CompareTag(objectTag))
            {
                // Aquí puedes realizar acciones con el objeto detectado
                Debug.Log("Objeto detectado: " + hit.collider.gameObject.name);
            }*/
        }
    }
}
