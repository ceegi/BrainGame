using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public int playerScore = 0;
    public int scoreRequiredToPass = 20;
    public int currentLevel = 1;
    public int maxLevel = 3;
    private ScoreManager scoreManager;

    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    public void CompleteLevel(bool isSuccessful)
    {
        Debug.Log($"CompleteLevel called: isSuccessful = {isSuccessful}, playerScore = {playerScore}");

        // If player reached the desired score, proceed to the next level
        if (isSuccessful)
        {
            // Update playerScore from ScoreManager
            playerScore = scoreManager.GetCurrentScore(); // Get the current score from ScoreManager

            if (playerScore >= scoreRequiredToPass)
            {
                // Save the player's score
                PlayerPrefs.SetInt("FinalScore", playerScore); // Store the current score

                // Check for new high score
                int highScore = PlayerPrefs.GetInt("HighScore", 0);
                if (playerScore > highScore)
                {
                    PlayerPrefs.SetInt("HighScore", playerScore);
                    Debug.Log("New high score!");
                }

                // Load the next level or end the game if it's the last level
                if (currentLevel < maxLevel)
                {
                    currentLevel++; // Move to the next level
                    LoadNextLevel();
                }
                else
                {
                    EndGame(true); // Ends the game if all levels are completed
                }
            }
            else
            {
                EndGame(false); // Ends the game if the score is insufficient
            }
        }
        else
        {
            EndGame(false); // Ends the game if unsuccessful
        }
    }

    void LoadNextLevel()
    {
        SceneManager.LoadScene("level" + currentLevel);
    }

    void EndGame(bool isComplete)
    {
        // End the game
        SceneManager.LoadScene("EndGame");
    }
}
