using UnityEngine;

public class TeleportOnCollision : MonoBehaviour
{
    // Drag and drop the GameObject you want to teleport in the Inspector
    public GameObject objectToTeleport;

    // The target position to teleport to
    private Vector3 targetPosition = new Vector3(2.47f, 0f, -40.47f);

    // This function is called when another object collides with the GameObject this script is attached to
    private void OnCollisionEnter(Collision collision)
    {
        if (objectToTeleport != null)
        {
            // Teleport the object to the target position
            objectToTeleport.transform.position = targetPosition;
        }
    }
}
