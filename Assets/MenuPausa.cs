using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{

    public GameObject Pausa;
    public static int cont;

    void Start()
    {
        Pausa.SetActive(false);
        cont = 0;
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
        if ( Time.timeScale>0)
        {
            Pausear();
        }
        else if(Time.timeScale == 0)
        {
            Continuar();
        }
    }
    public void Pausear()
    {
        cont = 1;
        Pausa.SetActive(true);
        Time.timeScale = 0;
    }
    public void Continuar()
    {
        cont = 0;
        Pausa.SetActive(false);
        Time.timeScale = Difficulty.velocidad_tiempo;

        
    }
}
