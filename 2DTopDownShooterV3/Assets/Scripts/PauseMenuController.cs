using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    public GameObject pauseMenu; // Referencia al menú de pausa
    public PlayerController playerController;
    public AudioSource music; // Referencia al AudioSource de la música de fondo

    private bool isPaused = false; // Indica si el juego está en pausa

    private void Start()
    {
        pauseMenu.SetActive(false); // apagar el menú de pausa
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
        pauseMenu.SetActive(true); // Mostrar el menú de pausa
        //playerController.enabled = false;
    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f; // Reanudar el tiempo del juego
        pauseMenu.SetActive(false); // Ocultar el menú de pausa
        //playerController.enabled = true;
    }

    public void OpenSettings()
    {
        // Implementa aquí la lógica para abrir la ventana de ajustes
        Debug.Log("Abrir ajustes");
    }

    public void GoToMainMenu()
    {
        // Implementa aquí la lógica para ir al menú principal
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        // Implementa aquí la lógica para salir del juego
        Debug.Log("Salir del juego");
        Application.Quit();
    }

    public void AdjustVolume(float volume)
    {
        // Implementa aquí la lógica para ajustar el volumen de la música
        music.volume = volume;
    }

    public void OnQuitButtonClick()
    {
        QuitGame();
    }
}
