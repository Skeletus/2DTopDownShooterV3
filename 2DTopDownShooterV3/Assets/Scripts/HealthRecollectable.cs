using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthRecollectable : MonoBehaviour
{
    public HealthSpawner healthSpawner;
    public int healthToAdd = 15; // Cantidad de vida para agregar

    private void Start()
    {
        healthSpawner = GameObject.FindGameObjectWithTag("HealthRcSpawner").GetComponent<HealthSpawner>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Obtener el componente PlayerController del jugador
            PlayerController playerController = collision.GetComponent<PlayerController>();

            if (playerController != null)
            {
                playerController.addHealth(healthToAdd);

                // Actualizar la lista de puntos de spawn utilizados en el AK47AmmoSpawner
                healthSpawner.UpdateUsedSpawnPoints(transform);

                // Destruir el objeto del recolectable
                Destroy(gameObject);
                /*
                // Desactivar el recolectable
                gameObject.SetActive(false);
                */
            }
        }
    }
}
