using UnityEngine;

public class ArrowManagement : MonoBehaviour
{
    public Rigidbody2D arrowRigidbody;
    public float forwardSpeed = 5f;
    public float upwardForce = 10;            // The force applied when space is held
    public float fallSpeedLimit = -10f;       // Maximum speed when falling down
    private bool canMoveUp = true;            // Can the arrow move upward
    private bool canMoveDown = true;          // Can the arrow move downward
    public float minY = -2f;

    void Start()
    {
        arrowRigidbody.transform.rotation = Quaternion.Euler(0, 0, 0);
        // Ensure the Rigidbody2D component is properly assigned
        if (arrowRigidbody == null)
        {
            arrowRigidbody = GetComponent<Rigidbody2D>();
        }
    }

    void Update()
    {
        // Vector2 forwardMovement = new Vector2(forwardSpeed, arrowRigidbody.linearVelocity.y);
        // arrowRigidbody.linearVelocity = forwardMovement;
        // Check if the space key is being held down
        if (Input.GetKey(KeyCode.Space) && canMoveUp)
        {
            // Only apply upward force if the arrow can move up
            arrowRigidbody.linearVelocity = new Vector2(arrowRigidbody.linearVelocity.x, upwardForce);
            arrowRigidbody.transform.rotation = Quaternion.Euler(0, 0, 30);
        }
        else if (!Input.GetKey(KeyCode.Space) && canMoveDown)
        {
            // Apply gravity effect only if the arrow can move down
            if (arrowRigidbody.linearVelocity.y > fallSpeedLimit)
            {
                arrowRigidbody.linearVelocity += Vector2.down * Time.deltaTime * 30f; // Simulates gravity effect for smooth fall
                arrowRigidbody.transform.rotation = Quaternion.Euler(0, 0, -30);
            }
        }
    }

    // Detect when the arrow enters a boundary trigger
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Background")
        {
            if (transform.position.y > 0f)
            {
                canMoveUp = false;
                arrowRigidbody.linearVelocity = new Vector2(arrowRigidbody.linearVelocity.x, 0); // Stop upward velocity
                arrowRigidbody.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else
            {
                canMoveDown = false;
                arrowRigidbody.linearVelocity = new Vector2(arrowRigidbody.linearVelocity.x, 0); // Stop downward velocity
                arrowRigidbody.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }
    }
    // Detect when the arrow exits a boundary trigger
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Background")
        {
            canMoveUp = true;
            canMoveDown = true;
        }
    }
}
