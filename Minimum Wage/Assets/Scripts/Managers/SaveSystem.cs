using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveSystem : MonoBehaviour
{
    public static List<Barrel> barrels = new List<Barrel>();
    public static List<Money> money = new List<Money>();
    public Player currentPlayer;
    [SerializeField] Barrel barrelPrefab;
    [SerializeField] Money moneyPrefab;
    
    void Start()
    {
        if (SlotController.Load == true)
        {
            Debug.Log("Load is: " + SlotController.Load);
            // remove default objects

            if (barrels != null) {
                for (int i = 0; i < barrels.Count; i++)
                {
                    barrels[i].KillYourself();
                }
            }

            if (money != null)
            {
                for (int i = 0; i < money.Count; i++)
                {
                    money[i].KillYourself();
                }
            }
            
            currentPlayer.LoadPlayer();
            LoadBarrels();
            LoadMoney();
        } else if (SlotController.Continue == true)
        {
            currentPlayer.LoadPlayer();
        }
    }
    public static void SavePlayer (Player player) 
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/" + SlotController.SaveSlot + "player.cok";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(player);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData LoadPlayer ()
    {
        string path = Application.persistentDataPath + "/" + SlotController.SaveSlot + "player.cok";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return data;
        } else {
            Debug.LogError("file not found: " + path);
            return null;
        }
    }

    public void SaveBarrels()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/" + SlotController.SaveSlot + "barrels.cok";
        string countPath = Application.persistentDataPath + "/" + SlotController.SaveSlot + "barrelCount.cok";

        FileStream countStream = new FileStream(countPath, FileMode.Create);
        formatter.Serialize(countStream, barrels.Count);
        countStream.Close();

        for (int i = 0; i < barrels.Count; i++) 
        {
            FileStream stream = new FileStream(path + i, FileMode.Create);
            BarrelData data = new BarrelData(barrels[i]);

            formatter.Serialize(stream, data);
            stream.Close();
        }
    }

    public void LoadBarrels()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/" + SlotController.SaveSlot + "barrels.cok";
        string countPath = Application.persistentDataPath + "/" + SlotController.SaveSlot + "barrelCount.cok";
        int barrelCount = 0;
        if (File.Exists(countPath))
        {
            FileStream countStream = new FileStream(countPath, FileMode.Open);
            barrelCount = (int) formatter.Deserialize(countStream);
            countStream.Close();
        } else {
            Debug.LogError("path not found: " + countPath);
        }

        for (int i = 0; i < barrelCount; i++)
        {
            if (File.Exists(path + i))
            {
                FileStream stream = new FileStream(path + i, FileMode.Open);
                BarrelData data = formatter.Deserialize(stream) as BarrelData;

                stream.Close();

                Vector2 position = new Vector2(data.position[0], data.position[1]);
                Barrel barrel = Instantiate(barrelPrefab, position, Quaternion.identity);

                barrel.direction = data.direction;
                barrel.rb.velocity = new Vector2(data.velocity[0], data.velocity[1]);

            } else {
                Debug.LogError("path not found: " + path + i);
            }
            
        }
    }

    public void SaveMoney()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/" + SlotController.SaveSlot + "money.cok";
        string countPath = Application.persistentDataPath + "/" + SlotController.SaveSlot + "moneyCount.cok";

        FileStream countStream = new FileStream(countPath, FileMode.Create);
        formatter.Serialize(countStream, money.Count);
        countStream.Close();

        for (int i = 0; i < money.Count; i++) 
        {
            FileStream stream = new FileStream(path + i, FileMode.Create);
            MoneyData data = new MoneyData(money[i]);

            formatter.Serialize(stream, data);
            stream.Close();
        }
    }

    public void LoadMoney()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/" + SlotController.SaveSlot + "money.cok";
        string countPath = Application.persistentDataPath + "/" + SlotController.SaveSlot + "moneyCount.cok";
        int moneyCount = 0;
        if (File.Exists(countPath))
        {
            FileStream countStream = new FileStream(countPath, FileMode.Open);
            moneyCount = (int) formatter.Deserialize(countStream);
            countStream.Close();
        } else {
            Debug.LogError("path not found: " + countPath);
        }

        for (int i = 0; i < moneyCount; i++)
        {
            if (File.Exists(path + i))
            {
                FileStream stream = new FileStream(path + i, FileMode.Open);
                MoneyData data = formatter.Deserialize(stream) as MoneyData;

                stream.Close();

                Vector2 position = new Vector2(data.position[0], data.position[1]);
                Money money = Instantiate(moneyPrefab, position, Quaternion.identity);

                money.value = data.value;
                money.player = currentPlayer;

            } else {
                Debug.LogError("path not found: " + path + i);
            }
            
        }
    }
}
