using UnityEngine;

public class TestScript : MonoBehaviour, IInteractable
{

    public bool isGone;
    bool grabbed = false;
    Transform target;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnPlayerJoined()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (grabbed)
        {
            Debug.Log("Interacted!!!");

            Vector3 newPos = new Vector3(target.position.x, target.position.y, transform.position.z);
            transform.position = newPos;
        }
    }

    public bool CanInteract()
    {
        return !isGone;
    }

    public void Interact()
    {
        if(!CanInteract()) return;
        grabbed = true;
        //HoldObject();
    }
    public void HoldObject()
    {
        Debug.Log("Interacted!!!");

        Vector3 newPos = new Vector3(target.position.x, target.position.y, transform.position.z);
        transform.position = newPos;
    }
}
