using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] bool spawning = true;
    [SerializeField] Attacker[] attackerPrefabs;

    GameTimer gameTimer;
    // Start is called before the first frame update
    void Start()
    {
        gameTimer = FindObjectOfType<GameTimer>();
        StartCoroutine("SpawnAttacker");
    }

    // Update is called once per frame
    void Update()
    {
        if(gameTimer.GetLevelRemainingTime() <= 0) {
            spawning = false;
        }
    }

    IEnumerator SpawnAttacker() {
        while (spawning) {
            FindObjectOfType<LevelController>().IncreaseAttacker();
            int randomIndex = Random.Range(0, this.attackerPrefabs.Length);     
            Attacker attackerToSpawn = attackerPrefabs[randomIndex];
            yield return new WaitForSeconds(Random.Range(0,attackerToSpawn.GetComponent<Attacker>().GetMaxTimeBetweenSpawn()));    
            Attacker newAttacker =  Instantiate(attackerToSpawn,
                transform.position, Quaternion.identity) as Attacker;
            newAttacker.transform.parent = transform;
        }
    }
}
