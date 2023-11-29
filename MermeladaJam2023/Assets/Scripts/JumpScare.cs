using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScare : MonoBehaviour
{
    public GameManager GM;
    public Transform instanciador;
    AudioSource aus;
    public bool sustodado;
    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        aus = GetComponent<AudioSource>();
           
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" && GM.MonstruoActivo == true)
        {
            if (sustodado == false)
            {
                sustodado = true;
                GM.Baal.transform.position = instanciador.position;
                GM.Baal.SetActive(true);
                aus.Play();
            }

        }
    }
}
