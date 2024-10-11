using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            }
        }

        if (other.gameObject.CompareTag("Bot"))
        {
            botLapsCompleted++;
            Debug.Log("Le bot a franchi la ligne de victoire : " + botLapsCompleted + "/" + lapsToWin);

            if (botLapsCompleted == lapsToWin)
            {
                ShowPanel(botVictoryPanel);
                Debug.Log("Défaite ! Le Bot a gagné la course.");
            }
        }
    }

    private void ShowPanel(GameObject panel)
    {
        panel.SetActive(true);
        Time.timeScale = 0f;
    }
}