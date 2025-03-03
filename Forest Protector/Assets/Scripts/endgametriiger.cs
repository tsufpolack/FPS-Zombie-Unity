using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class EndGameTrigger : MonoBehaviour
{
    // Specify the name of Scene 2
    public string scene2Name = "endscene"; // Update scene name here
    private bool hasTriggered = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasTriggered)
        {
            hasTriggered = true;
            // Start the coroutine for delayed scene loading
            StartCoroutine(LoadSceneAfterDelay());
        }
    }

    IEnumerator LoadSceneAfterDelay()
    {
        // Wait for 10 seconds
        yield return new WaitForSeconds(1f);

        // Load Scene 2
        SceneManager.LoadScene(scene2Name);
    }
}