using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour
{
    private void TriggerJump() {
        GetComponent<Animator>().SetTrigger("JumpTrigger");
    }  
      
    private void TriggerAttack(GameObject otherObject) {
        GetComponent<Attacker>().Attack(otherObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject otherObject = other.gameObject;
        if (otherObject.GetComponent<Defender>()) {
            if (otherObject.GetComponent<Defender>().IsShieldDefender()) {
                TriggerJump();
            } else {
                TriggerAttack(otherObject);
            }
        }
    }
    
}
