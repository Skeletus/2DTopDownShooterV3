using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour
{
    public GameObject bulletPrefab; // Prefab del proyectil
    public Transform firePoint; // Punto de salida del proyectil
    public int bulletDamage = 10; // Daño del proyectil
    public float bulletSpeed = 10f; // Velocidad del proyectil
    public float shootDelay = 0.5f; // Retardo entre disparos
    public int maxBullets = 15; // Cantidad máxima de balas
    public int currentBullets; // Balas restantes


    public Animator animator; // Animator para la animación de disparo
    public AudioSource audioSource; // AudioSource para el sonido de disparo

    public float shootTimer; // Temporizador para controlar el retardo entre disparos

    void Start()
    {
        currentBullets = maxBullets; // Inicializar las balas restantes al máximo
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
        currentBullets = Mathf.Clamp(currentBullets + amount, 0, maxBullets); // Añadir munición asegurándose de no exceder la cantidad máxima
    }

    public void Shoot()
    {
        if (shootTimer <= 0f && currentBullets > 0)
        {
            // Restar una bala disponible
            currentBullets--;

            createBullet();

            // Verificar si se quedó sin balas
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
        // Instanciar el proyectil en la posición y rotación del punto de salida
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // Obtener el componente Rigidbody2D del proyectil
        Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();

        // Aplicar una fuerza al proyectil para que se mueva hacia adelante
        bulletRigidbody.AddForce(firePoint.up * bulletSpeed, ForceMode2D.Impulse);

        // Reproducir la animación de disparo
        if (animator != null)
        {
            animator.SetTrigger("Shoot");
        }

        // Reproducir el sonido de disparo
        if (audioSource != null)
        {
            audioSource.Play();
        }

        // Obtener el componente del script de daño del proyectil
        BulletDamage bulletDamageScript = bullet.GetComponent<BulletDamage>();

        // Configurar el daño del proyectil
        if (bulletDamageScript != null)
        {
            bulletDamageScript.damageAmount = bulletDamage;
        }
    }
    
}
