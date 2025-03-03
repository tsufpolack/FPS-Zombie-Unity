using UnityEngine;

public class BallShooter : MonoBehaviour
{
    public GameObject ballPrefab;  // Assign your ball prefab in the inspector
    public Transform spawnPoint;   // The point from where the ball will be instantiated
    public float shootForce = 500f; // The force with which the ball will be shot
    public float cooldownTime = 60f; // Cooldown time in seconds

    private float nextFireTime = 0f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && Time.time > nextFireTime)
        {
            ShootBall();
            nextFireTime = Time.time + cooldownTime;
        }
    }

    void ShootBall()
    {
        Camera cam = Camera.main; // Get the main camera
        GameObject ball = Instantiate(ballPrefab, spawnPoint.transform.position, cam.transform.rotation * Quaternion.Euler(0, -90, 0));

        Rigidbody rb = ball.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(-spawnPoint.right * shootForce);
        }
    }
}
