using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public AudioMixer audioMixer;

    public TMPro.TMP_Dropdown resolutionDropdown;

    public static bool GameIsPaused = false;

    //public GameObject pauseMenuUI;

    public FirstPersonController fpc;

    private Resolution[] resolutions;

    private float currentMouseSensibility;
    private void OnEnable()
    {
        resolutions = Screen.resolutions;

        if(resolutionDropdown != null)
        {
            resolutionDropdown.ClearOptions();

            List<string> options = new List<string>();

            int currentResolutionIndex = 0;

            for(int i = 0; i < resolutions.Length; i++)
            {
                string option = resolutions[i].width + " x " + resolutions[i].height;
                options.Add(option);

                if (resolutions[i].width == Screen.currentResolution.width &&
                    resolutions[i].height == Screen.currentResolution.height)
                {
                    currentResolutionIndex= i;
                }
            }

            resolutionDropdown.AddOptions(options);
            resolutionDropdown.value = currentResolutionIndex;
            resolutionDropdown.RefreshShownValue();
        }
    }

    /*private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
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
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        fpc.RotationSpeed = currentMouseSensibility;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        GameIsPaused =false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        currentMouseSensibility = fpc.RotationSpeed;
        fpc.RotationSpeed= 0f;
        Cursor.visible = true;
        Cursor.lockState= CursorLockMode.None;
        GameIsPaused = true;
    }*/

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void GoToMenu()
    {
        Time.timeScale = 1f;
        fpc.RotationSpeed = currentMouseSensibility;
        SceneManager.LoadScene(0);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("MasterVolume", volume);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void setResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetMouseSensibility(float sensibility)
    {
        fpc.RotationSpeed= sensibility;
    }
}
