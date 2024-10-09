using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSteering2D : MonoBehaviour
{
    Rigidbody2D rb;

    [SerializeField]
    float accelerationPower = 5f; // vitesse pour avancer
    [SerializeField]
    float steeringPower = 5f; // sensibilité du volant 
    float steeringAmount, direction;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
    }

    // Update is called once per frame
    void Update()
    {

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
