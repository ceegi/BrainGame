using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float levelDuration = 20f; // 20 seconds per level
    private float timeRemaining;
    private LevelManager levelManager;
    public Text timerText; 

    void Start()
    {
        timeRemaining = levelDuration;
        levelManager = FindObjectOfType<LevelManager>();
        UpdateTimerUI(); // Initialize the timer UI
    }

    void Update()
    {
        timeRemaining -= Time.deltaTime;

        // Ensure time doesn't go below zero
        if (timeRemaining < 0)
        {
            timeRemaining = 0;
            // Call CompleteLevel with false when time runs out
            levelManager.CompleteLevel(false); // Player didn't reach the score in time
        }

        UpdateTimerUI();
    }

    private void UpdateTimerUI()
    {
        // Format the time remaining as minutes and seconds
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);
        timerText.text = string.Format("{0:D2}:{1:D2}", minutes, seconds);
    }
}
