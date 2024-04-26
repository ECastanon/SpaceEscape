using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private float turnSpeed = 50f;
    [SerializeField] private float mouseSensitivity = 2f;

    //private Animator animator;

    private float rotationX = 0f;

    // Start is called before the first frame update
    void Start()
    {
        //animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Player Movement
        var forwardInput = Input.GetAxis("Vertical");
        var horizontalInput = Input.GetAxis("Horizontal");

        var velocity = Vector3.forward * forwardInput * speed;
        transform.Translate(velocity * Time.deltaTime);
        transform.Rotate(Vector3.up, horizontalInput * Time.deltaTime * turnSpeed);
        //animator.SetFloat("Speed", velocity.z);

        // Mouse Look
        var mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        var mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // Rotate the player horizontally based on mouse movement
        transform.Rotate(Vector3.up, mouseX * Time.deltaTime * turnSpeed);

        // Rotate the camera vertically based on mouse movement
        rotationX -= mouseY * mouseSensitivity * turnSpeed * Time.deltaTime;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);

        if (Camera.main != null)
        {
            Camera.main.transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);
        }
    }
}
