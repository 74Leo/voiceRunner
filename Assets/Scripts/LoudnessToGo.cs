using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LoudnessToGo : MonoBehaviour
{
    public Timer goalLoudness;
    [SerializeField] Slider loudnessToGoSlider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        loudnessToGoSlider.value = Mathf.Clamp01(goalLoudness.loudnessToGo / 60f);
    }
}
