using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float delay = 3f; // Delay in seconds before the bomb explodes after being triggered
    private float countdown; // Timer to track the countdown
    private bool hasExploded = false; // Flag to check if the bomb has exploded
    public float radius = 5f; // Explosion radius
    public float power = 10f; // Explosion power

    void Start()
    {
        countdown = delay;
    }

    void Update()
    {
        if (hasExploded)
        {
            // Reduce the countdown timer only after the bomb has been triggered to explode
            countdown -= Time.deltaTime;

            // Check if the countdown is over
            if (countdown <= 0f)
            {
                Explode();
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Check for trigger with an object tagged "HitBox"
        if (other.CompareTag("HitBox") && !hasExploded)
        {
            hasExploded = true; // Set the bomb to explode, countdown starts
        }
    }

    void Explode()
    {
        Debug.Log("Boom!"); // Log explosion for debugging

        // Make the collider a trigger to ensure it does not physically interact while exploding
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(power, transform.position, radius);
            }
        }

        // Optionally, instantiate explosion effects or sounds here

        Destroy(gameObject); // Destroy the bomb object to simulate that it has exploded
    }
}
