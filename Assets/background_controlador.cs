using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class background_controlador : MonoBehaviour
{
    public GameObject jugador;        //Public variable to store a reference to the jugador game object

    public float smoothtime=0.5f;
    public Vector2 mincampos,maxcampos;
    private Vector2 velocity;
    public SpriteRenderer spriteRenderer;
    public Sprite nivel1,nivel2;


    void Start(){

        jugador=GameObject.Find("hero");

    }

void Update()
    {
    if (SceneManager.GetActiveScene () == SceneManager.GetSceneByName ("Nivel 1")) 
        {
            spriteRenderer.sprite = nivel1; 
        }

    else if (SceneManager.GetActiveScene () == SceneManager.GetSceneByName ("Nivel 2"))
        {
            spriteRenderer.sprite = nivel2; 
        }
    }

    void FixedUpdate(){
        float posx=Mathf.SmoothDamp(transform.position.x,
        jugador.transform.position.x, ref velocity.x,smoothtime);

        float posy=Mathf.SmoothDamp(transform.position.y,
        jugador.transform.position.y, ref velocity.y,smoothtime);

        transform.position = new Vector3(
            Mathf.Clamp(posx,mincampos.x,maxcampos.x),
            Mathf.Clamp(posy,mincampos.y,maxcampos.y),
            transform.position.z);
    }
}
