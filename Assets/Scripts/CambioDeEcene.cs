using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CambioDeEcene : MonoBehaviour {

    public GameObject playerSelectionHolder;
    public GameObject mainMenuHolder;
    public GameObject optionsMenuHolder;
    public Slider[] volumeSliders;
    public Toggle[] resolutionToggles;
    public Toggle fullscreenToggle;
    public int[] screenWidths;
    int activeScreenResIndex;

   void Start()
    {
        activeScreenResIndex = PlayerPrefs.GetInt("screen res index");
        bool isFullscreen = (PlayerPrefs.GetInt("fullscreen") == 1) ? true : false;

        volumeSliders[0].value = AudioManager.instance.masterVolumePercent;
        volumeSliders[1].value = AudioManager.instance.musicVolumePercent;
        volumeSliders[2].value = AudioManager.instance.sfxVolumePrecent;

        for(int i = 0; i<resolutionToggles.Length; i++)
        {
            resolutionToggles[1].isOn = i == activeScreenResIndex;
        }

        fullscreenToggle.isOn = isFullscreen;
    }

    public void Play ()
    {
        AudioManager.instance.PlaySound2D("Play");
        SceneManager.LoadScene("Pista_Halloween");
    }

    public void Salir()
    {
        Application.Quit();
    }

    public void ScreenMainMenu()
    {
        AudioManager.instance.PlaySound2D("Retroceder_Menu");
        mainMenuHolder.SetActive(true);
        playerSelectionHolder.SetActive(false);
        optionsMenuHolder.SetActive(false);
    }

    public void ScreenPlayerSelection()
    {
        AudioManager.instance.PlaySound2D("Avanzar_Menu");
        mainMenuHolder.SetActive(false);
        playerSelectionHolder.SetActive(true);
        optionsMenuHolder.SetActive(false);
    }

    public void ScreenSettings()
    {
        AudioManager.instance.PlaySound2D("Boton_Opciones");
        optionsMenuHolder.SetActive(true);
    }

    public void CloseScreenSettings()
    {
        AudioManager.instance.PlaySound2D("Boton_Opciones");
        optionsMenuHolder.SetActive(false);
    }

    public void SetScreenResolution (int i)
    {
        if (resolutionToggles[i].isOn)
        {
            activeScreenResIndex = i;
            float aspectRatio = 16 / 9f;
            Screen.SetResolution(screenWidths[i], (int)(screenWidths[i] / aspectRatio), false);
            PlayerPrefs.SetInt("screen res index", activeScreenResIndex);
            PlayerPrefs.Save();
        }
    }

    public void SetFullscreen(bool isFullscreen)
    {
        for(int i=0 ; i < resolutionToggles.Length ; i++)
        {
            resolutionToggles [i].interactable = !isFullscreen;
        }

        if (isFullscreen)
        {
            Resolution[] allResolutions = Screen.resolutions;
            Resolution maxResolutions = allResolutions[allResolutions.Length - 1];
            Screen.SetResolution(maxResolutions.width, maxResolutions.height, true);
        }
        else
        {
            SetScreenResolution(activeScreenResIndex);
        }
        PlayerPrefs.SetInt("fullscreen", ((isFullscreen) ? 1 : 0));
        PlayerPrefs.Save();
    }

    public void SetMasterVolume (float value)
    {
        AudioManager.instance.SetVolume(value, AudioManager.AudioChannel.Master);
    }

    public void SetMusicVolume(float value)
    {
        AudioManager.instance.SetVolume(value, AudioManager.AudioChannel.Music);
    }

    public void SetSfxVolume(float value)
    {
        AudioManager.instance.SetVolume(value, AudioManager.AudioChannel.Sfx);
    }
}
