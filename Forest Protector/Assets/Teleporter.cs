using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleporter : MonoBehaviour
{
    public KillCounter killCounter; // Reference to the KillCounter script

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (killCounter.killCount >= 10)
            {
                // Destroy all objects marked as DontDestroyOnLoad
                DestroyAllDontDestroyOnLoadObjects();

                // Save the kill count and reset it
                PlayerPrefs.SetInt("KillCount", killCounter.killCount);
                killCounter.ResetKillCount();

                // Load the scene with index 3
                SceneManager.LoadScene(3);
            }
        }
    }

    private void DestroyAllDontDestroyOnLoadObjects()
    {
        // Find all root objects in the scene
        GameObject[] allObjects = GameObject.FindObjectsOfType<GameObject>();

        foreach (GameObject obj in allObjects)
        {
            // Check if the object is in the DontDestroyOnLoad scene
            if (obj.scene.name == "DontDestroyOnLoad")
            {
                Destroy(obj);
            }
        }
    }
}
