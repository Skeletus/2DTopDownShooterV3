using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public int maxHealth = 100; // Salud máxima
    public int currentHealth; // Salud actual
    public GameController gc;

    private void Start()
    {
        gc = GameObject.FindGameObjectWithTag("GControler").GetComponent<GameController>();
        currentHealth = maxHealth; // Establecer la salud actual a la salud máxima al inicio
    }

    public int getMaxHealth()
    {
        return maxHealth;
    }

    public int getCurrentHealth()
    {
        Debug.Log("Returning current health:" + currentHealth);
        return currentHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount; // Restar el daño a la salud actual
        
        if (IsDead())
        {
            Die(); // El personaje/enemigo ha muerto
        }
    }

    public void Heal(int healAmount)
    {
        currentHealth += healAmount; // Sumar la cantidad de curación a la salud actual

        // Asegurarse de que la salud actual no exceda la salud máxima
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    public bool IsDead()
    {
        return currentHealth <= 0; // Devolver verdadero si la salud actual es menor o igual a cero
    }

    private void Die()
    {
        PlayerController playerController = GetComponent<PlayerController>();
        

        if (playerController != null)
        {
            // El objeto que murió es el jugador
            // Agrega aquí la lógica específica para la muerte del jugador
            playerController.desactivatePlayerController();
            gc.loadGameOverScreen();
        }
        else
        {
            // El objeto que murió es un enemigo
            // Agrega aquí la lógica específica para la muerte de los enemigos

            // Asegurarse de tener una referencia válida al ScoreSystem
            if (gc != null)
            {
                gc.addScoreToPlayer();
            }

            EnemySpawner enemySpawner = GameObject.FindGameObjectWithTag("Spawner").GetComponent<EnemySpawner>();
            enemySpawner.enemiesKilled++;
            Destroy(gameObject);
        }
    }
}
