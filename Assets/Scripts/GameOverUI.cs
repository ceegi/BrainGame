using UnityEngine;
using UnityEngine.UI;

public class GameOverUIManager : MonoBehaviour
{
    [Header("Game Over UI Elements")]
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private Text finalScoreText;
    [SerializeField] private Text highScoreText;

    private void Awake()
    {
        // Ensure the Game Over screen is inactive at the start
        if (gameOverScreen != null)
        {
            gameOverScreen.SetActive(false);
        }
    }

    public void ShowGameOverScreen(bool isVictory, int finalScore, int highScore)
    {
        // Check if gameOverScreen is null
        if (gameOverScreen == null)
        {
            Debug.LogError("GameOverScreen is not assigned!");
            return;
        }

        // Check if finalScoreText is null
        if (finalScoreText == null)
        {
            Debug.LogError("FinalScoreText is not assigned!");
            return;
        }

        // Check if highScoreText is null
        if (highScoreText == null)
        {
            Debug.LogError("HighScoreText is not assigned!");
            return;
        }

        // Activate the Game Over screen
        gameOverScreen.SetActive(true);

        // Set the final score and high score text
        finalScoreText.text = "Final Score: " + finalScore.ToString();
        highScoreText.text = "High Score: " + highScore.ToString();

        // You can also customize the victory/defeat message if needed
        string resultMessage = isVictory ? "You Win!" : "Game Over!";
        // Assuming you have a Text component to display this message
        // Example: gameOverMessageText.text = resultMessage;
    }
}
