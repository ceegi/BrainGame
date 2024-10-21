using UnityEngine;

public class Barrel : MonoBehaviour
{
    float angle = 0;

    public GameObject projectilePrefab;
    public Transform firePoint;

    void Update()
    {
        Vector3 mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.position.z;
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        Vector3 direction = mousePos3D - transform.position;
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        if (Mathf.Abs(angle - 90) < 85)
        {
            transform.rotation = Quaternion.Euler(0, 0, angle - 90);
        }

        // Fire projectiles when keys are pressed
        if (Input.GetKeyDown(KeyCode.S))
        {
            FireProjectile(1); // Fire projectile with value 1
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            FireProjectile(2); // Fire projectile with value 2
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            FireProjectile(3); // Fire projectile with value 3
        }
    }

    void FireProjectile(int bulletValue)
    {
        // Get the ScoreManager instance
        ScoreManager uiManager = FindObjectOfType<ScoreManager>();
        if (uiManager == null) return;

        // Check for bullet availability
        if ((bulletValue == 1 && uiManager.GetBullet1Count() <= 0) ||
            (bulletValue == 2 && uiManager.GetBullet2Count() <= 0) ||
            (bulletValue == 3 && uiManager.GetBullet3Count() <= 0))
        {
            return;
        }

        // Decrease the bullet count
        uiManager.UpdateBulletCount(bulletValue);

        // Fire from the firePoint rotation
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);

        // Set the value (1, 2, or 3)
        Projectile projectileScript = projectile.GetComponent<Projectile>();
        if (projectileScript != null)
        {
            projectileScript.Initialize(bulletValue);
        }

        // Get projectile rigidbody
        Rigidbody rb = projectile.GetComponent<Rigidbody>();

        // Calculate the direction to shoot
        Vector3 shootDirection = transform.up; // Use the barrel's up direction

        // Determine the speed 
        float speed = bulletValue + 9f; // Assign speed based on bullet value
        rb.AddForce(shootDirection * speed, ForceMode.Impulse); // Use the calculated speed
    }



}