using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AnimateVictoryCounts : MonoBehaviour
{
    public Text roundsText;

    void OnEnable()
    {
        if (roundsText == null) return;
        StartCoroutine(AnimatedTextt());
    }

    IEnumerator AnimatedTextt()
    {
        roundsText.text = "0";
        int round = 0;

        yield return new WaitForSeconds(0.7f);

        while (round < 2)
        {
            round++;
            roundsText.text = round.ToString();
            yield return new WaitForSeconds(0.05f);
        }
    }
}
