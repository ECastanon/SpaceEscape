using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror : MonoBehaviour
{

    public GameObject mirrored;
    public float Z_offset;
    public float X_offset;
    bool stop = false;
    public bool printDebugInfo = true;
    bool hitOnce = false;
    // Start is called before the first frame update
    void Start()
    {
        transform.position= new Vector3(mirrored.transform.position.x,mirrored.transform.position.y,mirrored.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.parent.name.Contains("ObjTrigger"))
        {
            stop= true;
        }
        if (stop==false)
        {
            transform.position= new Vector3(mirrored.transform.position.x + X_offset,mirrored.transform.position.y,mirrored.transform.position.z+Z_offset);
        }
    }
}
