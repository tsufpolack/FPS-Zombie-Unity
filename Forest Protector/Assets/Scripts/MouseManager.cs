using UnityEngine;

public class MouseManager : MonoBehaviour
{
    void Start()
    {
        // Enable mouse input
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}