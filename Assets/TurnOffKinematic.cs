using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffKinematic : MonoBehaviour
{
    public Rigidbody rb;
    public Vector3 pos;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        pos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    private void Update()
    {
        if(pos != new Vector3(transform.position.x, transform.position.y, transform.position.z))
        {
            TurnOffKim();
        }
    }
    private void TurnOffKim()
    {
        rb.isKinematic = false;
    }
}
