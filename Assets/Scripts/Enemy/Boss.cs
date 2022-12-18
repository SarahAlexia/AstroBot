using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private GameManager gameManager;
    public float health;
    public float speed;
    private Rigidbody enemyRb;
    public GameObject player;
    public Transform target;
    public float minDist = 0.5f;

    private void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");

    //If no target specified, assume it's the player
        if(target == null)
        {
            if(GameObject.FindWithTag("Player") != null)
            {
                target = GameObject.FindWithTag("Player").GetComponent<Transform>();
            }
        }
    }

    private void Update()
    {
        Vector3 lookDirection = (player.transform.position
        - transform.position).normalized;

        enemyRb.AddForce(lookDirection * speed);

        if(target == null)
            return;
        //Face the player
        transform.LookAt(target);

        float distance = Vector3.Distance(target.position, transform.position);
        
        if(distance > minDist)
            transform.position += transform.forward * speed * Time.deltaTime;
    }

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    //Set the target
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if(health <= 0) Invoke(nameof(DestroyEnemy), .5f);
    }

    void DestroyEnemy()
    {
        Destroy(gameObject);
    }
}
