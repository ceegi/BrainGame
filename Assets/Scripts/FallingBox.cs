using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBox : MonoBehaviour
{
    public GameObject boxPrefab;
    public float spawnInterval = 2.0f; // Time interval between spawns
    public ScoreManager scoreManager;
    private float screenHeight;

    void Start()
    {
        // Start the box spawning coroutine
        StartCoroutine(SpawnBoxes());

        // Calculates the height of the screen in world units
        screenHeight = Camera.main.orthographicSize * 2;
    }

    IEnumerator SpawnBoxes()
    {
        while (true) // Infinite loop to keep spawning boxes
        {
            SpawnBox(); // Spawn a box
            yield return new WaitForSeconds(spawnInterval); // Wait for the specified interval
        }
    }

    void SpawnBox()
    {
        // Generate a random x position within the screen width
        float randomX = Random.Range(-Camera.main.orthographicSize * Camera.main.aspect, Camera.main.orthographicSize * Camera.main.aspect);

        // Set the spawn position at the top of the screen
        Vector3 spawnPosition = new Vector3(randomX, Camera.main.orthographicSize + 1, 0); // Offsets slightly to make sure it spawns above the screen

        // New the box at the spawnpoint
        GameObject box = Instantiate(boxPrefab, spawnPosition, Quaternion.identity);

        // Sets a random value between 1 and 10
        int randomBoxValue = Random.Range(1, 11);
        box.GetComponent<Box>().InitializeBoxValue(randomBoxValue); // Initialize box value

        // Makes sure there is a rigidbody
        Rigidbody rb = box.GetComponent<Rigidbody>();
        if (rb == null)
        {
            rb = box.AddComponent<Rigidbody>();
        }

        rb.useGravity = false;
    }
}