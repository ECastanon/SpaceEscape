using UnityEngine;

public class Plant : MonoBehaviour
{
    private bool isPlayerInsideCollider = false;
    int counter = 0;
    public GameObject Panel;

    void Update()
    {
        // Check for the "E" key press only when the player is inside the collider
        if (isPlayerInsideCollider && Input.GetKeyDown(KeyCode.E) && counter==0)
        {
            Debug.Log("E key pressed while in the collider");
            // Perform your desired action here
            transform.Translate(Vector3.forward * 1);
            counter += 1;
            Panel.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(counter == 0)
            {
                 Panel.SetActive(true);
                 Debug.Log("PLANT ON");
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
            Debug.Log("Plant OFF");
        }
    }
    
}
