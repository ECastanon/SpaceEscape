using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjTrigger : MonoBehaviour
{
    public bool printDebugInfo = true;
    bool hitOnce = false;
    bool pickup = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // This function is called when another collider hits this object's collider
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Power")  && !hitOnce)
        {
            string myname = gameObject.name;
            if (printDebugInfo)
                Debug.Log("generator connected");

            //your code here. Let the object do something when it is hit by the player
            other.transform.parent=null;
            other.transform.parent=transform;
            other.transform.position= new Vector3(transform.position.x,transform.position.y+2,transform.position.z-.5f);
            hitOnce = true;
            pickup= true;
        }
    }
}
