using UnityEngine;

public class TestScript : MonoBehaviour, IInteractable
{

<<<<<<< Updated upstream
    public bool isGone;
    public bool grabbed = false;
    /*
    fix the way player is tracked
    PlayerController playerController;
    */
    GameObject target;
    GameObject interactionIcon;
=======
    //public bool grabbed = false;
    float speed = 2f;
    private PlayerSpawn playerSpawnRef;
    private GameObject holder = null;
>>>>>>> Stashed changes

    //SpriteRenderer sr;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    void Start()
    {
<<<<<<< Updated upstream
        interactionIcon.SetActive(false);
=======
        playerSpawnRef = GameObject.Find("Player Input Manager").GetComponent<PlayerSpawn>();
>>>>>>> Stashed changes
    } 

    // Update is called once per frame
    void Update()
    {
<<<<<<< Updated upstream
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
=======
        if (holder != null)
        {
            GetComponent<SpriteRenderer>().sortingOrder = 2;

            transform.position = holder.transform.position;
        }
        else
        {
            GetComponent<SpriteRenderer>().sortingOrder = 0;
>>>>>>> Stashed changes
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
        return holder == null;
    }
<<<<<<< Updated upstream

    public void Interact()
    {
        if(!CanInteract()) return;
        grabbed = !grabbed;
        /*
        fix the way the player is tracked
        playerController.hasItem = !playerController.hasItem;
        */
=======
    public void Interact(GameObject interactor)
    {
        if (holder == null)
        {
            holder = interactor;
        }
        else if (holder == interactor)
        {
            holder = null;
        }
>>>>>>> Stashed changes
    }
    //2 -6
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (holder == null)
        {
            //dropoffs
            if (collision.gameObject.name == "DropOffLeft")
            {
                Vector3 newPos = new Vector3(-12, transform.position.y, transform.position.z);
                
                transform.position = newPos; 
                
            }
            if (collision.gameObject.name == "DropOffRight")
            {
                Vector3 newPos = new Vector3(14, transform.position.y, transform.position.z);
                
                transform.position = newPos; 
                
            }
            //conveyor pos fixes
            if (collision.gameObject.name == "ConveyorFixTop")
            {
                Vector3 newPos = new Vector3(transform.position.x, 2, transform.position.z);
                transform.position = newPos;
            }
            if (collision.gameObject.name == "ConveyorFixBottom")
            {
                Vector3 newPos = new Vector3(transform.position.x, -6, transform.position.z);
                transform.position = newPos;
            }
            //conveyor belts
            if (collision.gameObject.name == "ConveyorUp")
            {
                float speed = 2f;
                transform.position += Vector3.up * speed * Time.deltaTime;
            }
            if (collision.gameObject.name == "ConveyorLeft")
            {
                float speed = 2f;
                transform.position += Vector3.left * speed * Time.deltaTime;

            }
            if (collision.gameObject.name == "ConveyorDown")
            {
                float speed = 2f;
                transform.position += Vector3.down * speed * Time.deltaTime;

            }
            if (collision.gameObject.name == "ConveyorRight")
            {
                float speed = 2f;
                transform.position += Vector3.right * speed * Time.deltaTime;

            }
        }
    }
    
}
