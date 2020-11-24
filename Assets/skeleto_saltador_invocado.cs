using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skeleto_saltador_invocado : MonoBehaviour
{
    public GameObject objetivo1,objetivo2;
    public float velocidad;
    public float delay_salto=2f;
    public float impulso_salto=25f;

    private bool saltar_orden_en_3=false;
    public bool cambiar=false;
    
    public AudioClip clip;


    private Rigidbody2D rb2d;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D> ();
        objetivo1.transform.position=new Vector3(123,5,objetivo1.transform.position.z);
        objetivo2.transform.position=new Vector3(85,-12,objetivo2.transform.position.z);

    }
    void FixedUpdate()
    {

        if (cambiar==false){
            float fixedspeed = velocidad * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, objetivo1.transform.position, fixedspeed);
        }
        if (cambiar==true){
            float fixedspeed = velocidad * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, objetivo2.transform.position, fixedspeed);
        }
        
        if (transform.position == objetivo1.transform.position)
        {
            cambiar=true;
            transform.localScale = new Vector3(-1f,1f,1f);
            //Debug.Log(transform.localPosition);
            //Debug.Log(transform.position);

        }
        
        if (transform.position.y<=-55){
            Destroy(transform.parent.gameObject);
        }

        if (saltar_orden_en_3==false){
            Invoke("salto",delay_salto);
            saltar_orden_en_3=true;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
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

