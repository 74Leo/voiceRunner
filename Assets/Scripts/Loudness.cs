using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Loudness : MonoBehaviour
{
    public CarSteering2D player;
    
    [SerializeField] Slider loudnessSlider;

    [SerializeField] float smoothSpeed = 0.5f; 


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       float targetValue = Mathf.Clamp01(player.loudness / 60f);
        
        loudnessSlider.value = Mathf.Lerp(loudnessSlider.value, targetValue, smoothSpeed);
    }
}
