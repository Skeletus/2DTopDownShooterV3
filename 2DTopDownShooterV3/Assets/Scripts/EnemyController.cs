using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public int damageAmount = 10;

    private Rigidbody2D rb;
    private Transform target;

    public HealthSystem healthSystem;
    public EnemySpawner enemySpawner;
    public ScoreSystem scoreSystem;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        healthSystem = GetComponent<HealthSystem>();
        scoreSystem = GetComponent<ScoreSystem>();
        //target = GameObject.FindGameObjectWithTag("Player").transform;
        enemySpawner = GameObject.FindGameObjectWithTag("Spawner").GetComponent<EnemySpawner>();
    }

    private void Update()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        if (target != null)
        {
            FollowPlayer();
        }
        else
        {
            // Detener el movimiento del enemigo
            rb.velocity = Vector2.zero;
        }

    }

    public void addScore()
    {
        scoreSystem.AddScore();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            HealthSystem playerHealth = collision.gameObject.GetComponent<HealthSystem>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount);
            }
        }
    }

    void FollowPlayer()
    {
        Vector2 direction = target.position - transform.position;
        rb.velocity = direction.normalized * moveSpeed;
    }
}
