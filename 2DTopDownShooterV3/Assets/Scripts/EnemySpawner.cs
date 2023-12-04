using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;  // Prefab del enemigo a spawnear
    public Transform[] spawnPoints; // Array de puntos de spawn

    public float spawnInterval = 2f; // Intervalo de tiempo entre cada spawn
    public int maxEnemies = 5;      // Máximo número de enemigos a spawnear

    public int currentEnemies = 0; // Contador de enemigos actuales
    public int enemiesKilled = 0; // Contador de enemigos killed by player

    private void Start()
    {
        // Comenzar la rutina de spawn
        StartCoroutine(SpawnEnemies());
    }

    public IEnumerator SpawnEnemies()
    {
        while (currentEnemies < maxEnemies)
        {
            // Esperar el intervalo de tiempo
            yield return new WaitForSeconds(spawnInterval);

            // Obtener un punto de spawn aleatorio
            Transform spawnPoint = GetRandomSpawnPoint();

            // Spawnear el enemigo en el punto de spawn
            Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);

            // Incrementar el contador de enemigos
            currentEnemies++;
        }
    }

    private Transform GetRandomSpawnPoint()
    {
        // Obtener un índice aleatorio para seleccionar un punto de spawn
        int randomIndex = Random.Range(0, spawnPoints.Length);

        // Devolver el punto de spawn correspondiente al índice aleatorio
        return spawnPoints[randomIndex];
    }
}
