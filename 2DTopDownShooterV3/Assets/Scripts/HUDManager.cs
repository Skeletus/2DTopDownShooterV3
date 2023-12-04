using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUDManager : MonoBehaviour
{
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI ammoAK47Text;
    public TextMeshProUGUI ammoPistolText;
    public TextMeshProUGUI waveText;
    public TextMeshProUGUI scoreText;
    public GameController gccontroller;

    private void Update()
    {
        // Actualizar la información en el HUD
        UpdateHealthText();
        UpdateAK47AmmoText();
        UpdatePistolAmmoText();
        UpdateWaveText();
        UpdateScoreText();
    }

    private void UpdateHealthText()
    {
        // Obtener la vida actual del jugador y actualizar el texto correspondiente en el HUD
        int health = gccontroller.getPlayerHealth();
        healthText.text = "Vida: " + health.ToString();
    }

    private void UpdateAK47AmmoText()
    {
        // Obtener la munición actual del jugador y actualizar el texto correspondiente en el HUD
        int ammo = gccontroller.getPlayerAK47Ammo();
        ammoAK47Text.text = "AK47 Ammo: " + ammo.ToString();
    }

    private void UpdatePistolAmmoText()
    {
        // Obtener la munición actual del jugador y actualizar el texto correspondiente en el HUD
        int ammo = gccontroller.getPlayerPistolAmmo();
        ammoPistolText.text = "Pistol Ammo: " + ammo.ToString();
    }

    private void UpdateWaveText()
    {
        // Obtener el número de oleada actual y actualizar el texto correspondiente en el HUD
        int wave = gccontroller.getCurrentWave();
        waveText.text = "Oleada: " + wave.ToString();
    }

    private void UpdateScoreText()
    {
        // Obtener el número de oleada actual y actualizar el texto correspondiente en el HUD
        int score = gccontroller.getPlayerScore();
        scoreText.text = "Score: " + score.ToString();
    }
}
