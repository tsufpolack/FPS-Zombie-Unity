using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour

{
    public Canvas quitMenu;
    public Button play;
    public Button exit;



    // Start is called before the first frame update
    void Start()
    {
        quitMenu.enabled = false;

        
    }

    public void exitPress()
    {
        quitMenu.enabled = true;
        play.enabled = false;
        exit.enabled = false;
        

    }
    public void noPress()
    {
        quitMenu.enabled = false;
        play.enabled = true;
        exit.enabled = true;
        
    }

    public void playLevel()
    {
        SceneManager.LoadScene(1);

    }
    public void yesPress()
    {
        Application.Quit();
    }
}
