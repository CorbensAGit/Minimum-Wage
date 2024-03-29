using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool IsPaused = false;

    public GameObject pauseMenuUI;

    // Update is called once per frame
    void Update ()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsPaused)
            {
                Resume();
            } else 
            {
                Pause();
            }
        } else if (IsPaused) 
        {
            Pause();
        }
    }

    public void Resume () 
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        IsPaused = false;
    }

    void Pause () 
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        IsPaused = true;
    }

    public void LoadMenu ()
    {
        Time.timeScale = 1f;
        // pauseMenuUI.SetActive(false);
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame ()
    {
        Debug.Log("Quitting Game");
        Application.Quit();
    }
}
