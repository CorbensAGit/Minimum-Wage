using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public static int gameTime;
    public LevelUI LevelUI;
    // Start is called before the first frame update
    void Start()
    {
       InvokeRepeating("tickTime", 0.0f, 1.0f); 
    }

    public void setTime(int time)
    {
        gameTime = time;
        LevelUI.updateTime();
    }

    public void tickTime()
    {
        Player.playTime++;
        LevelUI.updateTime();
    }
}
