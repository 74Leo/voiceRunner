using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSteering2D : MonoBehaviour
{

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
        float loudness = detector.GetLoudnessFromMicrophone() * loudnessSensibility;

        Debug.Log("Loudness: " + loudness);

        goal = loudness - loudnessToGo;

        absgoal = Mathf.Abs(goal);

        if (2> loudness > 5)
        {
            moveSpeed = 10f;
        }
        if (loudness > 10)
        {
            moveSpeed = 15f;
        }
        if (loudness > 15)
        {
            moveSpeed = 20f;
        }
        if (loudness > 20)
        {
            moveSpeed = 25f;
        }
        else
        {
            moveSpeed = 5f;
        }

        if (loudness < threshold)
            loudness = 0;



        if (pointsIndex <= Points.Length - 1)
        {

            transform.position = Vector2.MoveTowards(transform.position, Points[pointsIndex].transform.position, moveSpeed * Time.deltaTime);  // Déplacer la voiture vers le prochain point


            if (transform.position == Points[pointsIndex].transform.position)   // Passer au point suivant si on atteint le point actuel
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
