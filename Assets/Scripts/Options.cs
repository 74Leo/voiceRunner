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

    private void Start() => SliderChange();
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            visible = !visible;
            Panel.SetActive(visible);
        }
    }

    public void SetResolution()
    {
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
        switch (DQuality.value)
        {
            case 0:
                QualitySettings.SetQualityLevel(DQuality.value);
                break;
            case 1:
                QualitySettings.SetQualityLevel(DQuality.value);
                break;
            case 2:
                QualitySettings.SetQualityLevel(DQuality.value);
                break;
        }
    }

    public void SetFPSLimit()
    {
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
    }
}