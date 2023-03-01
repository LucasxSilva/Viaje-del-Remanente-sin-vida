using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Difficulty : MonoBehaviour
{
    public static float dificultad=2;
    public static float velocidad_tiempo=1f;

    public void OnValueChanged(float valor)
    {
        dificultad = valor;

        if (dificultad == 1)
        {
            velocidad_tiempo = 0.8f;
            Time.timeScale = 0.8f;
        }
        if (dificultad == 2)
        {
            velocidad_tiempo = 1f;
            Time.timeScale = 1f;
        }
        if (dificultad == 3)
        {
            velocidad_tiempo = 1.25f;
            Time.timeScale = 1.25f;
        }
        //Debug.Log(dificultad);
    }
}
