using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Loudness : MonoBehaviour
{
    public CarSteering2D player;
    
    [SerializeField] TextMeshProUGUI loudnessText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         loudnessText.text = player.loudness.ToString("F0");
    }
}
