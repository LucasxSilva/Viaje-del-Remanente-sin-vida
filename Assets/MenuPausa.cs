using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{

    public GameObject Pausa;
    public bool isPaused = false;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cambio();
        }
    }
    public void Cambio()
    {
        if (!isPaused)
        {
            Pausear();
        }
        else if(isPaused)
        {
            Continuar();
        }
    }
    public void Pausear()
    {
        isPaused = true;
        Pausa.SetActive(true);
        Time.timeScale = 0;
    }
    public void Continuar()
    {
        isPaused = false;
        Pausa.SetActive(false);
        Time.timeScale = Difficulty.velocidad_tiempo;
    }
}
