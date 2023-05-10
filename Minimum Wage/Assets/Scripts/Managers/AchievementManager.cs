using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementManager : MonoBehaviour
{
    public AchievementDatabase db;
    public AchievementNotificationManager achievementNotificationManager;

    public Achievement achievementToShow;
    //public Achievements achievementToShow;
    
    public void ShowNotification()
    {
        //Achievement achievement = db.achievements[(int)achievementToShow];
        achievementNotificationManager.ShowNotification(achievementToShow);
    }
}