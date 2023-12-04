using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour
{
    public GameObject bulletPrefab; // Prefab del proyectil
    public Transform firePoint; // Punto de salida del proyectil
    public int bulletDamage = 10; // Da�o del proyectil
    public float bulletSpeed = 10f; // Velocidad del proyectil
    public float shootDelay = 0.5f; // Retardo entre disparos
    public int maxBullets = 15; // Cantidad m�xima de balas
    public int currentBullets; // Balas restantes


    public Animator animator; // Animator para la animaci�n de disparo
    public AudioSource audioSource; // AudioSource para el sonido de disparo

    public float shootTimer; // Temporizador para controlar el retardo entre disparos

    void Start()
    {
        currentBullets = maxBullets; // Inicializar las balas restantes al m�ximo
    }

    private void Update()
    {
        shootTimer -= Time.deltaTime;
    }

    public int getCurrenBullets()
    {
        return currentBullets;
    }

    public void AddAmmo(int amount)
    {
        currentBullets = Mathf.Clamp(currentBullets + amount, 0, maxBullets); // A�adir munici�n asegur�ndose de no exceder la cantidad m�xima
    }

    public void Shoot()
    {
        if (shootTimer <= 0f && currentBullets > 0)
        {
            // Restar una bala disponible
            currentBullets--;

            createBullet();

            // Verificar si se qued� sin balas
            if (currentBullets == 0)
            {
                // Deshabilitar el disparo
                enabled = false;
            }

            shootTimer = shootDelay;
        }
    }

    public void createBullet()
    {
        // Instanciar el proyectil en la posici�n y rotaci�n del punto de salida
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // Obtener el componente Rigidbody2D del proyectil
        Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();

        // Aplicar una fuerza al proyectil para que se mueva hacia adelante
        bulletRigidbody.AddForce(firePoint.up * bulletSpeed, ForceMode2D.Impulse);

        // Reproducir la animaci�n de disparo
        if (animator != null)
        {
            animator.SetTrigger("Shoot");
        }

        // Reproducir el sonido de disparo
        if (audioSource != null)
        {
            audioSource.Play();
        }

        // Obtener el componente del script de da�o del proyectil
        BulletDamage bulletDamageScript = bullet.GetComponent<BulletDamage>();

        // Configurar el da�o del proyectil
        if (bulletDamageScript != null)
        {
            bulletDamageScript.damageAmount = bulletDamage;
        }
    }
    
}
