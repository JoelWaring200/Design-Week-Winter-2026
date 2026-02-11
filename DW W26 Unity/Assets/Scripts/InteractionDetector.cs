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
    //only when held
    public void OnInteract(InputAction.CallbackContext context)
    {
        //checks if action was made 
        if (context.performed)
        {
            if (interactableInRange != null)
            {
                interactableInRange.Interact();

                //should write in the debug log... does
                Debug.Log("Key Tracked");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (interactableInRange == null)
        {
            //checks if collison is an interactable object
            if(collision.TryGetComponent(out IInteractable interactable) && interactable.CanInteract())
            {
                interactableInRange = interactable;
                interactionIcon.SetActive(true);
            }
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
