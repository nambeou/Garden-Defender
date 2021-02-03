using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] GameObject explosionFX; 

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Attacker>() != null) {
            Epxlode();
        }
    }

    private void Epxlode() {
        GameObject explosion = Instantiate(explosionFX, transform.position, Quaternion.identity);
        Destroy(gameObject);
        Destroy(explosion,0.4f);
    }

}
