using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using TMPro;
using UnityEngine.UI;

public class LoadMenuData : MonoBehaviour
{
    
    public Button Slot1;
    public TMP_Text Slot1Info;
    public Button Slot2;
    public TMP_Text Slot2Info;
    public Button Slot3;
    public TMP_Text Slot3Info;

    public void LoadSlots()
    {   
        string display;
        for (int i = 1; i < 4; i++)
        {
            // find and load PlayerData from files
            string path = Application.persistentDataPath + "/" + i + "player.cok";
            if (File.Exists(path))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream stream = new FileStream(path, FileMode.Open);

                PlayerData data = formatter.Deserialize(stream) as PlayerData;
                stream.Close();
                switch(i) 
                    {
                    case 1:
                        // assign slot1 details
                        display = "Lives: " + data.lives + "  |  Time: " + data.time + "  |  Cash: " + data.cash;
                        Slot1Info.text = display;
                        Slot1.interactable = true;
                        break;
                    case 2:
                        // assign slot2 details
                        display = "Lives: " + data.lives + "  |  Time: " + data.time + "  |  Cash: " + data.cash;
                        Slot2Info.text = display;
                        Slot2.interactable = true;
                        break;
                    case 3:
                        // assign slot3 details
                        display = "Lives: " + data.lives + "  |  Time: " + data.time + "  |  Cash: " + data.cash;
                        Slot3Info.text = display;
                        Slot3.interactable = true;
                        break;
                    }
            } else {
                switch(i) 
                    {
                    case 1:
                        // assign slot1 details
                        Slot1Info.text = "<color=#C8C8C8>No Save Data</color>";
                        Slot1.interactable = false;
                        break;
                    case 2:
                        // assign slot2 details
                        Slot2Info.text = "<color=#C8C8C8>No Save Data</color>";
                        Slot2.interactable = false;
                        break;
                    case 3:
                        // assign slot3 details
                        Slot3Info.text = "<color=#C8C8C8>No Save Data</color>";
                        Slot3.interactable = false;
                        break;
                    }
            }
        }
        
    }
}
