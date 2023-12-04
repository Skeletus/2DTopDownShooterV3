using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AK47AmmoRecollectable : MonoBehaviour
{
    public AK47AmmoSpawner ammoSpawner; // Referencia al AK47AmmoSpawner
    public int ammoToAdd = 15; // Cantidad de munición de pistola para agregar

    private void Start()
    {
        ammoSpawner = GameObject.FindGameObjectWithTag("AKAmmoSpawner").GetComponent<AK47AmmoSpawner>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Obtener el componente PlayerController del jugador
            PlayerController playerController = collision.GetComponent<PlayerController>();

            if (playerController != null)
            {
                // Obtener el componente AK47 del jugador
                AK47 ak47 = playerController.GetAK47();

                if (ak47 != null)
                {
                    // Agregar munición de AK47 al jugador
                    ak47.AddAmmo(ammoToAdd);

                    // Actualizar la lista de puntos de spawn utilizados en el AK47AmmoSpawner
                    ammoSpawner.UpdateUsedSpawnPoints(transform);

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
}
