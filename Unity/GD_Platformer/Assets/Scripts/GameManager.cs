using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    [SerializeField] private GameObject player;
    public GameObject victoryPanel;
    public GameObject pausePanel;
    public bool onPause;
    [SerializeField]public Vector3 spawn = new Vector3(-42.7f, 2.01f, 0.0f);

    public static GameManager Instance()
    {
        return _singleton;
    }

    private static GameManager _singleton;
    
    public int dimension;
    
    // Start is called before the first frame update
    void Start()
    {
        _singleton = this;
        dimension = 0;
        victoryPanel.SetActive(false);
        pausePanel.SetActive(false);
        player.transform.position = spawn;
        onPause = false;
    }

    void Pause() {
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
        onPause = true;
    }

    void Resume() {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
        onPause = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.y < -10.0f) {
            player.transform.position = spawn;
        } 

        if(Input.GetKeyDown(KeyCode.P)) {
            onPause = !onPause;
            if(onPause) {
                Pause();
            } else {    
                Resume();
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
