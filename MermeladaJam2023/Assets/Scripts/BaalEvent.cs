using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaalEvent : MonoBehaviour
{
    public GameManager GM;
    public Animator CuadroAnimator;
    public GameObject pose1, pose2, baal;
    public GameObject[] luces;
    public float TiempoOscuro;
    public GameObject trueFrame;
    bool entered = false;
    // Start is called before the first frame update

    private void Awake()
    {
        GM = FindObjectOfType<GameManager>();
    }

    void Start()
    {
        pose1.SetActive(false);
        pose2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            if (!entered)
            {
                entered = true;
                trueFrame.SetActive(false);
                CuadroAnimator.SetBool("empieza", true);
            }
            
        }
    }
    public void Oscuro1()
    {
        foreach ( GameObject luz in luces)
        {
            luz.SetActive(false);

        }
        pose1.SetActive(true);
        StartCoroutine (espera1());

    }
    IEnumerator espera1()
    {
        yield return new WaitForSeconds(TiempoOscuro);
        Luz1();
    }
    void Luz1()
    {
        //pose1
        foreach (GameObject luz in luces)
        {
            luz.SetActive(true);

        }
        StartCoroutine(espera2());
    }
    IEnumerator espera2()
    {
        yield return new WaitForSeconds(TiempoOscuro);
        Oscuro2();
    }
    void Oscuro2()
    {
        foreach (GameObject luz in luces)
        {
            luz.SetActive(false);

        }
        pose1.SetActive(false);
        pose2.SetActive(true);
        StartCoroutine(espera3());
    }
    IEnumerator espera3()
    {
        yield return new WaitForSeconds(TiempoOscuro);
        Luz2();
    }

    void Luz2()
    {
        //pose2
        foreach (GameObject luz in luces)
        {
            luz.SetActive(true);

        }
        StartCoroutine(espera4());
    }
    IEnumerator espera4()
    {
        yield return new WaitForSeconds(TiempoOscuro);
        Oscuro3();
    }
    void Oscuro3()
    {
        foreach (GameObject luz in luces)
        {
            luz.SetActive(false);

        }
      
        pose2.SetActive(false);
        StartCoroutine(espera5());
    }
    IEnumerator espera5()
    {
        yield return new WaitForSeconds(TiempoOscuro);
        Luz3();
    }
    void Luz3()
    {
        //baal
        foreach (GameObject luz in luces)
        {
            luz.SetActive(true);

        }
        baal.SetActive(true);
        GM.Bloqueo = true;
        GM.MonstruoActivo = true;
       
    }
}
