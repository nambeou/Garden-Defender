using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    float speed = 2;
    [SerializeField][Range(0.5f, 20)] float maxTimeBetweenSpawns = 10;
    GameObject currentTarget;

    void Update()
    {
        Move();
        UpdateAnimationState();
    }

    private void Move() {
        transform.Translate(Vector2.left * Time.deltaTime * speed);
    }

    private void UpdateAnimationState() {
        if (!currentTarget) {
            GetComponent<Animator>().SetBool("IsAttacking", false);
        }
    }

    public float GetMaxTimeBetweenSpawn() {
        return this.maxTimeBetweenSpawns;
    }

    public void SetMovementSpeed(float newSpeed) {
        this.speed = newSpeed;
    }

    public void Attack(GameObject target){ 
        GetComponent<Animator>().SetBool("IsAttacking", true);
        currentTarget = target;
        currentTarget.GetComponent<Animator>().SetBool("IsAttacked", true);
    }

    private void OnDestroy()
    {
        FindObjectOfType<LevelController>().DecreaseAttacker();
    }
}
