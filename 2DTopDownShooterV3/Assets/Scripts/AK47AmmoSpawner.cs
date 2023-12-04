using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AK47AmmoSpawner : MonoBehaviour
{
    public GameObject ammoPrefab;       // Prefab del objeto de munición de AK47
    public Transform[] spawnPoints;     // Puntos de spawn disponibles

    private List<Transform> usedSpawnPoints = new List<Transform>();   // Lista de puntos de spawn utilizados

    private void Start()
    {
        //SpawnAmmo();
    }

    public void alterAKAmmoPerCase(int caseX)
    {
        AK47AmmoRecollectable ap = ammoPrefab.GetComponent<AK47AmmoRecollectable>();
        if (ap != null)
        {
            if (caseX == 1)
            {
                ap.ammoToAdd = 10;
            }
            if (caseX == 2)
            {
                ap.ammoToAdd = 25;
            }
            if (caseX == 3)
            {
                ap.ammoToAdd = 35;
            }
        }
    }

    public void SpawnAmmo()
    {
        // Verificar si se han utilizado todos los puntos de spawn
        if (usedSpawnPoints.Count == spawnPoints.Length)
        {
            Debug.LogWarning("Se han utilizado todos los puntos de spawn disponibles para el AK47 Ammo.");
            return;
        }

        // Obtener un punto de spawn aleatorio que no se haya utilizado
        Transform spawnPoint = GetRandomSpawnPoint();

        // Spawnear el objeto de munición en el punto de spawn
        Instantiate(ammoPrefab, spawnPoint.position, Quaternion.identity);

        // Agregar el punto de spawn utilizado a la lista
        usedSpawnPoints.Add(spawnPoint);
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
