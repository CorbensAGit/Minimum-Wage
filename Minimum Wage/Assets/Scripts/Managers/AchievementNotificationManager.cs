using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(Animator))]
public class AchievementNotificationManager : MonoBehaviour
{
    public TMP_Text achievementTitleLablel;
    public TMP_Text achievementDescriptionLabel;

    public Animator curr_animator;

    // Update is called once per frame
    public void ShowNotification(Achievement achievement)
    {
        achievementTitleLablel.text = achievement.Title;
        achievementDescriptionLabel.text = achievement.Description;
        curr_animator.SetTrigger("Appear");
    }
}
