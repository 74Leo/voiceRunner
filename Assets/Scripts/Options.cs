using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    public GameObject Panel;
    bool visible = false;

    public Dropdown DResolution;
    public Dropdown DQuality;
    public Dropdown DFPSLimit;

    public AudioSource audioSource;
    public Slider slider;
    public Text TxtVolume;

    public Text GPUInfo;

    private void Start() 
    {
        PlayMusic();
        SliderChange();
        DisplayGPUInfo();
    }
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            visible = !visible;
            Panel.SetActive(visible);
            Debug.Log("Panel de l'options est maintenant " + (visible ? "visible" : "caché"));
        }
    }

    private void PlayMusic()
    {
        audioSource.loop = true;
        audioSource.Play();
    }

    public void SetResolution()
    {
        Debug.Log("Changement de résolution à l'index : " + DResolution.value);
        switch (DResolution.value)
        {
            case 0:
                Screen.SetResolution(640, 360, true);
                break;
            case 1:
                Screen.SetResolution(1024, 768, true);
                break;
            case 2:
                Screen.SetResolution(1280, 800, true);
                break;
            case 3:
                Screen.SetResolution(1280, 1024, true);
                break;
            case 4:
                Screen.SetResolution(1600, 1200, true);
                break;
            case 5:
                Screen.SetResolution(1680, 1050, true);
                break;
            case 6:
                Screen.SetResolution(1920, 1080, true);
                break;
            case 7:
                Screen.SetResolution(1920, 1200, true);
                break;
            case 8:
                Screen.SetResolution(2560, 1600, true);
                break;
            case 9:
                Screen.SetResolution(2560, 1440, true);
                break;
            case 10:
                Screen.SetResolution(3440, 1440, true);
                break;
            case 11:
                Screen.SetResolution(3840, 2160, true);
                break;
            case 12:
                Screen.SetResolution(5120, 2880, true);
                break;
            case 13:
                Screen.SetResolution(7680, 4320, true);
                break;
        }
    }

    public void SetQuality()
    {
        QualitySettings.SetQualityLevel(DQuality.value);
        Debug.Log("Changement de qualité à l'index : " + DQuality.value);
    }

    public void SetFPSLimit()
    {
        Debug.Log("Changement de limite de FPS à l'index : " + DFPSLimit.value);
        switch (DFPSLimit.value)
        {
            case 0:
                Application.targetFrameRate = 30;
                break;
            case 1:
                Application.targetFrameRate = 60;
                break;
            case 2:
                Application.targetFrameRate = 90;
                break;
            case 3:
                Application.targetFrameRate = 120;
                break;
            case 4:
                Application.targetFrameRate = 144;
                break;
            case 5:
                Application.targetFrameRate = 165;
                break;
            case 6:
                Application.targetFrameRate = 240;
                break;
            case 7:
                Application.targetFrameRate = 360;
                break;
            case 8:
                Application.targetFrameRate = -1;
                break;
        }
    }

    public void SliderChange()
    {
        audioSource.volume = slider.value;
        TxtVolume.text = "Volume " + (audioSource.volume * 100).ToString("00") + "%";
        Debug.Log("Volume ajusté à : " + (audioSource.volume * 100).ToString("00") + "%");
    }

    private void DisplayGPUInfo()
    {
        GPUInfo.text += "Carte graphique : " + SystemInfo.graphicsDeviceName + "\n";
        GPUInfo.text += "Fabricant GPU : " + SystemInfo.graphicsDeviceVendor + "\n";
        GPUInfo.text += "API Graphique : " + SystemInfo.graphicsDeviceVersion + "\n";
        GPUInfo.text += "VRAM disponible : " + SystemInfo.graphicsMemorySize + " Mo\n";
        GPUInfo.text += "Résolution actuelle : " + Screen.currentResolution.width + " x " + Screen.currentResolution.height + " @ " + Screen.currentResolution.refreshRate + "Hz\n";
        GPUInfo.text += "Processeur : " + SystemInfo.processorType + "\n";
        GPUInfo.text += "Cœurs logiques : " + SystemInfo.processorCount + "\n";
        GPUInfo.text += "RAM Système : " + SystemInfo.systemMemorySize + " Mo\n";
        GPUInfo.text += "Système d'exploitation : " + SystemInfo.operatingSystem + "\n";
        Debug.Log("Informations sur le GPU affichées.");
    }
}