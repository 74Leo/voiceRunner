using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    public GameObject Panel;
    bool visible = false;

    public Dropdown DResolution;

    public AudioSource audioSource;
    public Slider slider;
    public Text TxtVolume;

    private void Start()=> SliderChange();
    
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
    }
}


    public void SliderChange()
    {
        audioSource.volume = slider.value;
        TxtVolume.text = "Volume " + (audioSource.volume * 100).ToString("00") + "%";
    }
}