using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveSystem : MonoBehaviour
{
    public static List<Barrel> barrels = new List<Barrel>();
    [SerializeField] Barrel barrelPrefab;

    public static void SavePlayer (Player player) 
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.cok";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(player);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData LoadPlayer ()
    {
        string path = Application.persistentDataPath + "/player.cok";
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
        string path = Application.persistentDataPath + "/barrels.cok";
        string countPath = Application.persistentDataPath + "/barrelCount.cok";

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
        string path = Application.persistentDataPath + "/barrels.cok";
        string countPath = Application.persistentDataPath + "/barrelCount.cok";
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

            } else {
                Debug.LogError("path not found: " + path + i);
            }
            
        }
    }
}
