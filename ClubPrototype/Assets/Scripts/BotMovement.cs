using UnityEngine;

public class BotMovement : MonoBehaviour
{
    // This script is actually made of dark matter and will complete break if you change the order of anything
    
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 6f;
    [SerializeField] private float lerp = 0.025f;

    private float horizontalMovement;
    private float verticalMovement;

    Vector3 moveDirection;

    private void Update()
    {
        MoveInput();
    }

    private void MoveInput()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        verticalMovement = Input.GetAxisRaw("Vertical");

        moveDirection = transform.forward * verticalMovement + transform.right * horizontalMovement;
    }

    private void FixedUpdate()
    {
        transform.position += Vector3.Lerp(moveDirection.normalized, moveDirection.normalized * moveSpeed, lerp) * 0.1f;
    }
}
