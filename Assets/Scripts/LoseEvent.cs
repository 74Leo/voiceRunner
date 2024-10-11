using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseEvent : MonoBehaviour
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
                LoseRace();
            }
        }
    }

    private void LoseRace()
    {
        Debug.Log("Le Bot a remporté la course !");
        SceneManager.LoadScene(Defaite);
    }
}