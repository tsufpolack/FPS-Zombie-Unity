using UnityEngine;
using UnityEngine.SceneManagement;

public class PlaySoundOnCollision : MonoBehaviour
{
    // Reference to the AudioSource component
    public AudioSource audioSource;

    private void Update()
    {
        // Check if the current scene is "Demo6Fps"
        if (SceneManager.GetActiveScene().name == "Demo6Fps")
        {
            // Set the position of this GameObject
            transform.position = new Vector3(6.22366047f, 0.0430000015f, -22.5734749f);
        }
    }

    // This method is called when the collider attached to this GameObject collides with another collider
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collided object has the tag "Player"
        if (collision.gameObject.CompareTag("Player"))
        {
            // Play the audio if it's not already playing
            if (audioSource != null && !audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
    }
}
