using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{  

    
    public bool printDebugInfo = true;
    bool hitOnce = false;
    bool pickup = false;


    

    // Start is called before the first frame update
    void Start()
    {

    }
   void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Player" && !hitOnce)
        {
            string myname = gameObject.name;
            if (printDebugInfo)
                Debug.Log("Player Picks up ball");

            //your code here. Let the object do something when it is hit by the player
            transform.parent=other.transform;
            hitOnce = true;
            pickup= true;
        }
    }

    // Update is called once per frame
  void Update()
    {
     /*if(pickup== true)
     {
        transform.position= new Vector3(player.transform.position.x+1.5f,player.transform.position.y,player.transform.position.z);
     }*/
    }
}
