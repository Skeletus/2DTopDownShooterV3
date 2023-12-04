using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AIState
{
    Idle,
    LowHealth,
    LowAKAmmo,
    LowPistolAmmo,
    mediuamAKammo,
    mediuamPistolAmmo,
    mediuamHealth,
    highAKAmmo,
    highPistolAmmo,
    highHealth,
}

public class IAController : MonoBehaviour
{
    public WaveManager waveManager;
    public HealthSpawner healthSpawner;
    public AK47AmmoSpawner ak47AmmoSpawner;
    public PistolAmmoSpawner pistolAmmoSpawner;
    public AK47 ak47;
    public Pistol pistol;
    public HealthSystem healthSystemPlayer;
    public ScoreSystem scoreSystem;

    public int currentAK47Ammo;
    public int currentPistolAmmo;
    public int currentPlayerHealth;

    public int lowHealthParameter;
    public int lowAmmoAK47Parameter;
    public int lowAmmoPistolParameter;

    public int mediumHealthParameter;
    public int mediumAmmoAK47Parameter;
    public int mediumAmmoPistolParameter;

    public int highHealthParameter;
    public int highAmmoAK47Parameter;
    public int highAmmoPistolParameter;

    public AIState currentState;

    private void Start()
    {
        waveManager = GetComponent<WaveManager>();
        scoreSystem = GetComponent<ScoreSystem>();
        currentAK47Ammo = ak47.getCurrenBullets();
        currentPistolAmmo = pistol.getCurrenBullets();
        currentPlayerHealth = healthSystemPlayer.getCurrentHealth();

        // Inicializar el estado inicial
        currentState = AIState.Idle;
    }

    public void chekingPlayerAKAmmoStatusV2()
    {
        currentAK47Ammo = ak47.getCurrenBullets();
        currentState = AIState.Idle;
        switch (currentState)
        {
            case AIState.Idle:
                // Verificar las condiciones para cambiar de estado
                if (0 < currentAK47Ammo && currentAK47Ammo <= lowAmmoAK47Parameter)
                {
                    currentState = AIState.LowAKAmmo;
                }
                else if (lowAmmoAK47Parameter < currentAK47Ammo && currentAK47Ammo <= mediumAmmoAK47Parameter)
                {
                    currentState = AIState.mediuamAKammo;
                }
                else if (currentAK47Ammo == highAmmoAK47Parameter)
                {
                    currentState = AIState.highAKAmmo;
                }
                break;
        }
        switch (currentState)
        {
            case AIState.LowAKAmmo:
                // Ejecutar el comportamiento del estado de baja ammo de AK47
                spawnAKammoFirstCondition();
                break;

            case AIState.mediuamAKammo:
                // Ejecutar el comportamiento del estado de medio ammo de AK47
                spawnAKammoSecondCondition();
                break;

            case AIState.highAKAmmo:
                // Ejecutar el comportamiento del estado de alto ammo de AK47
                // El jugador esta estable
                break;
        }
    }

    public void chekingPlayerHealthStatusV2()
    {
        currentPlayerHealth = healthSystemPlayer.getCurrentHealth();
        currentState = AIState.Idle;
        switch (currentState)
        {
            case AIState.Idle:
                // Verificar las condiciones para cambiar de estado
                if (0 < currentPlayerHealth  && currentPlayerHealth <= lowHealthParameter)
                {
                    currentState = AIState.LowHealth;
                }
                else if (lowHealthParameter < currentPlayerHealth && currentPlayerHealth <= mediumHealthParameter)
                {
                    currentState = AIState.mediuamHealth;
                }
                else if (currentPlayerHealth == highHealthParameter)
                {
                    currentState = AIState.highHealth;
                }
                break;
        }
        switch (currentState)
        {
            case AIState.LowHealth:
                // Ejecutar el comportamiento del estado de baja salud
                spawnHealthFirstCondition();
                break;

            case AIState.mediuamHealth:
                // Ejecutar el comportamiento del estado de media salud
                spawnHealthSecondCondition();
                break;

            case AIState.highHealth:
                // Ejecutar el comportamiento del estado de alta salud
                // El jugador esta estable
                break;
        }
    }

    public void chekingPlayerPistolStatusV2()
    {
        currentPistolAmmo = pistol.getCurrenBullets();
        currentState = AIState.Idle;
        switch (currentState)
        {
            case AIState.Idle:
                // Verificar las condiciones para cambiar de estado
                if (0 < currentPistolAmmo && currentPistolAmmo <= lowAmmoPistolParameter)
                {
                    currentState = AIState.LowPistolAmmo;
                }
                else if (lowAmmoPistolParameter < currentPistolAmmo && currentPistolAmmo <= mediumAmmoPistolParameter)
                {
                    currentState = AIState.mediuamPistolAmmo;
                }
                else if (currentPistolAmmo == highAmmoPistolParameter)
                {
                    currentState = AIState.highPistolAmmo;
                }
                break;
        }
        switch (currentState)
        {
            case AIState.LowPistolAmmo:
                // Ejecutar el comportamiento del estado de baja ammo de pistol
                spawnPistolammoFirstCondition();
                break;

            case AIState.mediuamPistolAmmo:
                // Ejecutar el comportamiento del estado de media ammo de pistol
                spawnPistolammoSecondCondition();
                break;

            case AIState.highPistolAmmo:
                // Ejecutar el comportamiento del estado de alta ammo de pistol
                // El jugador esta estable
                break;
        }
    }

    

    public void spawnHealthSecondCondition()
    {
        //alter quanity of health
        healthSpawner.alterHealthAmountPerCase(2);
        //alter quantity of recollectables
        waveManager.HealthRecollectableQuantity = 2;
        Debug.Log("Health Rec Quantity: " + waveManager.HealthRecollectableQuantity);
        //spawn health
        waveManager.SpawnHealthRecollectable();
    }
    public void spawnHealthFirstCondition()
    {
        //alter quanity of health
        healthSpawner.alterHealthAmountPerCase(3);
        //alter quantity of recollectables
        waveManager.HealthRecollectableQuantity = 3;
        Debug.Log("Health Rec Quantity: " + waveManager.HealthRecollectableQuantity);
        //spawn health
        waveManager.SpawnHealthRecollectable();
    }

    public void spawnAKammoSecondCondition()
    {
        //alter quanity of health
        ak47AmmoSpawner.alterAKAmmoPerCase(2);
        //alter quantity of recollectables
        waveManager.AK47AmmoQuantity = 2;
        Debug.Log("AK AMMO Quantity: " + waveManager.AK47AmmoQuantity);
        //spawn health
        waveManager.SpawnAK47Ammo();
    }
    public void spawnAKammoFirstCondition()
    {
        //alter quanity of health
        ak47AmmoSpawner.alterAKAmmoPerCase(3);
        //alter quantity of recollectables
        waveManager.AK47AmmoQuantity = 3;
        Debug.Log("AK AMMO Quantity: " + waveManager.AK47AmmoQuantity);
        //spawn health
        waveManager.SpawnAK47Ammo();
    }

    public void spawnPistolammoSecondCondition()
    {
        //alter quanity of health
        pistolAmmoSpawner.alterPistolAmmoPerCase(2);
        //alter quantity of recollectables
        waveManager.PistolAmmoQuantity = 2;
        Debug.Log("PISTOL AMMO Quantity: " + waveManager.PistolAmmoQuantity);
        //spawn health
        waveManager.SpawnPistolAmmo();
    }
    public void spawnPistolammoFirstCondition()
    {
        //alter quanity of health
        pistolAmmoSpawner.alterPistolAmmoPerCase(3);
        //alter quantity of recollectables
        waveManager.PistolAmmoQuantity = 3;
        Debug.Log("PISTOL AMMO Quantity: " + waveManager.PistolAmmoQuantity);
        //spawn health
        waveManager.SpawnPistolAmmo();
    }
}
