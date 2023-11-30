using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{ 
    public static GameManager GameMan;

    public bool TESTMODE;


    public GameObject pauseMenuUI;
    public FirstPersonController fpc;
    
    private float currentMouseSensibility;
    private float currentPlayerSpeed;
    private float currentPlayerSprint;
    public static bool GameIsPaused = false;

    public Scene Menu, Vestibulo, Baños, SalaCarven, Garita, Columnas, Sotano, Salas;

    [Header("MusicList")]
    public MusicList musicList;
    public AudioSource aus;
    public AudioClip currentMusic;

    //MODO ALARMA
    public bool Bloqueo;

    public bool MonstruoActivo;
    public GameObject Baal;
    public string EscenaActual;

    //EVENTOS
    public GameObject Canvasinicio;
    public bool Introterminada;

    //TRANSICION
    public int puntosdepawn;

   
    private void Awake()
    {

        /* if(GameMan != null)
         {
             Destroy(gameObject);
         }
         else
         {
             GameMan = this;
         }
         DontDestroyOnLoad(gameObject); */

        if (GameMan == null)
        {
            GameMan = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // Si ya existe una instancia, destruye este objeto para evitar duplicados
            Destroy(gameObject);
        }

        aus = GetComponent<AudioSource>();
    }

    private void Start()
    {
       SceneManager.sceneLoaded += OnSceneLoaded;

        GameObject playerCapsule = GameObject.Find("PlayerCapsule");
       // Bloqueo = false;
        if(playerCapsule != null)
        {
            fpc = playerCapsule.GetComponent<FirstPersonController>();

        }
        else
        {
            Debug.Log("En esta escena no hay player");
        }

        aus = GetComponent<AudioSource>();

        Baal = GameObject.Find("SM_Monster");
        EscenaActual = SceneManager.GetActiveScene().name;

        if (Baal != null)
        {
            if (EscenaActual != "Baños_pasillo")
            {
                Baal.SetActive(MonstruoActivo);
            }
            else { Baal.SetActive(false); }

        }
        else { Debug.Log("No hay demonios en esta escena"); }
       

    }
   void OnSceneLoaded(Scene scene,LoadSceneMode mode)
    {
        Debug.Log("scene "+ scene.name +" loaded");
        GameObject playerCapsule = GameObject.Find("PlayerCapsule");
        if (playerCapsule != null)
        {
            fpc = playerCapsule.GetComponent<FirstPersonController>();

        }
        else
        {
            Debug.Log("En esta escena no hay player");
        }
        aus = GetComponent<AudioSource>();

        Baal = GameObject.Find("SM_Monster");
        EscenaActual = SceneManager.GetActiveScene().name;

        if (Baal != null)
        {
            if (EscenaActual != "Baños_pasillo") 
            { 
            Baal.SetActive(MonstruoActivo);
            }
            else { Baal.SetActive(false); }

        }
        else { Debug.Log("No hay demonios en esta escena"); }

    }
    private void Update()
    {
        // Todo lo que esta en testmode es para que nosotros probemos cosas
        if (TESTMODE)
        {
           
        }


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

        if(GameIsPaused)
        {
            if (Input.GetKeyDown(KeyCode.M))
            {
                Debug.Log("Menu");
                GoToMenu();
            }
        }
    }
    #region Inicio
    public void Intro()
    {
        AudioClip llamada = musicList.tracks[1].AudioClip;
        aus.PlayOneShot(llamada);
        
        
    }
    public void FinDeLlamada()
    {   
        Introterminada = true;
        currentMusic = musicList.tracks[3].AudioClip;
        aus.clip = currentMusic;
        aus.Play();
        aus.loop = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

   
    #endregion

    #region Alarma

    public void Alarma()
    {
        Bloqueo = true;
        MonstruoActivo = true;
        aus = GetComponent<AudioSource>();
        currentMusic = musicList.tracks[6].AudioClip;
        aus.clip = currentMusic;
        aus.Play();
    }
   
    #endregion

    public void DeathGM()
    {
        Bloqueo = false;
        MonstruoActivo = false;
       
        StartCoroutine(TiempoPostMuerte());
    }

    IEnumerator TiempoPostMuerte()
    {
        yield return new WaitForSeconds(7f);
        PostMuerte();
    }
    public void PostMuerte()
    {
        SceneManager.LoadScene(0);
    }

    #region Bloqueo de control del jugador
    public void LockPlayer()
    {
        currentMouseSensibility = fpc.RotationSpeed;
        currentPlayerSpeed = fpc.MoveSpeed;
        currentPlayerSprint= fpc.SprintSpeed;
        fpc.RotationSpeed = 0f;
        fpc.MoveSpeed = 0f;
        fpc.SprintSpeed = 0f;
    }

    public void UnlockPlayer()
    {
        fpc.RotationSpeed = currentMouseSensibility;
        fpc.MoveSpeed = currentPlayerSpeed;
        fpc.SprintSpeed = currentPlayerSprint;
    }
    #endregion

    public void GoToMenu()
    {
        Time.timeScale = 1f;
        fpc.RotationSpeed = currentMouseSensibility;
        SceneManager.LoadScene(0);
    }

    #region Pause
    public void Resume()
    {
       /* if (pauseMenuUI != null)
        {
            pauseMenuUI.SetActive(false);
        }*/
        Time.timeScale = 1f;
        fpc.RotationSpeed = currentMouseSensibility;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        GameIsPaused = false;
    }

    void Pause()
    {
      /*  if (pauseMenuUI != null)
        {
            pauseMenuUI.SetActive(true);
        }*/
        Time.timeScale = 0f;
        currentMouseSensibility = fpc.RotationSpeed;
        fpc.RotationSpeed = 0f;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        GameIsPaused = true;
    }
    #endregion
}
