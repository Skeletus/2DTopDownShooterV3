using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    public int baseScore = 10;                  // Puntuaci�n base por enemigo asesinado
    public int bonusMultiplier = 20;            // Multiplicador de bonificaci�n por enemigo consecutivo
    public float bonusWindowDuration = 1f;      // Duraci�n de la ventana de bonificaci�n en segundos

    public int currentScore = 0;               // Puntuaci�n actual
    public int consecutiveKills = 0;           // Contador de enemigos asesinados consecutivamente
    private Coroutine bonusWindowCoroutine;     // Referencia a la corrutina de ventana de bonificaci�n
    //public PlayerController pc;

    private float lastKillTime;                 // Tiempo del �ltimo enemigo eliminado

    public int CurrentScore => currentScore;    // Propiedad para acceder a la puntuaci�n actual

    private void Start()
    {
        //pc = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        // Inicializar la puntuaci�n actual
        currentScore = 0;
        lastKillTime = Time.time;
    }

    public int getCurrentScore()
    {
        return currentScore;
    }

    public void AddScore()
    {
        // Incrementar la puntuaci�n base
        currentScore += baseScore;
        //pc.score += baseScore;
        Debug.Log("ADDING BASE SCORE: " + baseScore);

        // Verificar si se cumplen las condiciones para la bonificaci�n
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

        // Actualizar el tiempo del �ltimo enemigo eliminado
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

        // Esperar la duraci�n de la ventana de bonificaci�n
        Debug.Log("WAITING BONUS WINDOW");
        yield return new WaitForSeconds(bonusWindowDuration);

        // Reiniciar el contador de asesinatos consecutivos
        Debug.Log("RESTARTING KILL COUNT!!");
        consecutiveKills = 0;
        //pc.killStreak = 0;
        bonusWindowCoroutine = null;

        // Verificar si hay m�s enemigos asesinados en la ventana de bonificaci�n
        // Si hay, iniciar una nueva ventana
        if (consecutiveKills > 0)
        {
            bonusWindowCoroutine = StartCoroutine(StartBonusWindow());
        }
    }
}
