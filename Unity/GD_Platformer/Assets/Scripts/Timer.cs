using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField]private TextMeshProUGUI timerText;
    private float startTime;
    private bool finished = false;
    
    void Start() {
        startTime = Time.time;
    }

    void Update() {
        if(finished) {
            return;
        } else {
            float timer = Time.time - startTime;
            string minutes = ((int) timer / 60).ToString();
            string seconds = (timer % 60).ToString("f2");

            timerText.text = minutes + ":" + seconds;
        }
    }

    public void Finish() {
        finished = true;
        timerText.color = Color.green;
    }
}
