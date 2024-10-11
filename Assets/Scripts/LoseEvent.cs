using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinEvent : MonoBehaviour
{
    public int lapsCompleted = 0;
    public int lapsToWin = 3;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bot"))
        {
            lapsCompleted++;
            Debug.Log("Passage sur la ligne de victoire : " + lapsCompleted + "/" + lapsToWin);

            if (lapsCompleted >= lapsToWin)
            {
                Debug.Log("Défaite ! Le Bot a gagné la course.");
                WinRace();
            }
        }
    }

    private void WinRace()
    {
        Debug.Log("Le Bot a remporté la course !");
    }
}