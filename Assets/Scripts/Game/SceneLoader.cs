using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadToMainMenu() {
        StartCoroutine(LoadSceneWithDelay("MainMenu", 0.5f));
    }

    public void LoadGame() {
        StartCoroutine(LoadSceneWithDelay("Level1", 0.5f));
    }

    public void QuitGame() {
        Application.Quit();
    }

    public void LoadGameOver() {
        StartCoroutine(LoadSceneWithDelay("GameOver", 2));
    }
    public void LoadNextScene() {
        StartCoroutine(LoadSceneWithDelay(SceneManager.GetActiveScene().buildIndex + 1, 2));
    }

    IEnumerator LoadSceneWithDelay(string sceneName, float delayInSeconds) {
        yield return new WaitForSeconds(delayInSeconds);
        SceneManager.LoadScene(sceneName);
    }
    IEnumerator LoadSceneWithDelay(int index, float delayInSeconds) {
        yield return new WaitForSeconds(delayInSeconds);
        SceneManager.LoadScene(index);
    }
}
