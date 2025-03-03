using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WelcomScript : MonoBehaviour
{
    public Text hellText;
    public float fadeSpeed = 1f; // Adjusted to a smaller value to allow gradual fading
    public float displayDuration = 30f; // Duration for the text to stay visible
    private bool enterance = false;
    private Coroutine fadeCoroutine;

    void Start()
    {
        hellText.color = Color.clear; // Start with text being invisible
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            enterance = true;
            hellText.color = Color.red; // Make text fully visible immediately
            if (fadeCoroutine != null)
            {
                StopCoroutine(fadeCoroutine); // Stop any existing fade coroutine
            }
            fadeCoroutine = StartCoroutine(FadeText());
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            enterance = false;
            if (fadeCoroutine != null)
            {
                StopCoroutine(fadeCoroutine); // Stop the coroutine if the player exits early
            }
            fadeCoroutine = StartCoroutine(FadeOutText());
        }
    }

    private IEnumerator FadeText()
    {
        yield return new WaitForSeconds(displayDuration); // Wait for the display duration
        StartCoroutine(FadeOutText());
    }

    private IEnumerator FadeOutText()
    {
        while (hellText.color.a > 0)
        {
            hellText.color = Color.Lerp(hellText.color, Color.clear, fadeSpeed * Time.deltaTime);
            yield return null;
        }
    }
}