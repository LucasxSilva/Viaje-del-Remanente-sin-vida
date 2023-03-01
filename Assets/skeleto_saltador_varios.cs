using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skeleto_saltador_varios : MonoBehaviour
{
    public float velocidad;
    public float delay_salto=2f;
    public float impulso_salto=25f;

    private bool saltar_orden_en_3=false;
    public bool cambiar=false;
    
    public AudioClip clip;
    private Vector3 default_direccion,inicio,final;
    private Vector3[] childPositions;

    private Rigidbody2D rb2d;
    private int index, contador;
    public bool destruir;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D> ();
        default_direccion=transform.localScale;
        inicio=transform.position;


        int childCount = transform.parent.childCount;
        // Exclude the current object from the child count
        childCount -= 1;
        childPositions = new Vector3[childCount];
        index = 0;
        contador = 0;
        for (int i = 0; i < transform.parent.childCount; i++)
        {
            Transform child = transform.parent.GetChild(i);
            // Skip the current object
            if (child == transform)
            {
                continue;
            }
            childPositions[index] = child.position;
            index++;
        }
        if(transform.position.x>childPositions[contador].x){
            transform.localScale = new Vector3(-1f,1f,1f);
        }
        if(transform.position.x<childPositions[contador].x){
            transform.localScale = new Vector3(1f,1f,1f);
        }
    }
    void FixedUpdate()
    {        
        float fixedspeed = velocidad * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, childPositions[contador], fixedspeed);

        Vector2 diff = transform.position - childPositions[contador];
        if (diff.magnitude < 4f)// si la diferencia entre transform.position - objetivo.position es menor a 0.2f
        {
            if (cambiar==false)
            {
                if (contador<index-1)
                {
                    contador++;
                }
                else
                {
                    cambiar=true;
                }
            }
            else
            {
                if (contador>0)
                {
                    contador--;
                }
                else
                {
                    cambiar=false;
                }
            }
        }
            if(transform.position.x>childPositions[contador].x){
                transform.localScale = new Vector3(-1f,1f,1f);
            }
            else if(transform.position.x<childPositions[contador].x){
                transform.localScale = new Vector3(1f,1f,1f);
            }

        
        if (saltar_orden_en_3==false){
            Invoke("salto",delay_salto);
            saltar_orden_en_3=true;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Daña_Enemigos" || col.gameObject.tag == "Dañador_objeto")
        {
            AudioSource.PlayClipAtPoint(clip, transform.position);
            if (destruir==true){
                Destroy(transform.parent.gameObject);            
            }
            else{
                transform.parent.gameObject.SetActive(false);
            }
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
        transform.localScale=default_direccion;
        transform.localScale=default_direccion;
        player_controller.OnPlayerDied -= respawn;
    }

    void respawn(){
        if (destruir==true){
            Destroy(transform.parent.gameObject);            
        }
        else{
            transform.position=inicio;
            transform.localScale=default_direccion;
            transform.localScale=default_direccion;
            contador=0;
        } 
    }

}