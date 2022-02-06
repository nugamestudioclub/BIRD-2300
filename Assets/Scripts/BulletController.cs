using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField]
    private float lifetime = 5f;
    private float currentLifetime;

    private Rigidbody rigidbody;
    private Animator animator;

    [SerializeField]
    private float speed = 1f;
    [SerializeField]
    private int damage = 5;

    public Vector3 direction;

    private bool isExploding = false;

    void Awake()
    {
        currentLifetime = 0;
        rigidbody = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
    }

 

    // Update is called once per frame
    void Update()
    {
        if (currentLifetime > lifetime)
        {
            Destroy(gameObject);
        }
        //keep moving
        rigidbody.velocity = direction * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        //if colliding with enemy
        if (collision.TryGetComponent(out EnemyAI enemy))
        {
            //deal dmg to enemy
            enemy.TakeDamage(damage);
        }
        

        //if colliding with player

        //deal dmg to player


        //no matter what destroy me
    }

    private void Explode()
    {
        //play explosion animation
        animator.Play("explode");
        //play explosion sound

        //start exploding
        isExploding = true;
    }

}
