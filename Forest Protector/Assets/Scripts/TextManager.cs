using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WelcomeScript : MonoBehaviour
{
    public Text messageText; // Reference to the UI Text component
    public float fadeSpeed = 1f; // Speed at which the text fades out
    public float displayDuration = 30f; // Duration for the text to stay visible before starting to fade out
    private bool isPlayerInTrigger = false; // Flag to check if the player is in the trigger zone
    private Coroutine fadeCoroutine;

    void Start()
    {
        messageText.color = Color.clear; // Start with text being invisible
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInTrigger = true;
            messageText.color = Color.white; // Make text fully visible immediately
            if (fadeCoroutine != null)
            {
                StopCoroutine(fadeCoroutine); // Stop any existing fade coroutine
            }
            fadeCoroutine = StartCoroutine(DisplayText());
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInTrigger = false;
            if (fadeCoroutine != null)
            {
                StopCoroutine(fadeCoroutine); // Stop the coroutine if the player exits early
            }
            fadeCoroutine = StartCoroutine(FadeOutText());
        }
    }

    private IEnumerator DisplayText()
    {
        yield return new WaitForSeconds(displayDuration); // Wait for the display duration
        if (!isPlayerInTrigger) // If the player is no longer in the trigger, start fading out
        {
            StartCoroutine(FadeOutText());
        }
    }

    private IEnumerator FadeOutText()
    {
        while (messageText.color.a > 0)
        {
            messageText.color = Color.Lerp(messageText.color, Color.clear, fadeSpeed * Time.deltaTime);
            yield return null;
        }
    }
}