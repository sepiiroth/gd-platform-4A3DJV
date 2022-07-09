using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Dialogue : MonoBehaviour {

    public TextMeshProUGUI textComponent;
    public string[] lines;
    public Image[] character;
    public float textSpeed;
    [SerializeField] private SaveLoad save;
    public Statistics stats;


    private int index;
    private bool characterAppear = false;

    void Start() {
        textComponent.text = string.Empty;
        ShowCharacter(character[0], false);
        StartDialogue();
        stats = save.stats;
    }

    void Update() {
        if(Input.GetMouseButtonDown(0) && !characterAppear) {
            if(textComponent.text == lines[index]) {
                NextLine();
            } else {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    } 

    void StartDialogue() {
        index = 0;
        StartCoroutine(TypeLine());
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
            default:
                textComponent.color = new Color32(0xFF, 0xFF, 0xFF, 0xFF);
                break;
        }

        if(index == 8) {
            ShowCharacter(character[1], false);
        }

        foreach(char c in lines[index].ToCharArray()) {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine() {
        if(index < lines.Length - 1) {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        } else {
            character[0].gameObject.SetActive(false);
            character[1].gameObject.SetActive(false);
            gameObject.SetActive(false);
            stats.scenarioLevel1Complete = true;
            save.Save();
            SceneManager.LoadScene("Level 0");
        }
    }

    void ShowCharacter(Image a, bool s) {
        StartCoroutine(FadeImage(a, s));
    } 

    IEnumerator FadeImage(Image a, bool fadeAway) {
        characterAppear = true;
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
