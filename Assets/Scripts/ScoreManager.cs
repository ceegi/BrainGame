using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text bullet1CountText;
    public Text bullet2CountText;
    public Text bullet3CountText;
    public Text boxesDestroyedCountText;
    public Text scoreText;

    private int bullet1Count = 50;
    private int bullet2Count = 50;
    private int bullet3Count = 50;

    private int boxesDestroyedCount = 0;
    private int score = 0;

    private LevelManager levelManager;

    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();

        // Reset the score at the start of each level
        score = 0;
        UpdateUI();
    }

    // Update the bullet count based on bullet type
    public void UpdateBulletCount(int bulletValue)
    {
        switch (bulletValue)
        {
            case 1:
                bullet1Count--;
                break;
            case 2:
                bullet2Count--;
                break;
            case 3:
                bullet3Count--;
                break;
        }
        UpdateUI(); // Update the UI
    }

    // Track when a box is destroyed
    public void BoxDestroyed()
    {
        boxesDestroyedCount++;
        UpdateUI(); 
    }

    // Add points to the score
    public void AddScore(int points)
    {
        score += points;
        UpdateUI(); // Update UI after changing score

        // Check if score is high enough to complete the level
        if (levelManager != null && score >= levelManager.scoreRequiredToPass)
        {
            levelManager.CompleteLevel(true);
        }
    }

    // Deducts points from score
    public void DeductScore(int points)
    {
        score -= points;
        UpdateUI();
    }

    // Return the current score
    public int GetCurrentScore()
    {
        return score; 
    }

    //Gets the bullet count
    public int GetBullet1Count() { return bullet1Count; }
    public int GetBullet2Count() { return bullet2Count; }
    public int GetBullet3Count() { return bullet3Count; }

    private void UpdateUI()
    {
        Debug.Log($"Score: {score}");
        bullet1CountText.text = $"{bullet1Count} (1)";
        bullet2CountText.text = $"{bullet2Count} (2)";
        bullet3CountText.text = $"{bullet3Count} (3)";
        boxesDestroyedCountText.text = $"{boxesDestroyedCount}x";
        scoreText.text = score.ToString();
    }
}
