using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public int loudnessToGo;
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float targetRemainingTime;

    private float remainingTime;

    void Start()
    {
      remainingTime = targetRemainingTime;
    }

    // Update is called once per frame
    void Update()
    {
     if (remainingTime > 0)
     {
        remainingTime -= Time.deltaTime;
     }
     else if (remainingTime < 0)
     {
        remainingTime = targetRemainingTime;
        LoudnessToGo();
     }
     int minutes = Mathf.FloorToInt(remainingTime / 60);
     int seconds = Mathf.FloorToInt(remainingTime % 60);
     timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);   
    }

   public void LoudnessToGo()
   {
      loudnessToGo = Random.Range(0, 11);
   }
}
  