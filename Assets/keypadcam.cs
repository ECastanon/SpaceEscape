using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keypadcam : MonoBehaviour
{
    private bool isPlayerInsideCollider = false;
    int counter = 0;
    public GameObject Panel;
    public GameObject Player;
    public GameObject keypad;
    


    void Update()
    {
        // Check for the "E" key press only when the player is inside the collider
        if (isPlayerInsideCollider && Input.GetKeyDown(KeyCode.E) && counter == 1)
        {
            Debug.Log("E key pressed while in the collider");
            Player.SetActive(false);
            keypad.SetActive(true);
            counter = 2;
        }
        else if(isPlayerInsideCollider && Input.GetKeyDown(KeyCode.E) && counter == 2)
        {
            Debug.Log("E key pressed while in the collider");
            keypad.SetActive(false);
            Player.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            counter = 1;
            Panel.SetActive(true);
            Debug.Log("In the collider");
            isPlayerInsideCollider = true;
            Debug.Log("Keypad ON");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Exited the collider");
            isPlayerInsideCollider = false;
            Panel.SetActive(false);
            Debug.Log("keypad OFF");
        }
    }
}
