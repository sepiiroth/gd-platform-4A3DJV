using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    [SerializeField] private GameObject player;
    public GameObject victoryPanel;
    private Vector3 spawn = new Vector3(-42.7f, 2.01f, 0.0f);

    public static GameManager Instance()
    {
        return _singleton;
    }

    private static GameManager _singleton;
    
    private int dimension;
    
    // Start is called before the first frame update
    void Start()
    {
        _singleton = this;
        dimension = 0;
        victoryPanel.SetActive(false);
        player.transform.position = spawn;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.y < -10.0f) {
            player.transform.position = spawn;
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
