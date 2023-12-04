using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    public int baseScore = 10;                  // Puntuación base por enemigo asesinado
    public int bonusMultiplier = 20;            // Multiplicador de bonificación por enemigo consecutivo
    public float bonusWindowDuration = 1f;      // Duración de la ventana de bonificación en segundos

    public int currentScore = 0;               // Puntuación actual
    public int consecutiveKills = 0;           // Contador de enemigos asesinados consecutivamente
    private Coroutine bonusWindowCoroutine;     // Referencia a la corrutina de ventana de bonificación
    //public PlayerController pc;

    private float lastKillTime;                 // Tiempo del último enemigo eliminado

    public int CurrentScore => currentScore;    // Propiedad para acceder a la puntuación actual

    private void Start()
    {
        //pc = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        // Inicializar la puntuación actual
        currentScore = 0;
        lastKillTime = Time.time;
    }

    public int getCurrentScore()
    {
        return currentScore;
    }

    public void AddScore()
    {
        // Incrementar la puntuación base
        currentScore += baseScore;
        //pc.score += baseScore;
        Debug.Log("ADDING BASE SCORE: " + baseScore);

        // Verificar si se cumplen las condiciones para la bonificación
        Debug.Log("ARE YOU IN STREAK ?: " + Time.time + " - " + lastKillTime + " < " + bonusWindowDuration);
        if (Time.time - lastKillTime <= bonusWindowDuration)
        {
            Debug.Log("YES YOU ARE!!");
            consecutiveKills++;
            //pc.killStreak++;
            Debug.Log("BONUS POINTS: " + consecutiveKills + " KILLS!!");
            int bonusScore = consecutiveKills * bonusMultiplier;
            currentScore += bonusScore;
            //pc.score += bonusScore;
            Debug.Log("EXTRA POINTS: " + bonusScore);
        }
        else
        {
            Debug.Log("NOP LOSER");
            Debug.Log("normal KILL");
            consecutiveKills = 1;
            //pc.killStreak = 1;
        }

        // Actualizar el tiempo del último enemigo eliminado
        lastKillTime = Time.time;
        //pc.lstKillTime = Time.time;
        Debug.Log("UPDATING TIME KILL: " + lastKillTime);
        Debug.Log("TOTAL SCORE: " + currentScore);
    }

    private IEnumerator StartBonusWindow()
    {
        consecutiveKills++;
        //pc.killStreak++; 
        int bonusScore = consecutiveKills * bonusMultiplier;
        currentScore += bonusScore;
        //pc.score += bonusScore;

        // Esperar la duración de la ventana de bonificación
        Debug.Log("WAITING BONUS WINDOW");
        yield return new WaitForSeconds(bonusWindowDuration);

        // Reiniciar el contador de asesinatos consecutivos
        Debug.Log("RESTARTING KILL COUNT!!");
        consecutiveKills = 0;
        //pc.killStreak = 0;
        bonusWindowCoroutine = null;

        // Verificar si hay más enemigos asesinados en la ventana de bonificación
        // Si hay, iniciar una nueva ventana
        if (consecutiveKills > 0)
        {
            bonusWindowCoroutine = StartCoroutine(StartBonusWindow());
        }
    }
}
