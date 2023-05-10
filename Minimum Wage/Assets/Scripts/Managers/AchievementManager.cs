using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementManager : MonoBehaviour
{
    public Queue<Achievement> AchievementQueue = new Queue<Achievement>();

    public static List<Achievement> Level1Achievements;
    public AchievementNotificationManager achievementNotificationManager;

    public Achievement achievementToShow;
    //public Achievements achievementToShow;
    
    private void Start()
    {
        Level1Achievements = new List<Achievement>();
        Level1Achievements.Add(new Achievement("OnTheClock", "On The Clock", "Beat Factory in Under 1 Minute"));
        Level1Achievements.Add(new Achievement("BarrelBuster", "Barrel Buster", "Break a Barrel"));
        Level1Achievements.Add(new Achievement("BigBucks", "Big Bucks", "Collect 50 Cash"));
        Level1Achievements.Add(new Achievement("ModelEmployee", "Model Employee", "Beat Factory Without Dying"));
        StartCoroutine("CheckAchievementQueue");
    }

    public void NotifyAchievement(string id)
    {
        foreach (Achievement achievement in Level1Achievements)
        {
            if (achievement.Unlocked == true) {
                // skip
            } else if (achievement.Id == id) {
                AchievementQueue.Enqueue(achievement);
            }
        }
    }

    public void ShowNotification(Achievement achievementToShow)
    {     
        achievementNotificationManager.ShowNotification(achievementToShow);
    }

    private void UnlockAchievement(Achievement achievement)
    {
        Debug.Log("Unlock achievement: " + achievement.Id);
        achievement.Unlocked = true;
        ShowNotification(achievement);
        PlayerPrefs.SetInt(achievement.Id, 1); 
    }

    private IEnumerator CheckAchievementQueue()
    {
        for(; ;)
        {
            if (AchievementQueue.Count > 0) UnlockAchievement(AchievementQueue.Dequeue());
            yield return new WaitForSeconds(2f);
        }
    }
}