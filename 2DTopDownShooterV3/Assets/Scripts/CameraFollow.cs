using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Referencia al Transform del personaje a seguir
    public Vector3 offset; // Distancia entre la c�mara y el personaje
    public float cameraSpeed = 5f; // Velocidad de movimiento de la c�mara
    public float maxDistance = 10f; // Distancia m�xima permitida entre la c�mara y el personaje

    //private bool cameraUnlocked = false; // Indica si la c�mara est� desbloqueada

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
        // Bloquear la c�mara y seguir al personaje
        //cameraUnlocked = false;
        transform.position = target.position + offset;
    }

    void cameraEnterFreeMode()
    {
        // Desbloquear la c�mara y moverla hacia la posici�n del puntero del rat�n
        //cameraUnlocked = true;
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 cameraTargetPosition = mousePosition;
        float distance = Vector3.Distance(cameraTargetPosition, target.position);

        if (distance > maxDistance)
        {
            Vector3 cameraToTargetDirection = (target.position - cameraTargetPosition).normalized;
            cameraTargetPosition = target.position - cameraToTargetDirection * maxDistance;

            // Ajustar manualmente la coordenada Z de la posici�n objetivo de la c�mara
            cameraTargetPosition.z = transform.position.z;
        }

        transform.position = Vector3.MoveTowards(transform.position, cameraTargetPosition, cameraSpeed * Time.deltaTime);
    }

}
