using UnityEngine;

public class MovingScript : MonoBehaviour
{
    public float speed = 5.0f;
    public float rotateSpeed = 1f;

    void Update()
    {
        // Movement
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.forward * vertical * speed * Time.deltaTime);
        transform.Rotate(Vector3.up * horizontal * rotateSpeed * Time.deltaTime * 5);

        // Mouse look
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        transform.Rotate(Vector3.up * mouseX * rotateSpeed * Time.deltaTime * 5);

        // Limiting vertical rotation to prevent flipping
        float currentRotationX = transform.rotation.eulerAngles.x;
        float newRotationX = currentRotationX - mouseY * rotateSpeed * Time.deltaTime * 5;
        newRotationX = Mathf.Clamp(newRotationX, 0f, 90f);

        transform.rotation = Quaternion.Euler(newRotationX, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
    }
}

