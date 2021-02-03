using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] Projectile projectilePrefab;
    Spawner mySpawner;
    Animator animator;
    [SerializeField][Range(0.1f, 5)] float projectileSpeed = 5;

    private void Start()
    {
        SetLaneSpawner();
        this.animator = GetComponent<Animator>();
    }

    private void SetLaneSpawner()
    {
        Spawner[] spawners = FindObjectsOfType<Spawner>();  
        foreach (Spawner spawner in spawners) {
            if (Mathf.Abs(spawner.transform.position.y - transform.position.y) <= Mathf.Epsilon) {
                mySpawner = spawner;
            }
        } 
    }

     private void Update()
    {
        animator.SetBool("IsAttacking", IsAttackerInLane());
    }

    private bool IsAttackerInLane()
    {
        return mySpawner.transform.childCount > 0;
    }

    public float GetProjectileSpeed() {
        return this.projectileSpeed;
    }

    public void Fire() {
        SpawnProjectile();
    }

    private void SpawnProjectile() {
        Projectile projectile = Instantiate(projectilePrefab, 
        transform.GetChild(0).transform.position, 
        Quaternion.identity) as Projectile;
        projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(projectileSpeed, 0);
        projectile.transform.parent = transform;
    }
}
