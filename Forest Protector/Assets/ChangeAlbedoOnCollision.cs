using UnityEngine;

public class ChangeAlbedoOnCollision : MonoBehaviour
{
    // Drag and drop the GameObject you want to change the material color in this field in the Inspector
    public GameObject targetObject;

    // Reference to the material of the target object
    private Material targetMaterial;

    void Start()
    {
        if (targetObject != null)
        {
            // Get the material of the target object
            targetMaterial = targetObject.GetComponent<Renderer>().material;
        }
        else
        {
            Debug.LogError("Target object is not assigned.");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the colliding object has the tag "Player"
        if (collision.gameObject.CompareTag("Player"))
        {
            if (targetMaterial != null)
            {
                // Change the albedo (main color) of the material to blue
                targetMaterial.color = Color.blue;
            }
            else
            {
                Debug.LogError("Target material is not found.");
            }
        }
    }
}
