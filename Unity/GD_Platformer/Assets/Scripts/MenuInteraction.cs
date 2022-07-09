using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

public class MenuInteraction : MonoBehaviour
{
    [SerializeField] private GameObject loaderCanvas = null;
    [SerializeField] private Image progressBar;
    [SerializeField] private GameObject optionsCanvas = null;
    [SerializeField] private Toggle adminMode = null;
    [SerializeField] private GameObject continuer = null;
    [SerializeField] private SaveLoad save;
    public bool inGame;
    public bool runNewScene;

    private float target;

    public Statistics stats;

    void Start() {
        stats = save.stats;
        loaderCanvas.SetActive(false);
        optionsCanvas.SetActive(false);
        if(inGame == false) {
            if(stats.scenarioLevel1Complete || stats.adminMode) {
                continuer.SetActive(true);
            } else {
                continuer.SetActive(false);
            }
        }
    }

    public async void RunScene(string scenes) {
        runNewScene = true;
        target = 0;
        progressBar.fillAmount = 0;

        var scene = SceneManager.LoadSceneAsync(scenes);
        scene.allowSceneActivation = false;

        loaderCanvas.SetActive(true);
        Time.timeScale = 1f;

        do {
            await Task.Delay(100);
            target = scene.progress;
        } while(scene.progress < 0.90f);

        await Task.Delay(1000);

        if(scenes == "FirstScenario") {
            save.NewGame();
        }
        save.Save();
        scene.allowSceneActivation = true;
        runNewScene = false;
        loaderCanvas.SetActive(false);
    }

    void Update() {

        progressBar.fillAmount = Mathf.MoveTowards(progressBar.fillAmount, target, 3 * Time.deltaTime);

        if(!inGame) {
            if(adminMode.isOn) {
            stats.adminMode = true;
            }

            if(!adminMode.isOn) {
                stats.adminMode = false;
            }
        }
    }

    public void Continuer() {
        if(stats.level1Complete == false) {
            RunScene("Level 0");
        } else if(stats.level1Complete == true && stats.level2Complete == false) {
            RunScene("Level 1");
        }
    }

    public void OpenOption() {
        optionsCanvas.SetActive(true);
    }

    public void CloseOption() {
        save.Save();
        optionsCanvas.SetActive(false);
    }

    public void QuitGame() {
        Application.Quit();
    }

    
    public void RebootTime() {
        Time.timeScale = 1f;
    }
}
