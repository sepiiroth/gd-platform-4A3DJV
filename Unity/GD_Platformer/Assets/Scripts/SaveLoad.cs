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
            Reset();
            Directory.CreateDirectory(dir);
        }

        string json = JsonUtility.ToJson(stats);
        File.WriteAllText(dir + "/save.txt", json);
    }


    public void Load() {
        string saveFilePath = Application.persistentDataPath + "/Saves/save.txt";
        if(File.Exists(saveFilePath)) {
            string json = File.ReadAllText(saveFilePath);
            stats = JsonUtility.FromJson<Statistics>(json);
        } else {
            print("Le fichier n'existe pas !");
        }
    }

    public void Reset() {
        stats.jump = "Space";
        stats.right = "D";
        stats.left= "Q";
        stats.changeDim = "R";
        stats.pause = "P";
        stats.scenarioLevel1Complete = false;
        stats.level1Complete = false;
        stats.wm1level1 = false;
        stats.wm2level1 = false;
        stats.wm3level1 = false;
        stats.timeLevel1 = "00:00";
        stats.scenarioLevel2Complete = false;
        stats.level2Complete = false;
        stats.wm1level2 = false;
        stats.wm2level2 = false;
        stats.wm3level2 = false;
        stats.timeLevel2 = "00:00";
        stats.scenarioLevel3Complete = false;
        stats.level3Complete = false;
        stats.wm1level3 = false;
        stats.wm2level3 = false;
        stats.wm3level3 = false;
        stats.timeLevel3 = "00:00";
        stats.adminMode = false;
    }

    public void NewGame() {
        stats.scenarioLevel1Complete = false;
        stats.level1Complete = false;
        stats.wm1level1 = false;
        stats.wm2level1 = false;
        stats.wm3level1 = false;
        stats.timeLevel1 = "00:00";
        stats.scenarioLevel2Complete = false;
        stats.level2Complete = false;
        stats.wm1level2 = false;
        stats.wm2level2 = false;
        stats.wm3level2 = false;
        stats.timeLevel2 = "00:00";
        stats.scenarioLevel3Complete = false;
        stats.level3Complete = false;
        stats.wm1level3 = false;
        stats.wm2level3 = false;
        stats.wm3level3 = false;
        stats.timeLevel3 = "00:00";
        stats.adminMode = false;
    }
}
