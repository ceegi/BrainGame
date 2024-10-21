using UnityEngine;
using UnityEngine.UI;

public class LevelTextManager : MonoBehaviour
{
    [Header("Level UI Elements")]
    [SerializeField] private Text levelText;

    private LevelManager levelManager;

    private void Awake()
    {
        levelManager = FindObjectOfType<LevelManager>();
        if (levelManager == null)
        {
            Debug.LogError("LevelManager not found in the scene. Please ensure there is a LevelManager present.");
        }
    }

    private void Start()
    {
        UpdateLevelText();
    }

    public void UpdateLevelText()
    {
        if (levelText != null && levelManager != null)
        {
            levelText.text = levelManager.currentLevel.ToString();  // Use currentLevel instead of CurrentLevel
        }
        else
        {
            Debug.LogError("LevelText or LevelManager is null. Cannot update level text.");
        }
    }
}
