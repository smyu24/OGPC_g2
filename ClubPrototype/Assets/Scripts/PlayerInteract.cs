using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [Header("Interact Settings")]
    [SerializeField]private float interactDistance = 5;
    [SerializeField]private LayerMask layer;

    private bool interactable = false;

    private void Update()
    {
        if(interactable && Input.GetKeyDown(KeyCode.E))
        {
            DeployBot.instance.Return();
        }
    }

    private void FixedUpdate()
    {
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), interactDistance, layer))
        {
            // Enable button prompt here
            interactable = true;
        }
        else
        {
            interactable = false;
        }
    }
}
