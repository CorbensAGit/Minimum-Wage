using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementNotificationManager : MonoBehaviour
{
    //[SerializeField] Text achievementTitleLablel;
    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    public void ShowNotification(Achievement achievement)
    {
        Debug.Log("earned: " + achievement.id);
    }
}
