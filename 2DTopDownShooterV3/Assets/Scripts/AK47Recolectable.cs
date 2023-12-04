using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AK47Recolectable : MonoBehaviour
{
    public PlayerController playerController; // Referencia al script PlayerController

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Activar el AK47 llamando a la función del PlayerController
            playerController.ActivateWeapon();

            // Desactivar el recolectable
            gameObject.SetActive(false);
        }
    }
}
