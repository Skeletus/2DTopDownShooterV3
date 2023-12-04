using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab; // Prefab del proyectil
    public Transform firePoint; // Punto de salida del proyectil
    public int bulletDamage = 10; // Daño del proyectil
    public float bulletSpeed = 10f; // Velocidad del proyectil
    public float shootDelay = 0.5f; // Retardo entre disparos

    public Animator animator; // Animator para la animación de disparo
    public AudioSource audioSource; // AudioSource para el sonido de disparo

    private float shootTimer; // Temporizador para controlar el retardo entre disparos

    void Update()
    {
        // Actualizar el temporizador de disparo
        shootTimer -= Time.deltaTime;

        // Detectar el input de disparo
        if (Input.GetButtonDown("Fire1") && shootTimer <= 0f)
        {
            Shoot();
            shootTimer = shootDelay;
        }
    }

    public void Shoot()
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
