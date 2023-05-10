using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(Animator))]
public class AchievementNotificationManager : MonoBehaviour
{
    [SerializeField] TMP_Text achievementTitleLablel;

    private Animator curr_animator;
    // Start is called before the first frame update
    void Awake()
    {
        curr_animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    public void ShowNotification(Achievement achievement)
    {
        Debug.Log("earned: " + achievement.id);
        achievementTitleLablel.text = achievement.title;
        curr_animator.SetTrigger("Appear");
    }
}
