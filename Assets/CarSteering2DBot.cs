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


    // Start is called before the first frame update
    void Start()
    {
        transform.position = Points[pointsIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
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
