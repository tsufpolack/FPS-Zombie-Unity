using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;

    void Start()
    {
        // Find the GameObject named "w"
        GameObject wObject = GameObject.Find("w");

        // Check if the GameObject was found and has an AudioSource component
        if (wObject != null)
        {
            audioSource = wObject.GetComponent<AudioSource>();
        }
        else
        {
            Debug.LogError("GameObject named 'w' not found or does not have an AudioSource component.");
        }

        // Destroy the ball itself after 6 seconds
        Destroy(gameObject, 10f);
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the object collided with is tagged as "Sphere"
        if (collision.gameObject.CompareTag("Sphere") && audioSource != null)
        {
            // Play the audio
            audioSource.Play();
        }
    }
}
