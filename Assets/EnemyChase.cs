using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    public float walkSpeed = 2f;
    private Vector3 startPosition;
    private Vector3 mainstartpos;
    private Quaternion mainrotate;
    public GameObject player;
    public GameObject enemy;
    bool isChasing = false;
    int counter = 0;
    public GameObject respawn;

    void Start()
    {
        mainstartpos = enemy.transform.position;
        mainrotate = enemy.transform.rotation;
        startPosition = enemy.transform.position;
        //Debug.Log(startPosition);
    }

    void Update()
    {
        if (player.transform.position.z > enemy.transform.position.z - 5f && counter == 0)
        {
            isChasing = true;
        }

        if (isChasing)
        {

            transform.Translate(Vector3.forward * walkSpeed * Time.deltaTime);

            if (enemy.transform.position.x < startPosition.x - 11.5f && counter == 0)
            {
                //Debug.Log("Second turn");
                transform.Rotate(Vector3.up, 270f);
                startPosition = enemy.transform.position;
                //Debug.Log(startPosition);
                counter = 1;
            }

            if (enemy.transform.position.z < startPosition.z - 48f && counter == 1)
            {
                //Debug.Log("Third turn");
                transform.Rotate(Vector3.up, 270f);
                startPosition = enemy.transform.position;
                counter = 2;
            }

            if (enemy.transform.position.x > startPosition.x + 20f && counter == 2)
            {
                //Debug.Log("Fourth turn");
                transform.Rotate(Vector3.up, 90f);
                counter = 3;
            }

            if (enemy.transform.position.z < startPosition.z - 9f && counter == 3)
            {
                walkSpeed = 0;
            }

        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the player has entered the trigger collider
        if (other.gameObject == player)
        {
            enemy.transform.position = mainstartpos;
            enemy.transform.rotation = mainrotate;
            startPosition = mainstartpos;
            counter = 0;
            isChasing = false;
            player.transform.position = respawn.transform.position;
        }
    }


}
