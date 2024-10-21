using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int value; // The value of the bullet (1, 2, or 3)

    // Initialize the bullet value
    public void Initialize(int bulletValue)
    {
        value = bulletValue;
    }

    private void Update()
    {
        // Check if the projectile is out of the screen bounds
        if (transform.position.y > Camera.main.orthographicSize || transform.position.y < -Camera.main.orthographicSize)
        {
            Destroy(gameObject); // Destroy the projectile if it's out of screen bounds
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object it collided with is a box
        if (other.CompareTag("Box"))
        {
            Box box = other.GetComponent<Box>();
            if (box != null)
            {
                // Subtract the projectile's value from the box's value
                box.SubtractValue(value);
            }

            // Destroy the projectile after collision
            Destroy(gameObject);
        }
    }
}