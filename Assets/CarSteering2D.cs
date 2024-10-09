using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSteering2D : MonoBehaviour
{
    Rigidbody2D rb;

    [SerializeField]
    float accelerationPower = 5f; // vitesse pour avancer
    [SerializeField]
    float steeringPower = 0.5f; // sensibilité du volant 
    float steeringAmount, direction;

    public AudioSource source;
    public Vector3 minScale;
    public Vector3 maxScale;
    public AudioLoudnessDetection detector;

    public float loudnessSensibility = 100;
    public float threshold = 5f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        float loudness = detector.GetLoudnessFromMicrophone() * loudnessSensibility;

        // Utilisation du switch pour gérer les différents niveaux de loudness
        switch (loudness)
        {
            case > 20:
                accelerationPower = 25f;
                break;
            case > 15:
                accelerationPower = 20f;
                break;
            case > 10:
                accelerationPower = 15f;
                break;
            case > 5:
                accelerationPower = 10f;
                break;
            default:
                accelerationPower = 5f;
                break;
        }

        if (loudness < threshold)
            loudness = 0;

        transform.localScale = Vector3.Lerp(minScale, maxScale, loudness);
    }

    void FixedUpdate()
    {
        steeringAmount = -Input.GetAxis("Horizontal"); // Cette ligne permet a l'utilisateur de pouvoir tourner le volant 
        direction = Mathf.Sign(Vector2.Dot(rb.velocity, rb.GetRelativeVector(Vector2.up)));

        rb.rotation += steeringAmount * steeringPower * rb.velocity.magnitude * direction;

        rb.AddForce(transform.up * accelerationPower); // avancer en automatique

        rb.AddRelativeForce(-Vector2.right * rb.velocity.magnitude * steeringAmount / 2); // pour déraper un +
    }
}
