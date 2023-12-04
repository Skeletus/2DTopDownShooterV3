using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    private Pistol pistol; // Referencia al script Pistol
    private AK47 ak47; // Referencia al script AK47
    private PlayerController playerController;
    public Sprite pistolSprite; // Sprite de la pistola
    public Sprite ak47Sprite; // Sprite del AK47

    private bool isPistolEquipped; // Indica si la pistola está equipada actualmente

    private void Start()
    {
        playerController = GetComponent<PlayerController>();    
        pistol = GetComponent<Pistol>(); // Obtener referencia al script Pistol
        ak47 = GetComponent<AK47>(); // Obtener referencia al script AK47

        isPistolEquipped = true; // Inicialmente, la pistola está equipada

        // Desactivar el script AK47 y activar el script Pistol
        ak47.enabled = false;
        pistol.enabled = true;
    }

    private void Update()
    {
        changeWeapon();
        shootWeapon();
    }

    public void changeWeapon()
    {
        // Cambiar de arma al presionar la tecla E
        if (Input.GetKeyDown(KeyCode.E))
        {
            //verifica si tienes acceso al ak47
            if(playerController.ak47Activated)
            {
                // Si la pistola está equipada, cambiar a AK47
                // Si AK47 está equipada, cambiar a pistola
                isPistolEquipped = !isPistolEquipped;

                if (isPistolEquipped)
                {
                    // Desactivar el script AK47 y activar el script Pistol
                    ak47.enabled = false;
                    pistol.enabled = true;
                    // Cambiar el sprite del jugador a la pistola
                    playerController.GetComponent<SpriteRenderer>().sprite = pistolSprite;
                }
                else
                {
                    // Desactivar el script Pistol y activar el script AK47
                    pistol.enabled = false;
                    ak47.enabled = true;
                    // Cambiar el sprite del jugador al AK47
                    playerController.GetComponent<SpriteRenderer>().sprite = ak47Sprite;
                }
            }

        }
    }

    public void shootWeapon()
    {
        // Disparar al presionar el botón de disparo (por ejemplo, clic izquierdo)
        if (isPistolEquipped)
        {
            // Detectar el input de disparo
            if (Input.GetButtonDown("Fire1") && pistol.shootTimer <= 0f)
            {
                pistol.Shoot();
            }

        }
        else
        {
            // Verificar si se presiona o se suelta el botón de disparo para el AK47
            if (Input.GetButtonDown("Fire1"))
            {
                ak47.StartFiring();
            }
            else if (Input.GetButtonUp("Fire1"))
            {
                ak47.StopFiring();
            }
            
            if (ak47.isFiring)
            {

                if (ak47.shootTimer <= 0f && ak47.currentBullets > 0)
                {
                    ak47.Shoot();
                }
            }
            
        }
    }
}
