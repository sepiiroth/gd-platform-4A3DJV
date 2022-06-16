using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Apri : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public Image[] character;
    public float textSpeed;

    private int index;
    private bool characterAppear = false;
    private bool triggerWithPlayer = false;
    private bool onDialog = false;

    public GameObject E;
    public GameObject DialogueBox;

    void Start() {
        textComponent.text = string.Empty;
        E.SetActive(false);
        DialogueBox.SetActive(false);
    }

    void Update() {
        if(triggerWithPlayer && onDialog != true) {
            if(Input.GetKeyDown(KeyCode.E)) {
                DialogueBox.SetActive(true);
                textComponent.text = string.Empty;
                ShowCharacter(character[0], false);
                ShowCharacter(character[1], false);
                onDialog = true;
                StartDialogue();
            }
        }

        if(!triggerWithPlayer && onDialog) {
            StopDialog();
        }

        if(onDialog) {
            if(Input.GetMouseButtonDown(0) && !characterAppear) {
                if(textComponent.text == lines[index]) {
                    NextLine();
                } else {
                    StopAllCoroutines();
                    textComponent.text = lines[index];
                }
            }
        }
    }

    void OnTriggerEnter(Collider target) {
        if(target.tag == "Player") {
            E.SetActive(true);
            triggerWithPlayer = true;
        }
    }

    void OnTriggerExit(Collider target) {
        if(target.tag == "Player") {
            E.SetActive(false);
            triggerWithPlayer = false;
        }
    }

    void StartDialogue() {
        index = 0;
        StartCoroutine(TypeLine());
    }

    void NextLine() {
        if(index < lines.Length - 1) {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        } else {
            StopDialog();
        }
    }

    void StopDialog() {
        character[0].gameObject.SetActive(false);
        character[1].gameObject.SetActive(false);
        DialogueBox.SetActive(false);
        onDialog = false;
    }


    IEnumerator TypeLine() {
        switch(lines[index][0]) {
            case 'A':
                textComponent.color = new Color32(0x97, 0xF3, 0xAE, 0xFF);
                lines[index] = lines[index].Remove(0, 1);
                break;
            case 'J':
                textComponent.color = new Color32(0xF3, 0xE9, 0x97, 0xFF);
                lines[index] = lines[index].Remove(0, 1);
                break;
            case 'I':
                textComponent.color = new Color32(0xFF, 0x0D, 0x00, 0xFF);
                lines[index] = lines[index].Remove(0, 1);
                break;
            case 'B':
                textComponent.color = new Color32(0x4D, 0x92, 0xC3, 0xFF);
                lines[index] = lines[index].Remove(0, 1);
                break;
            default:
                textComponent.color = new Color32(0xFF, 0xFF, 0xFF, 0xFF);
                break;
        }

        foreach(char c in lines[index].ToCharArray()) {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void ShowCharacter(Image a, bool s) {
        StartCoroutine(FadeImage(a, s));
    } 

    IEnumerator FadeImage(Image a, bool fadeAway) {
        characterAppear = true;
        a.gameObject.SetActive(true);
        if (fadeAway) {
            for (float i = 1; i >= 0; i -= Time.deltaTime) {
                a.color = new Color(1, 1, 1, i);
                yield return null;
            }
        } else {
            for (float i = 0; i <= 1; i += Time.deltaTime) {
                a.color = new Color(1, 1, 1, i);
                yield return null;
            }
        }
        characterAppear = false;
    }
}
