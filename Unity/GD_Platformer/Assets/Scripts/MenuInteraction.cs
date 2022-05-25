using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInteraction : MonoBehaviour
{
    public void RunScene(string scene) {
        SceneManager.LoadScene(scene);
    }

    public void QuitGame() {
        Application.Quit();
    }
}
