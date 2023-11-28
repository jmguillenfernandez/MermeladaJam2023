using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Final : MonoBehaviour
{
    public GameObject canvasfinal;
    public GameManager GM;
    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(GM.MonstruoActivo == true)
            {
                GM.aus.Stop();

                GM.aus.clip = GM.musicList.tracks[10].AudioClip;
                GM.aus.Play();
                SceneManager.LoadScene("Final");

            }
            
        }
    }
}
