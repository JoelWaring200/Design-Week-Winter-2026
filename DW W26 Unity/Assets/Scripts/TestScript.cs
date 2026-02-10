using UnityEngine;

public class TestScript : MonoBehaviour, IInteractable
{

    public bool isGone;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool CanInteract()
    {
        return !isGone;
    }

    public void Interact()
    {
        if(!CanInteract()) return;
    }
}
