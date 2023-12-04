using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public EnemySpawner enemySpawner; // Referencia al EnemySpawner
    public AK47AmmoSpawner ak47AmmoSpawner;
    public PistolAmmoSpawner pistolAmmoSpawner;
    public HealthSpawner healthSpawner;
    public IAController Iacontroller;
    public int initialWave = 0; // Oleada inicial
    public int enemiesPerWaveIncrement = 2; // Incremento de enemigos por oleada
    public int enemyHealthIncrement = 5; // Incremento de vida de los enemigos por oleada

    public int AK47AmmoQuantity = 1;
    public int PistolAmmoQuantity = 1;
    public int HealthRecollectableQuantity = 1;


    public int currentWave; // Oleada actual

    private void Start()
    {
        Iacontroller = GetComponent<IAController>();
        currentWave = initialWave;
        StartNextWave();
    }

    private void StartNextWave()
    {
        
        // Incrementar el número de enemigos y la vida de los enemigos
        enemySpawner.maxEnemies += enemiesPerWaveIncrement;
        Debug.Log("CURRENT WAVE BEFORE IF: " + currentWave);
        if (currentWave == 0)
        {
            enemySpawner.enemyPrefab.GetComponent<HealthSystem>().maxHealth = 10;
            Debug.Log("ENEMY BASE HEATLH: " + enemySpawner.enemyPrefab.GetComponent<HealthSystem>().maxHealth);
        }
        if (currentWave != 0)
        {
            enemySpawner.enemyPrefab.GetComponent<HealthSystem>().maxHealth += enemyHealthIncrement;
            Debug.Log("ENEMY HEATLH: " + enemySpawner.enemyPrefab.GetComponent<HealthSystem>().maxHealth);
        }

        // Iniciar el spawner de enemigos
        StartCoroutine(StartSpawner());
        // iniciar el controlador de ia para el spawn de items recolectables
        Iacontroller.chekingPlayerAKAmmoStatusV2();
        Iacontroller.chekingPlayerHealthStatusV2();
        Iacontroller.chekingPlayerPistolStatusV2();

        // Incrementar el número de oleada
        currentWave++;
        Debug.Log("CURRENT WAVE AFTER IF: " + currentWave);
    }

    private IEnumerator StartSpawner()
    {
        while (enemySpawner.currentEnemies < enemySpawner.maxEnemies)
        {
            yield return null;
        }

        // Esperar hasta que se hayan destruido todos los enemigos
        while (enemySpawner.enemiesKilled < enemySpawner.maxEnemies)
        {
            yield return null;
        }

        // Reiniciar el contador de enemigos muertos
        enemySpawner.currentEnemies = 0;
        enemySpawner.enemiesKilled = 0;

        // Iniciar la siguiente oleada después de un breve retraso
        yield return new WaitForSeconds(2f);

        // Spawnear la próxima oleada de enemigos
        StartCoroutine(enemySpawner.SpawnEnemies());

        StartNextWave();
    }

    public int getCurrentWave()
    {
        return currentWave;
    }

    public void SpawnAK47Ammo()
    {
        for (int i = 0; i < AK47AmmoQuantity; i++)
        {
            ak47AmmoSpawner.SpawnAmmo();
        }
    }
    public void SpawnPistolAmmo()
    {
        for (int i = 0; i < PistolAmmoQuantity; i++)
        {
            pistolAmmoSpawner.SpawnAmmo();
        }
    }
    public void SpawnHealthRecollectable()
    {
        for (int i = 0; i < HealthRecollectableQuantity; i++)
        {
            healthSpawner.SpawnHealthRecollectable();
        }
    }
}
