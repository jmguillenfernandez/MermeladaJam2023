using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VicenteScript : MonoBehaviour
{
    public Llavero llavero;

    [Header("Muerte")]
    public Animator animmuerte,animPanelMuerte;
    
    // Start is called before the first frame update
    void Start()
    {
        llavero = GetComponent<Llavero>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCollisionEnter(Collision col)
    {

        /*if (col.gameObject.tag == "llavero")
        {
            llavero.tengollavero = true;
            Destroy(col.gameObject);
        }*/
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "llavero")
        {
            llavero.tengollavero = true;
            llavero.TutsacarllavesText.SetActive(true);
            Destroy(other.gameObject);
        }
    }
    public void VicenteMuerte()
    {
        animPanelMuerte.SetBool("muerto", true);
        animmuerte.enabled = true;
        
    }
}
