using UnityEngine;


// used this as a base
//https://www.youtube.com/watch?v=cecD66fZ_4c 
public class SquareSpawningScript: MonoBehaviour
{
    [SerializeField]
    private GameObject SquareItem;
    [SerializeField]
    float spawnTime;

    float timeUntilSpawn;

    //bool spawning = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timeUntilSpawn = 1f;   
    }

    // Update is called once per frame
    private void Update()
    {
       
        timeUntilSpawn -= Time.deltaTime;
        if (timeUntilSpawn <= 0)
        {
            Instantiate(SquareItem, transform.position, Quaternion.identity);
            timeUntilSpawn = spawnTime;
        }
        
    }
}