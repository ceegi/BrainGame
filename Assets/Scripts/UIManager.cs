using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text currentLevelText;
    private LevelManager levelManager;

    void Start()
    {
        // Find LevelManager in scene
        levelManager = FindObjectOfType<LevelManager>();

        // Ensure levelManager is not null somehow
        if (levelManager != null)
        {
            UpdateLevelText();
        }
        else
        {
            Debug.LogError("LevelManager not found in the scene.");
        }
    }

    public void UpdateLevelText()
    {
        // Assigns text component
        if (currentLevelText != null)
        {
            currentLevelText.text = levelManager.currentLevel.ToString(); // Access currentLevel from levelManager
        }
        else
        {
            Debug.LogError("CurrentLevelText is not assigned in the inspector.");
        }
    }
}
