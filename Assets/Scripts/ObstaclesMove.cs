using UnityEngine;

public class ObstaclesMove : MonoBehaviour
{
    public float speed = 5f; // Speed of the obstacle
    public float deadZone = -30f; // The position at which the obstacle is destroyed
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime; // Move the obstacle to the left
        if (transform.position.x < deadZone)
        {
            Destroy(gameObject); // Destroy the obstacle when it reaches the dead zone
        }
    }
}
