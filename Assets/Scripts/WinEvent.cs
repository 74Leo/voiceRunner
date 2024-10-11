using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinEvent : MonoBehaviour
{
    public int playerLapsCompleted = 0;
    public int botLapsCompleted = 0;
    public int lapsToWin = 2;
    public int lapsToWinBot = 6;
    

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
            Debug.Log("Le bot a franchi la ligne de victoire : " + botLapsCompleted + "/" + lapsToWinBot);

            if (botLapsCompleted == lapsToWinBot)
            {
                ShowPanel(botVictoryPanel);
                Debug.Log("Défaite ! Le Bot a gagné la course.");
            }
        }
    }

    private void ShowPanel(GameObject panel)
    {
        visible = !visible;
        panel.SetActive(visible);
        Time.timeScale = 0f;
    }
}