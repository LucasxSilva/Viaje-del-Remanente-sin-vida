using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class siguiente_nivel : MonoBehaviour
{
    private Animator anim;

    public GameObject jugador,musica;
    public bool abierta=false;
    public bool estado_base=false;
    void Awake(){
        jugador=GameObject.Find("hero");
    }
    void Start()
    {
        estado_base=abierta;
		anim = GetComponent<Animator> ();

    }
    void Update()
    {
        anim.SetBool("abierta",abierta);
    }

    void OnTriggerEnter2D(Collider2D col )
    {
        if (abierta==true)
        {

            if (SceneManager.GetActiveScene () == SceneManager.GetSceneByName ("Nivel 1")) 
            {
                if (col.gameObject.tag == "Player"){
                    musica =  GameObject.Find("no destruir");
                    Destroy(musica);
                    SceneManager.LoadScene("Nivel 2");
                } 
            }

            else if (SceneManager.GetActiveScene () == SceneManager.GetSceneByName ("Nivel 2"))
            {
                if (col.gameObject.tag == "Player"){
                    musica =  GameObject.Find("no destruir");
                    Destroy(musica);
                    SceneManager.LoadScene("Nivel 3");
                } 
            }

        }
    }


    void OnEnable(){
        player_controller.OnPlayerDied += respawn;
    }
    void OnDisable(){
        player_controller.OnPlayerDied -= respawn;
    }

    void respawn(){
        abierta=estado_base;
    }
    
}
