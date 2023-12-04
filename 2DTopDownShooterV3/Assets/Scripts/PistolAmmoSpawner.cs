using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolAmmoSpawner : MonoBehaviour
{
    public GameObject ammoPrefab;       // Prefab del objeto de munición de Pistol
    public Transform[] spawnPoints;     // Puntos de spawn disponibles
    private Transform recollectableSpawnPoint;

    private List<Transform> usedSpawnPoints = new List<Transform>();   // Lista de puntos de spawn utilizados

    private void Start()
    {
        //SpawnAmmo();
    }

    public void alterPistolAmmoPerCase(int caseX)
    {
        PistolAmmoRecollectable pr = ammoPrefab.GetComponent<PistolAmmoRecollectable>();
        if (pr != null)
        {
            if (caseX == 1)
            {
                pr.ammoToAdd = 6;
            }
            if (caseX == 2)
            {
                pr.ammoToAdd = 9;
            }
            if (caseX == 3)
            {
                pr.ammoToAdd = 12;
            }
        }
    }

    public void SpawnAmmo()
    {
        // Verificar si se han utilizado todos los puntos de spawn
        if (usedSpawnPoints.Count == spawnPoints.Length)
        {
            Debug.LogWarning("Se han utilizado todos los puntos de spawn disponibles para la Pistol Ammo.");
            return;
        }

        // Obtener un punto de spawn aleatorio que no se haya utilizado
        Transform spawnPoint = GetRandomSpawnPoint();
        recollectableSpawnPoint = spawnPoint;

        // Spawnear el objeto de munición en el punto de spawn
        Instantiate(ammoPrefab, spawnPoint.position, Quaternion.identity);

        // Agregar el punto de spawn utilizado a la lista
        usedSpawnPoints.Add(spawnPoint);
    }

    public Transform getRecollectableSpawnPoint()
    {
        return recollectableSpawnPoint;
    }

    private Transform GetRandomSpawnPoint()
    {
        // Obtener un índice aleatorio para seleccionar un punto de spawn no utilizado
        int randomIndex;
        Transform spawnPoint;

        do
        {
            randomIndex = Random.Range(0, spawnPoints.Length);
            spawnPoint = spawnPoints[randomIndex];
        } while (usedSpawnPoints.Exists(sp => sp.position == spawnPoint.position));

        return spawnPoint;
    }

    public void UpdateUsedSpawnPoints(Transform spawnPoint)
    {
        usedSpawnPoints.RemoveAll(sp => sp.position == spawnPoint.position);
    }
}
