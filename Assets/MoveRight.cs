using UnityEngine;

public class Painting : MonoBehaviour
{
    private bool isPlayerInsideCollider = false;
    int counter = 0;
    public GameObject Panel;


    void Update()
    {
        // Check for the "E" key press only when the player is inside the collider
        if (isPlayerInsideCollider && Input.GetKeyDown(KeyCode.E) && counter == 0)
        {
            Debug.Log("E key pressed while in the collider");
            // Perform your desired action here
            transform.Translate(Vector3.down * 1.8f);
            transform.Rotate(-20f,0f,0f,Space.Self);
            transform.Translate(Vector3.forward * 0.17f);
            counter += 1;
            Panel.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (counter == 0)
            {
                Panel.SetActive(true);
            }

            Debug.Log("In the collider");
            isPlayerInsideCollider = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Exited the collider");
            isPlayerInsideCollider = false;
            Panel.SetActive(false);
        }
    }

}
