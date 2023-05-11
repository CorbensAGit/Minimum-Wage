using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using TMPro;
using UnityEngine.UI;

public class PowerUpStore : MonoBehaviour
{
    public TMP_Text CurrentCash;
    public TMP_Text Balance;
    public int balance;
    private PlayerData ourPlayer;
    
    public void LoadDetails()
    {
        // get the current player's cash and powerups
        string path = Application.persistentDataPath + "/" + SlotController.SaveSlot + "player.cok";
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Open);

        PlayerData ourPlayer = formatter.Deserialize(stream) as PlayerData;
        stream.Close();

        balance = 0;
        CurrentCash.text = "Cash: " + ourPlayer.cash;
        Balance.text = "Current: " + balance;
    }

    public void Complete()
    {
        // load level again but with only player's details

        SlotController.Load = false;
        SlotController.Continue = true;
    }

    public void changeBalance()
    {

    }
}
