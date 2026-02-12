using UnityEngine;

public class ItemScript : MonoBehaviour, IInteractable
{

    float speed = 2f;
    private PlayerSpawn playerSpawnRef;
    GameObject holder = null;

    //SpriteRenderer sr;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerSpawnRef = GameObject.Find("Player Input Manager").GetComponent<PlayerSpawn>();
    } 
    // Update is called once per frame
    void Update()
    {

        if (holder != null)
        {
            GetComponent<SpriteRenderer>().sortingOrder = 2;


            transform.position = holder.transform.position;
        }
        else
        {
            GetComponent<SpriteRenderer>().sortingOrder = 0;
        }
    }

    public bool CanInteract()
    {
        return holder == null;
    }
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
    }
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
            if(collision.gameObject.name == "FactoryLeftHitBox")
            {
                if(this.gameObject.tag == "RightItemLeft")
                {
                    if(this.gameObject.name == "HexHead")
                    {
                        Destroy(gameObject);
                        Debug.Log("aaaaaaa");
                    }
                    if(this.gameObject.name == "TriangleArm")
                    {
                        Destroy(gameObject);
                        Debug.Log("aaaaaaa");
                    }
                    if(this.gameObject.name == "TriangleLeg")
                    {
                        Destroy(gameObject);
                        Debug.Log("aaaaaaa");
                    }
                    Debug.Log("aaaaaaaaaaaaaa");
                }
                Debug.Log("aaaa");
            }
            if(collision.gameObject.name == "FactoryRightHitBox")
            {
                if(this.gameObject.tag == "RightItemRight")
                {
                    if(this.gameObject.name == "SquareBody")
                    {

                    }
                    if(this.gameObject.name == "CircleLeg")
                    {

                    }
                    if(this.gameObject.name == "CircleArm")
                    {
                        
                    }
                }
            }
        }
    }
    
}
