using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinEvent : MonoBehaviour
{
    public int playerLapsCompleted = 0;
    public int botLapsCompleted = 0;
    public int lapsToWin = 3;

    public GameObject playerVictoryPanel;
    public GameObject botVictoryPanel;

    bool visible = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerLapsCompleted++;
            Debug.Log("Le joueur a franchi la ligne de victoire : " + playerLapsCompleted + "/" + lapsToWin);

            if (playerLapsCompleted == lapsToWin)
            {
                ShowPanel(playerVictoryPanel);
                Debug.Log("Victoire ! Le joueur a gagné la course.");
                WinRace();
            }
        }
    }

    private void WinRace()
    {
        Debug.Log("Le joueur a remporté la course !");
    }
}
