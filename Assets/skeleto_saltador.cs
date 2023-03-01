using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skeleto_saltador : MonoBehaviour
{
    public Transform objetivo;
    public float velocidad;
    public float delay_salto=2f;
    public float impulso_salto=25f;

    public AudioClip clip;
    private bool saltar_orden_en_3=false;

    private Vector3 default_direccion,inicio,final;
    private Rigidbody2D rb2d;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D> ();
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
        if (transform.position == objetivo.position)
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

        if (saltar_orden_en_3==false){
            Invoke("salto",delay_salto);
            saltar_orden_en_3=true;
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
    void salto(){
        rb2d.AddForce(Vector2.up * impulso_salto * 1);
        saltar_orden_en_3=false;
    }

    void OnEnable(){
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
