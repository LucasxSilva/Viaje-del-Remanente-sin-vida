using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu_juego : MonoBehaviour
{
    public Canvas menu_pausa,menu;
    public void PlayGame() 
    {
        menu.enabled = false;
    }

    public void GoToOptionsMenu()
    {
        menu_pausa.enabled=true;
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
