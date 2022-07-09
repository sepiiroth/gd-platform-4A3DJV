using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public KeyCode jump {get; set;}
    public KeyCode right {get; set;}
    public KeyCode left {get; set;}
    public KeyCode changeDim {get; set;}
    public KeyCode pause {get; set;}
    
    private static GameManager _singleton;
    
    [SerializeField]private SaveLoad save;
    public Statistics stats;

    [SerializeField] private GameObject player;
    public GameObject victoryPanel;
    public GameObject pausePanel;
    public bool onPause;
    [SerializeField]public Vector3 spawn = new Vector3(-42.7f, 2.01f, 0.0f);

    public static GameManager Instance() {
        return _singleton;
    }

    public int dimension;

    public bool inGame;
    
    // Start is called before the first frame update
    void Start() {
        _singleton = this;
        dimension = 0;
        stats = save.stats;
        if(inGame) {
            victoryPanel.SetActive(false);
            pausePanel.SetActive(false);
            player.transform.position = spawn;
            onPause = false;
        }

        jump = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("jumpKey", stats.jump));
        right = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("rightKey", stats.right));
        left = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("leftKey", stats.left));
        changeDim = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("changeDimKey", stats.changeDim));
        pause = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("pauseKey", stats.pause));
        save.Load();
    }

    public void Pause() {
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
        onPause = true;
    }

    public void Resume() {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
        onPause = false;
    }

    // Update is called once per frame
    void Update()
    {   
        if(inGame) {
            if(player.transform.position.y < -10.0f) {
                player.transform.position = spawn;
            } 

            if(Input.GetKeyDown(pause)) {
                onPause = !onPause;
                if(onPause) {
                    Pause();
                } else {    
                    Resume();
                }
            }
        }
    }

    public  void ChangeDimension()
    {
        dimension = (dimension + 1) % 2;
    }

    public int GetDimension()
    {
        return dimension;
    }
}
