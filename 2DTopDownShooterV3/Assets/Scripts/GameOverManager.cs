using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject GoM;
    public bool isGameOvered = false;

    private void Start()
    {
        //isGameOvered = false;
        GoM.SetActive(false); // apagar el menú de pausa
    }
    private void Update()
    {        
        if (isGameOvered)
        {
            loadGameOverScreen();
        }
        
    }

    public void setGameOver()
    {
        isGameOvered = true;    
    }
    public void RestartGame()
    {
        // Reiniciar el juego cargando la escena actual nuevamente
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        // Salir del juego (funciona en la compilación del juego, no en el editor)
        Application.Quit();
    }

    public void loadGameOverScreen()
    {
        // Mostrar el cursor del mouse
        Cursor.visible = true;
        GoM.SetActive(true); // muestra el menú de gameover
    }
    public void OnQuitButtonClick()
    {
        QuitGame();
    }
}
