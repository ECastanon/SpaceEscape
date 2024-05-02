using UnityEngine;

public class TriggerArt : MonoBehaviour
{
    public GameObject sphereCenter;
    private GameObject positionedObject;
    public GameObject Correct;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Sphere") && positionedObject == null && other.gameObject == Correct)
        {
            PositionObject(other.gameObject);
            Debug.Log("Correct");

        }
        else if (other.CompareTag("Sphere") && positionedObject == null)
        {
            PositionObject(other.gameObject);
            Debug.Log("Incorrect");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Sphere") && other.gameObject == positionedObject)
        {
            ResetPosition();
            Debug.Log("Exit");
        }
    }

    void PositionObject(GameObject obj)
    {
        obj.transform.position = sphereCenter.transform.position;
        positionedObject = obj;
    }

    void ResetPosition()
    {

        if (positionedObject != null)
        {

            positionedObject = null;
        }
    }


}