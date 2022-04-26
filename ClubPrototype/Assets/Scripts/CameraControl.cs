/* Script Based off of Brackey's FPS Controller Camera Script
 * Link to video: https://www.youtube.com/watch?v=_QajrabyTJc
 */

using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Transform playerBody;
    [Header("Camera Settings")]
    [SerializeField] private float mouseSens;

    private float mouseX;
    private float mouseY;
    private float xRotation;
    private float yRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        mouseX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
