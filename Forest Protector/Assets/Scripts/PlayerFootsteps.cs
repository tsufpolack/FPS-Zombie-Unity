using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayerFootsteps : MonoBehaviour
{
    public AudioClip walkingSound;
    public float volume = 0.5f;
    public float pitchRange = 0.2f;

    private AudioSource audioSource;
    private CharacterController characterController;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Check if the player is moving
        if (characterController.velocity.magnitude > 0 && !audioSource.isPlaying)
        {
            PlayFootstepSound();
        }
        else if (characterController.velocity.magnitude == 0 && audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }

    void PlayFootstepSound()
    {
        // Play the walking sound
        audioSource.clip = walkingSound;
        audioSource.volume = volume;
        audioSource.pitch = 1f + Random.Range(-pitchRange, pitchRange);
        audioSource.Play();
    }
}