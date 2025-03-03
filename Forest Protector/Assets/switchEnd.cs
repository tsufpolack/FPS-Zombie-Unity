using UnityEngine;
using UnityEngine.SceneManagement;

public class switchEnd : MonoBehaviour
{
    private bool playerEntered = false;
    private float timer = 0f;
    public float delay = 10f; // delay before loading the scene
    private GameObject playerObject; // To store the player object reference
    public GameObject additionalObject1; // Drag and drop the first additional object in the editor
    public GameObject additionalObject2; // Drag and drop the second additional object in the editor
    public GameObject additionalObject3; // Drag and drop the third additional object in the editor

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object that entered the trigger has the tag "Player"
        if (other.CompareTag("Player"))
        {
            playerEntered = true;
            playerObject = other.gameObject;

            // Prevent the player object from being destroyed between scenes
            DontDestroyOnLoad(playerObject);
            DontDestroyOnLoad(additionalObject2);
            DontDestroyOnLoad(additionalObject1);

            DontDestroyOnLoad(additionalObject3);
        }
    }

    private void Update()
    {
        if (playerEntered)
        {
            timer += Time.deltaTime;

            // If the timer reaches the delay, load the scene
            if (timer >= delay)
            {
                SceneManager.sceneLoaded += OnSceneLoaded; // Subscribe to the sceneLoaded event
                SceneManager.LoadScene("Demo6");
            }
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Unsubscribe from the sceneLoaded event
        SceneManager.sceneLoaded -= OnSceneLoaded;

        // Set the player's position to the specified coordinates in the new scene
        playerObject.transform.position = new Vector3(-8.4923439f, 0.967000008f, -32.4674873f);
        additionalObject1.transform.position = new Vector3(-8.4923439f, 10.967000008f, -32.4674873f);
        additionalObject2.transform.position = new Vector3(-8.4923439f, 15.967000008f, -32.4674873f);
        additionalObject3.transform.position = new Vector3(-8.4923439f, 20.967000008f, -32.4674873f);
    }
}
