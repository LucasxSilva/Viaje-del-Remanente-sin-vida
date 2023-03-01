using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class reiniciar : MonoBehaviour
{
    public GameObject player,nodestruir_reinicio;
    
	public void Reinicio(){
		SceneManager.LoadScene("MainMenu");
		Time.timeScale = Difficulty.velocidad_tiempo;
	}  
}
