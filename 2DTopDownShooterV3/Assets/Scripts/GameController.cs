using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public ScoreSystem scoreSystem;
    public WaveManager waveManager;
    public GameOverManager gameOverManager;
    public PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        scoreSystem = GetComponent<ScoreSystem>();
        waveManager = GetComponent<WaveManager>();
        //gameOverManager = GameObject.FindGameObjectWithTag("GameOverMENU").GetComponent<GameOverManager>();
    }

    public int getPlayerAK47Ammo()
    {
        return playerController.ak47.getCurrenBullets();
    }

    public int getPlayerScore()
    {
        return scoreSystem.getCurrentScore();
    }

    public int getPlayerPistolAmmo()
    {
        return playerController.pistol.getCurrenBullets();
    }

    public int getPlayerHealth()
    {
        return playerController.getPlayerCurrentHealth();
    }

    public int getCurrentWave()
    {
        return waveManager.getCurrentWave();
    }

    public WaveManager getWaveManager()
    {
        return waveManager;
    }

    public GameOverManager getGameOverManager()
    {
        return gameOverManager;
    }


    public void loadGameOverScreen()
    {
        gameOverManager.setGameOver();
    }

    public void addScoreToPlayer()
    {
        scoreSystem.AddScore();
    }

    
}
