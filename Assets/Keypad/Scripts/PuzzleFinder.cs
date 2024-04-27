using System.Collections.Generic;
using UnityEngine;

public class PuzzleFinder : MonoBehaviour
{
    public Transform playerTransform; // Reference to the player's transform
    private GameObject heldObject;    // Currently held object
    public float holdDistance = 2.0f; // Distance to keep the held object in front of the player

    // List of tags that can be picked up
    private List<string> pickableTags = new List<string> { "One", "Two", "Three", "Four", "Five", "Six" };

    void Update()
    {
        // Update position of the held object to be in front of the player
        if (heldObject != null)
        {
            heldObject.transform.position = playerTransform.position + playerTransform.forward * holdDistance;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision Detected with: " + collision.gameObject.name); // Check any collision

        if (pickableTags.Contains(collision.gameObject.tag) && heldObject == null)
        {
            Debug.Log("Contact made with object tagged: " + collision.gameObject.tag); // Specific tag collision
            PickUpObject(collision.gameObject);
        }
    }


    private void PickUpObject(GameObject pickUp)
    {
        heldObject = pickUp;
        // Disable physics while the object is held
        if (heldObject.GetComponent<Rigidbody>())
        {
            heldObject.GetComponent<Rigidbody>().isKinematic = true;
        }
    }
}
