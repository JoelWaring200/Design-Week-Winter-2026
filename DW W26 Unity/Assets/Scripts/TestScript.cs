using UnityEngine;

public class TestScript : MonoBehaviour, IInteractable
{

    public bool isGone;
    public bool grabbed = false;
    GameObject target;
    GameObject interactionIcon;

    //SpriteRenderer sr;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    void Start()
    {
        interactionIcon.SetActive(false);
    } 

    // Update is called once per frame
    void Update()
    {
        
        if (grabbed)
        {
            GetComponent<SpriteRenderer>().sortingOrder = 2;
            Vector3 newPos = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);
            transform.position = newPos;
            
        }
        else if (!grabbed)
        {
            GetComponent<SpriteRenderer>().sortingOrder = 0;
            transform.position = transform.position;
            Debug.Log("Dropped");
        }

        //Replace this
        if (target == null)
        {
            if (GameObject.FindGameObjectWithTag("Player"))
            {
                target = GameObject.FindGameObjectWithTag("Player");
            } 
            else
            {
                return;
            }
        }
        

    }

     

    public bool CanInteract()
    {
        return !isGone;
    }

    public void Interact()
    {
        if(!CanInteract()) return;
        grabbed = !grabbed;
        
    }
}
