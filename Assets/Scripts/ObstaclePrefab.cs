using UnityEngine;

public class ObstaclePrefab : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public GameObject obstaclePrefab2;
    private float spawnRate = 13f; // Rate at which the obstacle is spawned
    private float spawnRate2 = 5f; // Rate at which the obstacle is spawned
    private float nextSpawn = 0f; // Time to spawn the next obstacle
    private float nextSpawn2 = 0f; // Time to spawn the next obstacle
    private float heigthOffset = 0.5f; // Offset to spawn the obstacle at a random height
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (nextSpawn < spawnRate)
        {
            nextSpawn += Time.deltaTime; // Increment the time to spawn the next obstacle
        }
        else if (nextSpawn >= spawnRate)
        {
            Instantiate(obstaclePrefab, transform.position, transform.rotation); // Spawn the obstacle  
            nextSpawn = 0f; // Reset the time to spawn the next obstacle
        }
        if (nextSpawn2 < spawnRate2)
        {
            nextSpawn2 += Time.deltaTime; // Increment the time to spawn the next obstacle
        }
        else if (nextSpawn2 >= spawnRate2)
        {
            spawnObstacle();   
            nextSpawn2 = 0f; // Reset the time to spawn the next obstacle
        }
        
    }

    void spawnObstacle()
    {
        float loestY = transform.position.y - heigthOffset; // Calculate the lowest possible Y position
        float highestY = transform.position.y + heigthOffset; // Calculate the highest possible Y position
        Instantiate(obstaclePrefab2, new Vector3(transform.position.x, Random.Range(loestY, highestY), transform.position.z), transform.rotation);
    }
}
