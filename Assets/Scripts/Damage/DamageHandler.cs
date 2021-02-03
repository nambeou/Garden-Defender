using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHandler : MonoBehaviour
{
    [SerializeField] AudioClip dyingSound;
    [SerializeField] GameObject deathAnimation;
    [SerializeField] float deathDelay = 0.4f;
    [SerializeField] int health = 100;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<DamageDealer>() != null) {
            HandleDamage(other.gameObject.GetComponent<DamageDealer>());
        }
    }

    private void HandleDamage(DamageDealer damageDealer) {
        DeductHealth(damageDealer.GetDamage());
        if (health <= 0) {
            Die();
        }
    }

    public void DeductHealth(int amount) {
        this.health -= amount;
    }

    private void Die() {
        PlayDeathAnimatioon();
        Destroy(gameObject, deathDelay/2);
        PlayDyingSoundPlayDyingSound();
    }

    private void PlayDeathAnimatioon() {
        if (deathAnimation != null) {
            GameObject deathFX = Instantiate(deathAnimation, transform.position, Quaternion.identity);
            Destroy(deathFX, deathDelay);
        }
    }

    private void PlayDyingSoundPlayDyingSound() {
        if (dyingSound != null) {
            AudioSource.PlayClipAtPoint(dyingSound, Camera.main.transform.position, 0.2f);
        }
    }

    public int GetHealth() {
        return health;
    }
}
