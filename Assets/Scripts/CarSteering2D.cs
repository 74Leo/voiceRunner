using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSteering2D : MonoBehaviour
{
    public Timer timer;

    public float loudness;

    [SerializeField]
    Transform[] Points; // Points à suivre
    [SerializeField]
    private float moveSpeed = 5f; // Vitesse de déplacement
    private int pointsIndex = 0; // Index du point actuel

    public AudioSource source;
    public AudioLoudnessDetection detector;

    public float loudnessSensibility = 100;
    public float threshold = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = Points[pointsIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        loudness = detector.GetLoudnessFromMicrophone() * loudnessSensibility;
        int loudnessToGo = timer.loudnessToGo;

        Debug.Log("Loudness: " + loudness);

        float goal = loudnessToGo - loudness;

        float absGoal = Mathf.Abs(goal);

        if (absGoal <= 2)
        {
            moveSpeed = 10f;
        }
        else if (absGoal <= 5)
        {
            moveSpeed = 5f;
        }
        else
        {
            moveSpeed = 2f;
        }

        if (loudness < threshold)
            loudness = 0;



        if (pointsIndex <= Points.Length - 1)
        {

            transform.up = (Points[pointsIndex].position - transform.position).normalized;

            transform.position = Vector2.MoveTowards(transform.position, Points[pointsIndex].transform.position, moveSpeed * Time.deltaTime);  // Déplacer la voiture vers le prochain point


            if (Vector2.Distance(transform.position, Points[pointsIndex].transform.position) < 0.25f)   // Passer au point suivant si on atteint le point actuel
            {
                pointsIndex += 1;
            }

            if (pointsIndex == Points.Length)
            {
                pointsIndex = 0;
            }
        }
    }
}
