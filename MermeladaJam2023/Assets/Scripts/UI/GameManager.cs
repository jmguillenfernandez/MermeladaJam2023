using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public bool TESTMODE;


    public GameObject pauseMenuUI;
    public FirstPersonController fpc;
    private float currentMouseSensibility;
    private float currentPlayerSpeed;
    private float currentPlayerSprint;
    public static bool GameIsPaused = false;

    public Scene Menu, Vestibulo, Ba�os, SalaCarven, Garita, Columnas, Sotano, Salas;

    //MODO ALARMA
    public bool Bloqueo;
    public GameObject[] puertasBloqueo;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        Bloqueo = false;
    }
    private void Update()
    {
        // Todo lo que esta en testmode es para que nosotros probemos cosas
        if (TESTMODE)
        {
            if (Input.GetKeyDown(KeyCode.O))
            {
                Bloquear();
            }
            if (Input.GetKeyDown(KeyCode.P))
            {
                Desbloquear();
            }
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

    #region Alarma
    public void Bloquear()
    {
        foreach (GameObject anim in puertasBloqueo)
        {
            anim.GetComponentInChildren<Animator>().SetTrigger("Cerrar");
        }
        Bloqueo = true;
    }
    public void Desbloquear()
    {
        foreach (GameObject anim in puertasBloqueo)
        {
            anim.GetComponentInChildren<Animator>().SetTrigger("Abrir");
        }
        Bloqueo = false;
    }
    #endregion

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
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        fpc.RotationSpeed = currentMouseSensibility;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        currentMouseSensibility = fpc.RotationSpeed;
        fpc.RotationSpeed = 0f;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        GameIsPaused = true;
    }
    #endregion
}
