using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    public int damageAmount = 10; // Cantidad de daño que inflige el proyectil

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Obtener el componente de salud del objeto colisionado
        HealthSystem health = collision.gameObject.GetComponent<HealthSystem>();

        // Verificar si el objeto tiene un componente de salud
        if (health != null)
        {
            // Infligir daño al objeto
            health.TakeDamage(damageAmount);
        }
        

        // Destruir el proyectil al colisionar con cualquier objeto
        Destroy(gameObject);
    }
}
