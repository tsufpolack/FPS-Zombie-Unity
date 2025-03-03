using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnTrigger : MonoBehaviour
{
    // Drag and drop the GameObject you want to trigger the scene load in the Inspector
    public GameObject triggerObject;

    public GameObject dog;
    // Name of the scene to load
    public string sceneName = "Tutorial";

    // This function is called when another object enters the trigger collider
    private void OnTriggerEnter(Collider other)
    {
        // Check if the object that entered the trigger is the specified object
        if (other.gameObject == triggerObject)
        {
            DontDestroyOnLoad(dog);
            // Load the specified scene
            SceneManager.LoadScene(sceneName);
        }
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
                dog.transform.position = new Vector3(-5.4923439f, 0.039f, -32.4674873f);

        // Unsubscribe from the sceneLoaded event
        SceneManager.sceneLoaded -= OnSceneLoaded;

        dog.transform.position = new Vector3(-5.4923439f, 0.039f, -32.4674873f);

    }
}
