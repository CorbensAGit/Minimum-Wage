using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_MainMenu : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject CreditsMenu;
    public SpriteRenderer SettingsSquare;
    public SpriteRenderer BackSquare;
    public Color transparent;

    // Start is called before the first frame update
    void Start()
    {
        MainMenuButton();
        transparent = new Color(0, 0, 0, 0);
    }

    public void PlayNowButton()
    {
        // Play Now Button has been pressed, here you can initialize your game (For example Load a Scene called GameLevel etc.)
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level01");
    }

    public void SettingsButton()
    {
        // Show Credits Menu
        MainMenu.SetActive(false);
        // reset the back square
        CreditsMenu.SetActive(true);
        BackSquare.color = transparent;
    }

    public void MainMenuButton()
    {
        // Show Main Menu
        CreditsMenu.SetActive(false);
        // reset the settings square
        MainMenu.SetActive(true);
        SettingsSquare.color = transparent;
    }

    public void QuitButton()
    {
        // Quit Game
        Application.Quit();
    }
}