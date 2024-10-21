using UnityEngine;

public class Box : MonoBehaviour
{
    public int boxValue; // Initial value for the box
    public float fallSpeed = 2f; // Speed the box falls

    private TextMesh textMesh; // Reference to the TextMesh component
    private bool isDestroyed = false; // Track if the box is gone

    // Initialize the box value
    public void InitializeBoxValue(int value)
    {
        boxValue = value;
        UpdateBoxDisplay(); // Update display when box value is set
    }

    // Method to subtract projectile value from box value
    public void SubtractValue(int bulletValue)
    {
        if (isDestroyed) return; // Avoid doing anything if the box is already gone

        boxValue -= bulletValue;

        // Get a ScoreManager instance to manage the scoring
        ScoreManager scoreManager = FindObjectOfType<ScoreManager>();

        if (scoreManager != null)
        {
            if (boxValue <= 0) // Only destroy when the box is <= 0
            {
                // Only add points if the box value is exactly 0
                if (boxValue == 0)
                {
                    scoreManager.AddScore(10); // Add score for destroying the box exactly
                }
                else if (boxValue < 0)
                {
                    // Deduct score only if the box value was greater than 0 prior to decrementing
                    if (boxValue + bulletValue > 0) // Means boxValue was positive before the last bullet
                    {
                        scoreManager.DeductScore(5); // Deduct points for going below zero
                    }
                }

                scoreManager.BoxDestroyed(); // Award points
                isDestroyed = true; // Avoids double counting

                Destroy(gameObject); // Destroy the box after adjusting the score
            }
        }
        UpdateBoxDisplay();
    }

    private void UpdateBoxDisplay()
    {
        if (textMesh == null)
        {
            textMesh = GetComponentInChildren<TextMesh>();
        }

        if (textMesh != null)
        {
            textMesh.text = boxValue.ToString(); // Update TextMesh
        }
    }

    private void Update()
    {
        if (isDestroyed) return; // Kills box process if the box is already destroyed

        // Moves the box down
        transform.position += Vector3.down * fallSpeed * Time.deltaTime;

        // Destroys box when it goes off screen
        if (transform.position.y < -6)
        {
            ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
            if (scoreManager != null)
            {
                // Deduct points when the box goes off screen
                scoreManager.DeductScore(5);
            }

            Destroy(gameObject); // Destroy if out of bounds
        }
    }
}