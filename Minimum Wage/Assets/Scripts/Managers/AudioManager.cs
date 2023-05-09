using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource music;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("Volume"))
        {
            music.volume = PlayerPrefs.GetFloat("Volume");
        }
    }

    public void ChangeVolume(float value)
    {
        music.volume = value;
    }
}
