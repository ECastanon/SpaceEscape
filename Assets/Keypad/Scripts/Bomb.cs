using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float delay = 3f; // Delay in seconds before the bomb explodes
    private float countdown; // Timer to track the countdown
    private bool hasExploded = false; // Flag to check if the bomb has exploded

    // Start is called before the first frame update
    void Start()
    {
        countdown = delay;
    }

    // Update is called once per frame
    void Update()
    {
        // Reduce the countdown timer by the time passed since last frame
        countdown -= Time.deltaTime;

        // Check if the countdown is over and the bomb hasn't exploded yet
        if (countdown <= 0f && !hasExploded)
        {
            Explode();
            hasExploded = true;
        }
    }

    void Explode()
    {
        // Here you can put your explosion logic, such as playing an animation, sound, or instantiating explosion effects
        Debug.Log("Boom!"); // Log message for debugging

        // For example, you can destroy the bomb game object (or disable it if you prefer)
        Destroy(gameObject);
    }
}
