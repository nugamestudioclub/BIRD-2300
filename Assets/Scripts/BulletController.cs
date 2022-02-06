using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField]
    private float lifetime = 5f;
    private float currentLifetime;

    [SerializeField]
    private Rigidbody rigidbody;

    [SerializeField]
    private float speed = 1f;

    public Vector3 direction;
    // Start is called before the first frame update
 
    void Awake()
    {
        currentLifetime = 0;
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

        //deal dmg to enemy

        //if colliding with player

        //deal dmg to player


        //no matter what destroy me
    }

    
}
