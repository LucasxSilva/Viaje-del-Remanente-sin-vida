using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class siguiente_nivel : MonoBehaviour
{
    private Animator anim;

    public GameObject jugador,musica;
    public bool abierta=false;
    void Awake(){
        jugador=GameObject.Find("hero");
    }
    void Start()
    {
		anim = GetComponent<Animator> ();

    }
    void Update()
    {
        anim.SetBool("abierta",abierta);
    }

    void OnTriggerEnter2D(Collider2D col ){
            {
        if (SceneManager.GetActiveScene () == SceneManager.GetSceneByName ("Nivel 1")) 
            {
                if (col.gameObject.tag == "Player" && abierta==true){
                    jugador.transform.Translate(-150, -13, -1);
                    musica =  GameObject.Find("no destruir");
                    Destroy(musica);
                    SceneManager.LoadScene("Nivel 2");
                } 
            }

        else if (SceneManager.GetActiveScene () == SceneManager.GetSceneByName ("Nivel 2"))
            {
                if (col.gameObject.tag == "Player" && abierta==true){
                    jugador.transform.position = new Vector3(0,0,-1);
                    musica =  GameObject.Find("no destruir");
                    Destroy(musica);
                    SceneManager.LoadScene("Nivel 3");
                } 
            }
        }
    }
}
