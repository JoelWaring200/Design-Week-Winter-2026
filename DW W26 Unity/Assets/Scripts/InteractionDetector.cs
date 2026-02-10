using UnityEngine;
using UnityEngine.InputSystem;
public class InteractionDetector : MonoBehaviour
{
    private IInteractable interactableInRange = null;
    public GameObject interactionIcon;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        interactionIcon.SetActive(false);
    }

    //ask for help
    public void OnInteract(InputAction.CallbackContext context)
    {
        //checks if action was made 
        if (context.performed)
        {
            // ?                             .
            // is an interactable in range, if so Interact
            interactableInRange?.Interact();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //checks if collison is an interactable object
        if(collision.TryGetComponent(out IInteractable interactable) && interactable.CanInteract())
        {
            interactableInRange = interactable;
            interactionIcon.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        // checks if we leave the range of an interactable object
        if(collision.TryGetComponent(out IInteractable interactable) && interactable == interactableInRange)
        {
            interactableInRange = null;
            interactionIcon.SetActive(false);
        }
    }
}
