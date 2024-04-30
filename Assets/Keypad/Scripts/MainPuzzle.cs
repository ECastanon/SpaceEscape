using UnityEngine;

public class ObjectOrderManager : MonoBehaviour
{
    public GameObject[] orderedObjects; // Assign in inspector, objects one to six in correct order
    public GameObject bombObject; // Assign bomb object in inspector

    private bool CheckOrder()
    {
        // Assuming each object has a script with a bool 'isInCorrectPlace'
        for (int i = 0; i < orderedObjects.Length; i++)
        {
            if (!orderedObjects[i].GetComponent<ObjectPlacement>().isInCorrectPlace)
                return false;
        }
        return true;
    }

    private void Update()
    {
        if (CheckOrder())
        {
            TriggerBomb();
        }
    }

    void TriggerBomb()
    {
        // Logic to trigger the bomb
        bombObject.SetActive(true);
        Debug.Log("Bomb activated!");
    }
}

// You might need a simple script on each draggable object to check if it is in the correct place
public class ObjectPlacement : MonoBehaviour
{
    public bool isInCorrectPlace;

    private void OnTriggerEnter(Collider other)
    {
        // Check if it's the correct zone (perhaps each zone is also tagged or has a unique identifier)
        isInCorrectPlace = true;
    }

    private void OnTriggerExit(Collider other)
    {
        isInCorrectPlace = false;
    }
}

