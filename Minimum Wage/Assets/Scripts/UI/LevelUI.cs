using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelUI : MonoBehaviour
{
    public TMP_Text cashDisplay;
    public TMP_Text timeDisplay;
    public TMP_Text livesDisplay;
    public TMP_Text shinGuardDisplay;
    public Player player;

    // Start is called before the first frame update
    void Start()
    {
        cashDisplay.text = "$" + player.cash;
        livesDisplay.text = "lives: " + player.lives;
        InvokeRepeating("ChangeTime", 0.0f, 1.0f);
    }

    public void ChangeLives() {
        livesDisplay.text = "lives: " + player.lives;
    }

    public void ChangeCash() {
        cashDisplay.text = "$" + player.cash;
    }

    public void ChangeTime() {
        timeDisplay.text = "Time: " + (int)Time.time;
    }

    public void UpdateAll()
    {
        livesDisplay.text = "lives: " + player.lives;
        cashDisplay.text = "$" + player.cash;
        timeDisplay.text = "Time: " + (int)Time.time;
    }

    public void updateShinGuard()
    {
        if (player.shinGuardAvailable == true)
        {
            shinGuardDisplay.text = "Shin Guard Ready!";
        }
        else if (player.shinGuard > 0)
        {
            shinGuardDisplay.text = "Shin Guard: " + player.shinGuard;
        }
        else
        {
            shinGuardDisplay.text = "";
        }
        
    }
}
