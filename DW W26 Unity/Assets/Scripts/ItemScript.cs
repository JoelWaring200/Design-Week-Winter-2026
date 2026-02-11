using UnityEngine;

public class ItemScript : MonoBehaviour, IInteractable
{

    public bool isGone;
    public bool grabbed = false;
    float speed = 2f;
    private PlayerSpawn playerSpawnRef;

    public bool foundPlayer = false;
    GameObject target;
    GameObject interactionIcon;
    public GameObject[] Players;

    //SpriteRenderer sr;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //interactionIcon.SetActive(false);
        playerSpawnRef = GameObject.Find("Player Input Manager").GetComponent<PlayerSpawn>();
    } 
    // Update is called once per frame
    void Update()
    {

        if (playerSpawnRef.PlayerCount == 2)
        {
            foundPlayer = true;
        }
        //comment out
        if (playerSpawnRef.PlayerCount > 0 && !foundPlayer)
        {
            foundPlayer = true;
        }
        if (grabbed)
        {
            GetComponent<SpriteRenderer>().sortingOrder = 2;
            Vector3 newPos = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);
            transform.position = newPos; 
        }
        //Replace this
        if (foundPlayer)
        {
            target = GameObject.FindGameObjectWithTag("Player");
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
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!grabbed)
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
                transform.position += Vector3.up * speed * Time.deltaTime;
            }
            if (collision.gameObject.name == "ConveyorLeft")
            {
                transform.position += Vector3.left * speed * Time.deltaTime;
            }
            if (collision.gameObject.name == "ConveyorDown")
            {
                transform.position += Vector3.down * speed * Time.deltaTime;
            }
            if (collision.gameObject.name == "ConveyorRight")
            {
                transform.position += Vector3.right * speed * Time.deltaTime;
            }
        }
    }
    
}
