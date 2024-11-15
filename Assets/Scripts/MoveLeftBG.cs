using UnityEngine;

public class MoveLeftBG : MonoBehaviour
{
    public float speed = 5f; // Speed of the background
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime); // Move the background to the left
    }
}
