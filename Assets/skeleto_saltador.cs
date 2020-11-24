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

    private Vector3 inicio,final;
    private bool vuelta=true;
    private Rigidbody2D rb2d;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D> ();
        if (objetivo!=null){
            objetivo.parent = null;
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
            if (vuelta==true){
                transform.localScale = new Vector3(-1f,1f,1f);
                vuelta=false;
            }
            else{
                transform.localScale = new Vector3(1f,1f,1f);
                vuelta=true;
            };
        } 
        
        if (transform.position.y<=-55){
            Destroy(transform.parent.gameObject);
        }

        if (saltar_orden_en_3==false){
            Invoke("salto",delay_salto);
            saltar_orden_en_3=true;
        }
    }
    void OnTriggerEnter2D(Collider2D col){
        if (col.gameObject.tag == "Daña_Enemigos")
        {
            AudioSource.PlayClipAtPoint(clip, transform.position);
            Destroy(transform.parent.gameObject);
        }
        if (col.gameObject.tag == "Dañador_objeto")
        {
            AudioSource.PlayClipAtPoint(clip, transform.position);
            Destroy(transform.parent.gameObject);
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

}
