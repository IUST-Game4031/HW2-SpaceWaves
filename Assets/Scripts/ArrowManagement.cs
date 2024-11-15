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

    private bool gameFinished = false;

    public LogicScript logicScript;
    public GameOverScreen gameOverScreen;

    private float timer = 0.0f;

    void Start()
    {
        arrowRigidbody.transform.rotation = Quaternion.Euler(0, 0, 0);
        logicScript = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();

        // Ensure the Rigidbody2D component is properly assigned
        if (arrowRigidbody == null)
        {
            arrowRigidbody = GetComponent<Rigidbody2D>();
        }
    }

    void Update()
    {
        if (gameFinished)
        {
            arrowRigidbody.transform.rotation = Quaternion.Euler(0, 0, -30);
            return;
        }

        // Increment the timer
        timer += Time.deltaTime;

        // Check if 1 second has passed
        if (timer >= 1.0f)
        {
            logicScript.addScore(1); // Increment the score
            timer = 0.0f;              // Reset the timer
        }

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
        if (other.CompareTag("Background"))
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
        if (other.CompareTag("Obstacle"))
        {
            EndGame();
        }
    }
    // Detect when the arrow exits a boundary trigger
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Background"))
        {
            canMoveUp = true;
            canMoveDown = true;
        }
    }

    // Ends the game
    private void EndGame()
    {
        gameFinished = true; // Prevent further movement
        arrowRigidbody.transform.rotation = Quaternion.Euler(0, 0, -30);
        arrowRigidbody.linearVelocity = new Vector2(0, -1); // Stop arrow movement
        gameOverScreen.Setup(logicScript.playerScore);
        Debug.Log("Game Over!"); // Log message (can be replaced with UI update)

    }
}
