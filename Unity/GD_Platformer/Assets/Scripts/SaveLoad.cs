using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveLoad : MonoBehaviour
{

    public Statistics stats;

    public void Save() {
        string dir = Application.persistentDataPath + "/Saves";
        if(!Directory.Exists(dir)) {
            Directory.CreateDirectory(dir);
        }

        Debug.Log(dir);
        string json = JsonUtility.ToJson(stats);
        File.WriteAllText(dir + "/save.txt", json);
    }


    public void Load() {
        string saveFilePath = Application.persistentDataPath + "Saves/save.txt";
        if(File.Exists(saveFilePath)) {
            string json = File.ReadAllText(saveFilePath);
            stats = JsonUtility.FromJson<Statistics>(json);
        } else {
            print("Le fichier n'existe pas !");
        }
    }
}
