using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChangeTouchMenu : MonoBehaviour
{
    [SerializeField]private SaveLoad save;
    public Statistics stats;

    [SerializeField]TextMeshProUGUI[] buttons;
    Event keyEvent;
    TextMeshProUGUI buttonText;
    KeyCode newKey;

    bool waitingForKey;

    void Start() {
        waitingForKey = false;
        buttons[0].text = GameManager.Instance().jump.ToString();
        buttons[1].text = GameManager.Instance().right.ToString();
        buttons[2].text = GameManager.Instance().left.ToString();
        buttons[3].text = GameManager.Instance().changeDim.ToString();
        buttons[4].text = GameManager.Instance().pause.ToString();

        stats = save.stats;
    }

    void Update() {
        
    } 

    void OnGUI() {
        keyEvent = Event.current;

        if(keyEvent.isKey && waitingForKey) {
            newKey = keyEvent.keyCode;
            waitingForKey = false;
        }
    }

    public void StartAssignment(string keyName) {
        if(!waitingForKey) {
            StartCoroutine(AssignKey(keyName));
        }
    }

    public void SendText(TextMeshProUGUI text) {
        buttonText = text;
    }

    IEnumerator WaitForKey() {
        while(!keyEvent.isKey) {
            yield return null;
        }
    }

    public IEnumerator AssignKey(string keyName) {
        waitingForKey = true;

        yield return WaitForKey();

        switch(keyName) {
            case "jump":
                GameManager.Instance().jump = newKey;
                stats.jump = GameManager.Instance().jump.ToString();
                buttonText.text = GameManager.Instance().jump.ToString();
                PlayerPrefs.SetString("jumpKey", GameManager.Instance().jump.ToString());
                break;
            case "right":
                GameManager.Instance().right = newKey;
                stats.right = GameManager.Instance().right.ToString();
                buttonText.text = GameManager.Instance().right.ToString();
                PlayerPrefs.SetString("rightKey", GameManager.Instance().right.ToString());
                break;
            case "left":
                GameManager.Instance().left = newKey;
                stats.left = GameManager.Instance().left.ToString();
                buttonText.text = GameManager.Instance().left.ToString();
                PlayerPrefs.SetString("leftKey", GameManager.Instance().left.ToString());
                break;
            case "changeDim":
                GameManager.Instance().changeDim = newKey;
                stats.changeDim = GameManager.Instance().changeDim.ToString();
                buttonText.text = GameManager.Instance().changeDim.ToString();
                PlayerPrefs.SetString("changeDimKey", GameManager.Instance().changeDim.ToString());
                break;
            case "pause":
                GameManager.Instance().pause = newKey;
                stats.pause = GameManager.Instance().pause.ToString();
                buttonText.text = GameManager.Instance().pause.ToString();
                PlayerPrefs.SetString("pauseKey", GameManager.Instance().pause.ToString());
                break;
        }

        yield return null;
    }
}
