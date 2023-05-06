using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_MainMenu : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject CreditsMenu;
    public GameObject LoadMenu;
    public GameObject SaveMenu;
    public SpriteRenderer SettingsSquare;
    public SpriteRenderer BackSquare;
    public SpriteRenderer ContinueSquare;
    public SpriteRenderer StartSquare;
    public Color transparent = new Color(0, 0, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        MainMenu.SetActive(true);
        //MainMenuButton();
    }

    public void ContinueButton()
    {
        MainMenu.SetActive(false);
        LoadMenu.SetActive(true);
    }

    public void PlayNowButton(int saveSlot)
    {
        SlotController.SaveSlot = saveSlot;
        SlotController.Load = false;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level01");
    }

    public void LoadNowButton(int saveSlot)
    {
        SlotController.SaveSlot = saveSlot;
        SlotController.Load = true;
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

    public void LoadMenuBackButton()
    {
        LoadMenu.SetActive(false);

        MainMenu.SetActive(true);
        ContinueSquare.color = transparent;
    }

    public void SaveMenuBackButton()
    {
        SaveMenu.SetActive(false);

        MainMenu.SetActive(true);
        StartSquare.color = transparent;
    }

    public void QuitButton()
    {
        // Quit Game
        Application.Quit();
    }

    public void StartButton()
    {
        MainMenu.SetActive(false);
        SaveMenu.SetActive(true);
    }
}