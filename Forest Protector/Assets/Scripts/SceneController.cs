using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    // Method to reload the main game scene
    public void PlayAgain()
    {
        SceneManager.LoadScene("Demo6"); 
    }

    // Method to quit the game
    public void QuitGame()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}