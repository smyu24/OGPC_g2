/* Script Based off of Plai's FPS Controller Movement Script
 * Link to video: https://www.youtube.com/watch?v=LqnPeqoJRFY
 */

using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float playerHeight = 2f;

    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 6f;
    [SerializeField] private float jumpHeight = 5f;
    [Header("Components")]
    [SerializeField] private Rigidbody rigidb;

    private float horizontalMovement;
    private float verticalMovement;

    private float groundDrag = 6f;
    private float airDrag = 2f;

    private bool touchGround;

    Vector3 moveDirection;

    private void Update()
    {
        touchGround = Physics.Raycast(transform.position, Vector3.down, playerHeight / 2f + 0.1f);

        MoveInput();
        ControlDrag();

        if (Input.GetKeyDown(KeyCode.Space) && touchGround)
        {
            Jump();
        }
    }

    private void MoveInput()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        verticalMovement = Input.GetAxisRaw("Vertical");

        moveDirection = transform.forward * verticalMovement + transform.right * horizontalMovement;
    }

    private void Jump()
    {
        rigidb.AddForce(transform.up * jumpHeight, ForceMode.Impulse);
    }

    private void ControlDrag()
    {
        if(touchGround)
        {
            rigidb.drag = groundDrag;
        }
        else
        {
            rigidb.drag = airDrag;
        }
    }

    private void FixedUpdate()
    {
        if(touchGround)
        {
            rigidb.AddForce(moveDirection.normalized * moveSpeed * 10, ForceMode.Acceleration);
        }
        else if(!touchGround)
        {
            rigidb.AddForce(moveDirection.normalized * moveSpeed * 10 * 0.4f, ForceMode.Acceleration);
        }
    }
}
