using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class reiniciar : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject player,nodestruir_reinicio;
    
	public void Reinicio(){
		nodestruir_reinicio =  GameObject.Find("no destruir");
		Destroy(nodestruir_reinicio);
		SceneManager.LoadScene("MainMenu");
		player = GameObject.Find("hero");
		nodestruir_reinicio.transform.position = new Vector2(-66,10);
		Time.timeScale = Difficulty.velocidad_tiempo;
	}  
}
