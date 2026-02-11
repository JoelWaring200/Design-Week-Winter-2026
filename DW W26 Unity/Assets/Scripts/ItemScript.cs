using UnityEngine;

public class TestScript : MonoBehaviour, IInteractable
{

    public bool isGone;
    public bool grabbed = false;
    /*
    fix the way player is tracked
    PlayerController playerController;
    */
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
        //if (playerController.hasItem == false)
        {
            if (grabbed)
            {
                GetComponent<SpriteRenderer>().sortingOrder = 2;
                Vector3 newPos = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);
                transform.position = newPos; 
            }
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
        /*
        fix the way the player is tracked
        if (target != null && assigning )
        {
            playerController = target.GetComponent<PlayerController>(); 
        }
        */
    }

     

    public bool CanInteract()
    {
        return !isGone;
    }

    public void Interact()
    {
        if(!CanInteract()) return;
        grabbed = !grabbed;
        /*
        fix the way the player is tracked
        playerController.hasItem = !playerController.hasItem;
        */
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!grabbed)
        {
            //dropoffs
            if (collision.gameObject.name == "DropOffLeft")
            {
                Vector3 newPos = new Vector3(-12, transform.position.y, transform.position.z);
                
                transform.position = newPos; 
                Debug.Log("dropoff zone");
            }
            if (collision.gameObject.name == "DropOffRight")
            {
                Vector3 newPos = new Vector3(12, transform.position.y, transform.position.z);
                
                transform.position = newPos; 
                Debug.Log("dropoff zone");
            }
            //conveyor belts
            if (collision.gameObject.name == "ConveyorUp")
            {
                float speed = 2f;
                transform.position += Vector3.up * speed * Time.deltaTime;
                Debug.Log("on conveyor");
            }
            if (collision.gameObject.name == "ConveyorLeft")
            {
                float speed = 2f;
                transform.position += Vector3.left * speed * Time.deltaTime;
                Debug.Log("on conveyor");
            }
            if (collision.gameObject.name == "ConveyorDown")
            {
                float speed = 2f;
                transform.position += Vector3.down * speed * Time.deltaTime;
                Debug.Log("on conveyor");
            }
            if (collision.gameObject.name == "ConveyorRight")
            {
                float speed = 2f;
                transform.position += Vector3.right * speed * Time.deltaTime;
                Debug.Log("on conveyor");
            }
        }
    }
    
}
