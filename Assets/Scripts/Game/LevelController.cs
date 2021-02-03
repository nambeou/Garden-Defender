using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] GameObject winLabel;
    [SerializeField] AudioClip winSoundFX;
    [SerializeField] float winLabelDelay = 2;
    PlayableZone playableZone;
    GameTimer gameTimer;
    bool levelFinished = false;
    int attackerRemaining = 0;
    int attackerSpawn = 0;


    // Start is called before the first frame update
    void Start()
    {
        gameTimer = FindObjectOfType<GameTimer>();
        winLabel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!levelFinished) {
            if (gameTimer.GetLevelRemainingTime() == 0 && attackerRemaining == 0) {
                Debug.Log("Level has ended");
                StartCoroutine(ShowWinLabelAndLoadNextScene());
            }
        }
    }

    IEnumerator ShowWinLabelAndLoadNextScene() {
        levelFinished = true;
        winLabel.SetActive(true);
        if (winSoundFX) {
            AudioSource.PlayClipAtPoint(winSoundFX, Camera.main.transform.position, 0.5f);
        }
        yield return new WaitForSeconds(winLabelDelay);
        FindObjectOfType<SceneLoader>().LoadNextScene();
    }

    public void IncreaseAttacker() {
        attackerSpawn++;
        attackerRemaining++;
    }

    public void DecreaseAttacker() {
        attackerRemaining--;
    }
}
