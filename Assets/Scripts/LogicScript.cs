using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LogicScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int playerScore;
    public TextMeshProUGUI scoreText;
    public float speedBoost = 0f;
    private float timer = 0.0f;

    public void addScore(int scoreToAdd)
    {
        playerScore = playerScore + scoreToAdd;
        scoreText.text = "Score : " + playerScore.ToString();
    }

    public void increaseSpeed(float amount = 0.3f) 
    {
        speedBoost = speedBoost + amount;
    }

    void Update()
    {
        timer += Time.deltaTime;

        // Check if 1 second has passed
        if (timer >= 1.0f)
        {
            this.increaseSpeed();
            timer = 0.0f;
        }
    }
}
