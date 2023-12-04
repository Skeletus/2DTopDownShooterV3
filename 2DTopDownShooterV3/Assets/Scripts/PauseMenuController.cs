using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    public GameObject pauseMenu; // Referencia al men� de pausa
    public PlayerController playerController;
    public AudioSource music; // Referencia al AudioSource de la m�sica de fondo

    private bool isPaused = false; // Indica si el juego est� en pausa

    private void Start()
    {
        pauseMenu.SetActive(false); // apagar el men� de pausa
    }

    private void Update()
    {
        // Verificar si se presiona la tecla ESC para pausar o reanudar el juego
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
            {
                PauseGame();
            }
            else
            {
                ResumeGame();
            }
        }
    }

    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f; // Pausar el tiempo del juego
        pauseMenu.SetActive(true); // Mostrar el men� de pausa
        //playerController.enabled = false;
    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f; // Reanudar el tiempo del juego
        pauseMenu.SetActive(false); // Ocultar el men� de pausa
        //playerController.enabled = true;
    }

    public void OpenSettings()
    {
        // Implementa aqu� la l�gica para abrir la ventana de ajustes
        Debug.Log("Abrir ajustes");
    }

    public void GoToMainMenu()
    {
        // Implementa aqu� la l�gica para ir al men� principal
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        // Implementa aqu� la l�gica para salir del juego
        Debug.Log("Salir del juego");
        Application.Quit();
    }

    public void AdjustVolume(float volume)
    {
        // Implementa aqu� la l�gica para ajustar el volumen de la m�sica
        music.volume = volume;
    }

    public void OnQuitButtonClick()
    {
        QuitGame();
    }
}
