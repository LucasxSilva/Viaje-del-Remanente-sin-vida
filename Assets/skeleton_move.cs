using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skeleton_move : MonoBehaviour
{
    public Transform objetivo;
    public float velocidad;
    
    public AudioClip clip;
    private Vector3 default_direccion,inicio,final;
    void Start()
    {
        if (objetivo!=null){
            default_direccion=transform.localScale;

            inicio=transform.position;
            final=objetivo.position;
        }
    }
    void FixedUpdate()
    {
        if (objetivo!=null){
            float fixedspeed = velocidad * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, objetivo.position, fixedspeed);
        }




        Vector2 diff = transform.position - objetivo.position;
        if (diff.magnitude < 0.2f) // si la diferencia entre transform.position - objetivo.position es menor a 0.2f
        {
            objetivo.position = (objetivo.position == inicio ) ? final : inicio;
            if (objetivo.position.x>transform.position.x)
            {
                transform.localScale = new Vector3(-1f,1f,1f);
            }
            else{
                transform.localScale = new Vector3(1f,1f,1f);
            }
        } 
    }
    void OnTriggerEnter2D(Collider2D col){
        if (col.gameObject.tag == "Daña_Enemigos" || col.gameObject.tag == "Dañador_objeto")
        {
            AudioSource.PlayClipAtPoint(clip, transform.position);
            transform.parent.gameObject.SetActive(false);
        }
        if (col.gameObject.tag == "Player")
        {
            col.SendMessage("knockback",transform.position.x);
        }
    }

    void OnEnable(){
        if (objetivo.position.x>transform.position.x)
        {
            transform.localScale = new Vector3(-1f,1f,1f);
        }
        else{
            transform.localScale = new Vector3(1f,1f,1f);
        }
        player_controller.OnPlayerDied += respawn;
    }
    void OnDisable(){
        transform.position=inicio;
        objetivo.position=final;
        transform.localScale=default_direccion;
        player_controller.OnPlayerDied -= respawn;
    }

    void respawn(){
        transform.position=inicio;
        objetivo.position=final;
        transform.localScale=default_direccion;
    }

}
