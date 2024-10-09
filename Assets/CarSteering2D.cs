using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSteering2D : MonoBehaviour
{

    [SerializeField]
    Transform[] Points; // Points à suivre
    [SerializeField]
    private float moveSpeed = 0.2f; // Vitesse de déplacement
    private int pointsIndex = 0; // Index du point actuel

    public AudioSource source;
    public Vector3 minScale;
    public Vector3 maxScale;
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

        if (loudness > 5)
        {
            accelerationPower = 10f;
        }
        if (loudness > 10)
        {
            accelerationPower = 15f;
        }
        if (loudness > 15)
        {
            accelerationPower = 20f;
        }
        if (loudness > 20)
        {
            accelerationPower = 25f;
        }
        else
        {
            accelerationPower = 5f;
        }

        if (loudness < threshold)
            loudness = 0;


        // transform.localScale = Vector3.Lerp(minScale, maxScale, loudness);        if (pointsIndex <= Points.Length - 1)
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
