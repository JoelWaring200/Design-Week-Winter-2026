using UnityEngine;

public class ItemScript : MonoBehaviour, IInteractable
{

    float speed = 2f;
    private PlayerSpawn playerSpawnRef;
    GameObject holder = null;


    GameObject legLeftItem;
    SpriteRenderer legLeftItemSr;
    GameObject headLeftItem;
    SpriteRenderer headLeftItemSr;
    GameObject armLeftItem;
    SpriteRenderer armLeftItemSr;
    GameObject legRightItem;
    SpriteRenderer legRightItemSr;
    GameObject armRightItem;
    SpriteRenderer armRightItemSr;
    GameObject bodyRightItem;
    SpriteRenderer bodyRightItemSr;
    //SpriteRenderer sr;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerSpawnRef = GameObject.Find("Player Input Manager").GetComponent<PlayerSpawn>();
        //left leg
        legLeftItem = GameObject.Find("legLeft");
        legLeftItemSr = legLeftItem.GetComponent<SpriteRenderer>();
        //left head
        headLeftItem = GameObject.Find("headLeft");
        headLeftItemSr = headLeftItem.GetComponent<SpriteRenderer>();
        //left arm
        armLeftItem = GameObject.Find("armLeft");
        armLeftItemSr = armLeftItem.GetComponent<SpriteRenderer>();
        //right leg
        legRightItem = GameObject.Find("legRight");
        legRightItemSr = legRightItem.GetComponent<SpriteRenderer>();
        //right body
        bodyRightItem = GameObject.Find("bodyRight");
        bodyRightItemSr = bodyRightItem.GetComponent<SpriteRenderer>();
        //right arm
        armRightItem = GameObject.Find("armRight");
        armRightItemSr = armRightItem.GetComponent<SpriteRenderer>();
    }
    // Update is called once per frame
    void Update()
    {
        if (legLeftItemSr == null)
        {
            Debug.Log("what the fuck");
        }

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
            //factory checks
            if (collision.gameObject.name == "FactoryLeftHitBox")
            {
                if (this.gameObject.tag == "RightItemLeft")
                {
                    if (this.gameObject.name == "HexHead")
                    {
                        Destroy(gameObject);
                        FactoryManager.instance.FactoryHeadLeft = true;
                        headLeftItemSr.sortingOrder = 2;
                    }
                    if (this.gameObject.name == "TriangleArm")
                    {
                        Destroy(gameObject);
                        FactoryManager.instance.FactoryArmLeft = true;
                        armLeftItemSr.sortingOrder = 2;
                    }
                    if (this.gameObject.name == "TriangleLeg")
                    {
                        Destroy(gameObject);
                        FactoryManager.instance.FactoryLegLeft = true;
                        legLeftItemSr.sortingOrder = 2;
                    }
                }

            }
            if (collision.gameObject.name == "FactoryRightHitBox")
            {
                if (this.gameObject.tag == "RightItemRight")
                {
                    if (this.gameObject.name == "SquareBody")
                    {
                        Destroy(gameObject);
                        FactoryManager.instance.FactoryBodyRight = true;
                        bodyRightItemSr.sortingOrder = 2;
                    }
                    if (this.gameObject.name == "CircleArm")
                    {
                        Destroy(gameObject);
                        FactoryManager.instance.FactoryArmRight = true;
                        armRightItemSr.sortingOrder = 2;
                    }
                    if (this.gameObject.name == "CircleLeg")
                    {
                        Destroy(gameObject);
                        FactoryManager.instance.FactoryLegRight = true;
                        legRightItemSr.sortingOrder = 2;
                    }
                }
            }
        }
    }

}
