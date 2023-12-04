using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolAmmoRecollectable : MonoBehaviour
{
    public PistolAmmoSpawner ammoSpawner;
    public int ammoToAdd = 10; // Cantidad de munición de pistola para agregar

    private void Start()
    {
        ammoSpawner = GameObject.FindGameObjectWithTag("PistolAmmoSpawner").GetComponent<PistolAmmoSpawner>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Obtener el componente PlayerController del jugador
            PlayerController playerController = collision.GetComponent<PlayerController>();

            if (playerController != null)
            {
                // Obtener el componente Pistol del jugador
                Pistol pistol = playerController.GetPistol();

                if (pistol != null)
                {
                    // Agregar munición de pistola al jugador
                    pistol.AddAmmo(ammoToAdd);

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
