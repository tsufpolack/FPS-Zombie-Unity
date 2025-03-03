using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject menuPanel; // Assign the Panel object in the Inspector

    void Start()
    {
        menuPanel.SetActive(false); // Hide the menu at start
        Cursor.lockState = CursorLockMode.Locked; // Lock the cursor at start
        Cursor.visible = false; // Hide the cursor at start
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleMenu();
        }
    }

    public void ToggleMenu()
    {
        bool isActive = !menuPanel.activeSelf;
        menuPanel.SetActive(isActive);
        Time.timeScale = isActive ? 0 : 1; // Pause the game when the menu is active
        Cursor.lockState = isActive ? CursorLockMode.None : CursorLockMode.Locked; // Unlock/lock the cursor
        Cursor.visible = isActive; // Show/hide the cursor
    }

    public void ResumeGame()
    {
        menuPanel.SetActive(false);
        Time.timeScale = 1; // Resume the game
        Cursor.lockState = CursorLockMode.Locked; // Lock the cursor
        Cursor.visible = false; // Hide the cursor
    }

    public void ExitGame()
    {
        Application.Quit(); // Quit the application
        // If you're running in the editor, use UnityEditor.EditorApplication.isPlaying = false;
    }
}