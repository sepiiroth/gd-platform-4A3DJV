using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomWord : MonoBehaviour
{
    [SerializeField]private GameObject player;
    [SerializeField]private GameObject pixel;

    void Start() {
        InvokeRepeating("SpawnPixel", 0.0f, 0.1f);
    }

    void SpawnPixel() {
        if(GameManager.Instance().dimension == 0) {
            Instantiate(pixel, new Vector3(player.transform.position.x + Random.Range(-97, 97), player.transform.position.y + Random.Range(-77, 77), player.transform.position.z + 80), Quaternion.identity);
        } else if(GameManager.Instance().dimension == 1) {
            Instantiate(pixel, new Vector3(player.transform.position.x + 80, player.transform.position.y + Random.Range(-77, 77), player.transform.position.z + Random.Range(-97, 97)), Quaternion.Euler(new Vector3(0,90,0)));
        }

        var pixels = GameObject.FindGameObjectsWithTag("Pixel");
        if(pixels.Length > 150) {
            DestroyAllPixels();
        }
    }


    void DestroyAllPixels() {
        var pixels = GameObject.FindGameObjectsWithTag("Pixel");
        for(var i = 0 ; i < pixels.Length/2 ; i ++){
            Destroy(pixels[i]);
        }
    }
}
