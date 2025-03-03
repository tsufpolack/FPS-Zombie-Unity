using UnityEngine;
using UnityEngine.SceneManagement;

public class switchEnd2 : MonoBehaviour
{
    private bool playerEntered = false;

    public GameObject additionalObject2; // Drag and drop the second additional object in the editor


    private void OnTriggerEnter(Collider other)
    {
        // Check if the object that entered the trigger has the tag "Player"
        if (other.CompareTag("Player"))
        {

            DontDestroyOnLoad(additionalObject2);

        }
    }


    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Unsubscribe from the sceneLoaded event
        SceneManager.sceneLoaded -= OnSceneLoaded;

        additionalObject2.transform.position = new Vector3(-8.4923439f, 10.967000008f, -32.4674873f);

    }
}
