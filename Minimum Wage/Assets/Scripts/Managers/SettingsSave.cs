using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsSave : MonoBehaviour
{
    public Slider volumeSlider;
    public Toggle authToggle;

    void Start()
    {
        LoadSettings();
    }

    public void LoadSettings()
    {
        if (PlayerPrefs.HasKey("Autheticolour"))
        {
            int authentint = PlayerPrefs.GetInt("Authenticolour");
            Debug.Log("authentint: " + authentint);
            bool authenticolour = ((authentint == 0) ? false : true);
            Debug.Log("authenticolour: " + authenticolour);
            authToggle.isOn = authenticolour;
        }
        if (PlayerPrefs.HasKey("Volume"))
        {
            volumeSlider.value = PlayerPrefs.GetFloat("Volume");
        }
    }

    public void SaveSettings()
    {
        PlayerPrefs.SetFloat("Volume", volumeSlider.value);
        if (authToggle.isOn == true)
        {
            Debug.Log("Authenti true");
            PlayerPrefs.SetInt("Autheticolour", 1);
        } else if (authToggle.isOn == false)
        {
            PlayerPrefs.SetInt("Autheticolour", 0);
        }
        
    }
}
