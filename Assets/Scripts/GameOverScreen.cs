using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public TextMeshProUGUI pointsText;
    public TextMeshProUGUI highScoreText;

    public void Setup(int score)
    {
        gameObject.SetActive(true);
        pointsText.text = score.ToString();

        int highScore = PlayerPrefs.GetInt("HighScore", 0);

     
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
        }

        highScoreText.text =  highScore.ToString();
    }

    public void Restart(){
        SceneManager.LoadScene("SampleScene");
    }

    void Start()
    {
        gameObject.SetActive(false);
    }

}
