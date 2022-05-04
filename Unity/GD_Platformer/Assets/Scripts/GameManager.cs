using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
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
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
