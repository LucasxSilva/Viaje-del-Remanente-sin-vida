using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npc_summon : MonoBehaviour
{
    public Transform objetivo;
    public GameObject jugador;
    public float velocidad,delay_buscar;
    
    public AudioClip clip;
    private Animator anim;   
    //private bool vuelta=true;
    private bool orden_buscar=false;
    //private bool muriendo

    void Start(){
        jugador=GameObject.Find("hero");
        anim = GetComponent<Animator> ();
    }
    void FixedUpdate()
    {
        //anim.SetBool("muriendo",muriendo);
        
        if (objetivo!=null){
            float fixedspeed = velocidad * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, objetivo.position, fixedspeed);
        }
        if (orden_buscar==false){
            Invoke("Buscar",delay_buscar);
            orden_buscar=true;
        }

       // if (transform.position == objetivo.position)
        //{
        //    objetivo.position = (objetivo.position == inicio ) ? final : inicio;
        //    if (vuelta==true){
        //        transform.localScale = new Vector3(-1f,1f,1f);
        //        vuelta=false;
        //    }
        //    else{
        //        transform.localScale = new Vector3(1f,1f,1f);
        //        vuelta=true;
        //    };
        //} 
    }
    void OnTriggerEnter2D(Collider2D col){
        if (col.gameObject.tag == "Daña_Enemigos" || col.gameObject.tag == "Dañador_objeto")
        {
            AudioSource.PlayClipAtPoint(clip, transform.position);
            Destroy(transform.parent.gameObject);
        }
        if (col.gameObject.tag == "Player")
        {
            col.SendMessage("knockback",transform.position.x);
        }
    }
    void Buscar(){
        objetivo.transform.position=jugador.transform.position;
        orden_buscar=false;
        if(transform.position.x>objetivo.transform.position.x){
            transform.localScale = new Vector3(-1f,1f,1f);
        }
        if(transform.position.x<objetivo.transform.position.x){
            transform.localScale = new Vector3(1f,1f,1f);
        }
    }
    void OnEnable(){
        player_controller.OnPlayerDied += respawn;
    }
    void OnDisable(){
        player_controller.OnPlayerDied -= respawn;
    }

    void respawn(){
        Destroy(transform.parent.gameObject);
    }
}
