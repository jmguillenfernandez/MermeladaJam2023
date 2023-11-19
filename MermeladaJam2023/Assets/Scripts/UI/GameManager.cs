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
    public static bool GameIsPaused = false;

    //MODO ALARMA
    public bool Bloqueo;
    public Animator[] puertasBloqueo;

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

    //ALARMA
    public void Bloquear()
    {
        foreach (Animator anim in puertasBloqueo)
        {
            anim.SetTrigger("Cerrar");
        }
        Bloqueo = true;
    }
    public void Desbloquear()
    {
        foreach (Animator anim in puertasBloqueo)
        {
            anim.SetTrigger("Abrir");
        }
        Bloqueo = false;
    }




    public void GoToMenu()
    {
        Time.timeScale = 1f;
        fpc.RotationSpeed = currentMouseSensibility;
        SceneManager.LoadScene(0);
    }

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
}
