using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerInput : MonoBehaviour
{
    public GameObject victory;
    [SerializeField]private PlayerMovement playerMov;
    [SerializeField]private TextMeshProUGUI timerGame;
    [SerializeField]private GameObject WT1;
    [SerializeField]private GameObject WT2;
    [SerializeField]private GameObject WT3;
    [SerializeField]private TextMeshProUGUI finalTimer;
    [SerializeField] private SaveLoad save;
    public Statistics stats;


    void OnTriggerEnter(Collider other) {
        if(other.transform.tag == "Victory") {
            victory.SetActive(true);
            Time.timeScale = 0f;
            if(playerMov.WT1 == true) {
                WT1.SetActive(true);
            }
            if(playerMov.WT2 == true) {
                WT2.SetActive(true);
            }
            if(playerMov.WT3 == true) {
                WT3.SetActive(true);
            }
            finalTimer.text = timerGame.text;
            SetStats();
            save.Save();
        }
    }

    void SetStats() {
        stats = save.stats;
        Scene scene = SceneManager.GetActiveScene();
        if(scene.name == "Level 0") {

            if(playerMov.WT1 == true) {
                stats.wm1level1 = true;
            }
            if(playerMov.WT2 == true) {
                stats.wm2level1 = true;
            }
            if(playerMov.WT3 == true) {
                stats.wm3level1 = true;
            }   
            stats.timeLevel1 = CompareTime(finalTimer.text, stats.timeLevel1);
            stats.level1Complete = true;
        }

        if(scene.name == "Level 1") {
            if(playerMov.WT1 == true) {
                stats.wm1level2 = true;
            }
            if(playerMov.WT2 == true) {
                stats.wm2level2 = true;
            }
            if(playerMov.WT3 == true) {
                stats.wm3level2 = true;
            }
            stats.timeLevel2 = CompareTime(finalTimer.text, stats.timeLevel2);
            stats.level2Complete = true;
        }

        if(scene.name == "Level 2") {
            if(playerMov.WT1 == true) {
                stats.wm1level3 = true;
            }
            if(playerMov.WT2 == true) {
                stats.wm2level3 = true;
            }
            if(playerMov.WT3 == true) {
                stats.wm3level3 = true;
            }
            stats.timeLevel3 = CompareTime(finalTimer.text, stats.timeLevel2);
            stats.level3Complete = true;
        }
    }

    string CompareTime(string time, string timeOnSave) {

        string[] splitTime = time.Split(char.Parse(":"));
        string[] splitTime2 = timeOnSave.Split(char.Parse(":"));

        string newTime = splitTime[0] + ":" + Math.Ceiling(float.Parse(splitTime[1])).ToString();
        string newTime2 = splitTime2[0] + ":" + Math.Ceiling(float.Parse(splitTime2[1])).ToString();

        var t1 = TimeSpan.Parse(newTime);
        var t2 = TimeSpan.Parse(newTime2);
        if(t1 > t2) {
            return newTime;
        } else {
            return newTime2;
        }
    }
}
