using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndGameManager : MonoBehaviour
{
    public Text scoreText;
    public Text highScoreText;

    void Start()
    {
        // Get scores from PlayerPrefs
        int finalScore = PlayerPrefs.GetInt("FinalScore", 0);
        int highScore = PlayerPrefs.GetInt("HighScore", 0);

        // Display the scores
        scoreText.text = "Score: " + finalScore.ToString();
        highScoreText.text = "High Score: " + highScore.ToString();
    }
}