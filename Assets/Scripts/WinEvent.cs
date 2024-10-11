using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinEvent : MonoBehaviour
{
    public int lapsCompleted = 0;
    public int lapsToWin = 3;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            lapsCompleted++;
            Debug.Log("Passage sur la ligne de victoire : " + lapsCompleted + "/" + lapsToWin);

            if (lapsCompleted >= lapsToWin)
            {
                Debug.Log("Victoire ! Le joueur a gagné la course.");
                WinRace();
            }
        }
    }

    private void WinRace()
    {
        Debug.Log("Le joueur a remporté la course !");
        SceneManager.LoadScene(Victoire);
    }
}
