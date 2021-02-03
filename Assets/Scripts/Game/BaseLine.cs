using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BaseLine : MonoBehaviour
{
    [SerializeField] GameObject healthDisplay;
    [SerializeField] GameObject heartIcon;
    [SerializeField] int health = 100;

    private void Start()
    {
        DisplayHealth();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        EnemyHit(other.gameObject);
        if (health <= 0) {
            LoadGameOver();
        }
    }

    private void EnemyHit(GameObject enemy) {
        Destroy(enemy);
        if (health > 0) {
            health -= 1;
        }
        heartIcon.GetComponent<Animator>().SetTrigger("Pump");
        DisplayHealth();
    }

    private void DisplayHealth() {
        this.healthDisplay.GetComponent<TextMeshProUGUI>().text = health.ToString();
    }

    private void LoadGameOver() {
        FindObjectOfType<SceneLoader>().LoadGameOver();
    }
}
