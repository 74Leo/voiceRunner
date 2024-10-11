using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Loudness : MonoBehaviour
{
    public CarSteering2D player;
    
    [SerializeField] Slider loudnessSlider;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         loudnessSlider.value = Mathf.Clamp01(player.loudness / 60f);
    }
}
