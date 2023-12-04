using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Referencia al Transform del personaje a seguir
    public Vector3 offset; // Distancia entre la cámara y el personaje
    public float cameraSpeed = 5f; // Velocidad de movimiento de la cámara
    public float maxDistance = 10f; // Distancia máxima permitida entre la cámara y el personaje

    //private bool cameraUnlocked = false; // Indica si la cámara está desbloqueada

    void LateUpdate()
    {
        if (target != null)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                cameraEnterFreeMode();
            }
            else
            {
                followingPlayer();
            }
        }
    }

    void followingPlayer()
    {
        // Bloquear la cámara y seguir al personaje
        //cameraUnlocked = false;
        transform.position = target.position + offset;
    }

    void cameraEnterFreeMode()
    {
        // Desbloquear la cámara y moverla hacia la posición del puntero del ratón
        //cameraUnlocked = true;
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 cameraTargetPosition = mousePosition;
        float distance = Vector3.Distance(cameraTargetPosition, target.position);

        if (distance > maxDistance)
        {
            Vector3 cameraToTargetDirection = (target.position - cameraTargetPosition).normalized;
            cameraTargetPosition = target.position - cameraToTargetDirection * maxDistance;

            // Ajustar manualmente la coordenada Z de la posición objetivo de la cámara
            cameraTargetPosition.z = transform.position.z;
        }

        transform.position = Vector3.MoveTowards(transform.position, cameraTargetPosition, cameraSpeed * Time.deltaTime);
    }

}
