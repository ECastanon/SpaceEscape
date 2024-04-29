using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTriggerBox : MonoBehaviour
{
    public EnemyChase ec;
    private bool hitonce;

    void OnTriggerEnter(Collider other)
    {
        // Check if the player has entered the trigger collider
        if (other.gameObject.name.Contains("Player") && !hitonce)
        {
           // ec.isChasing = true;
            hitonce = true;
        }
    }

}
