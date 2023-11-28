using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ControlPuertas : MonoBehaviour
{
    public GameManager GM;

    public string codigoIntroducido, codigoCorrecto;
    public TextMeshProUGUI codigotext;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        codigotext.text = codigoIntroducido;
    }

    public void BotonRojo()
    {
        if(codigoIntroducido == codigoCorrecto)
        {
            //desbloquear puerta principal
        }
        else 
        { 
            codigoIntroducido = null; 
            //sonido error
        
        }
    }
}
