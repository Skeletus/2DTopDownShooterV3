using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSpawner : MonoBehaviour
{
    public GameObject healthPrefab;       // Prefab del objeto health recollectable
    public Transform[] spawnPoints;     // Puntos de spawn disponibles
    public float spawnDelay = 2f; // Tiempo de retraso para la generación del objeto de vida

    private List<Transform> usedSpawnPoints = new List<Transform>();   // Lista de puntos de spawn utilizados

    private void Start()
    {
        //SpawnHealthRecollectable();
    }

    public GameObject getHealthPrefab()
    {
        return healthPrefab;
    }

    public void alterHealthAmountPerCase(int caseX)
    {
        HealthRecollectable hr = healthPrefab.GetComponent<HealthRecollectable>();
        if (hr != null) 
        {
            if (caseX == 1) 
            {
                hr.healthToAdd = 15;
            }
            if (caseX == 2)
            {
                hr.healthToAdd = 30;
            }
            if (caseX == 3)
            {
                hr.healthToAdd = 45;
            }
        }
    }

    public void SpawnHealthRecollectable()
    {
        // Verificar si se han utilizado todos los puntos de spawn
        if (usedSpawnPoints.Count == spawnPoints.Length)
        {
            Debug.LogWarning("Se han utilizado todos los puntos de spawn disponibles para el heatlh recollectable.");
            return;
        }

        // Obtener un punto de spawn aleatorio que no se haya utilizado
        Transform spawnPoint = GetRandomSpawnPoint();

        // Spawnear el objeto de munición en el punto de spawn
        Instantiate(healthPrefab, spawnPoint.position, Quaternion.identity);

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
