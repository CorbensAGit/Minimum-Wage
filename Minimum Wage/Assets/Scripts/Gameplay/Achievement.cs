using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Achievement
{
    public string Id;
    public string Title;
    public string Description;
    public bool Unlocked;
    
    public Achievement(string _id, string _title, string _Description)
    {
        Id = _id;
        Title = _title;
        Description = _Description;
        // achievements are accociated with the player not the save slot
        if(PlayerPrefs.HasKey(_id))
        {
            int value = PlayerPrefs.GetInt(_id);
            Unlocked = ((value == 0) ? false : true);
        } else {
            Unlocked = false;
        }
    }
}
