using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class necromancer : MonoBehaviour
{
    public GameObject particulas;
    public GameObject puerta;
    public Transform skeleto_invocado;
    private Animator anim;   
    public float pre_invocar_delay,invocacion_delay;         
    public AudioClip summon_sound,muere;


    private bool orden_invocar;

    void Awake(){
        puerta = GameObject.Find("puerta_salida");
    }
	void Start()
	{
		anim = GetComponent<Animator> ();
	}
	void Update()
	{
		anim.SetBool("invocar",orden_invocar);
    }
    void FixedUpdate()
    {

        if (orden_invocar==false){
            Invoke("pre_invocar",pre_invocar_delay);
            orden_invocar=true;
            
        }
        if (transform.position.y<=-5){
            puerta.GetComponent<siguiente_nivel> ().abierta=true;
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.tag == "Daña_Enemigos")
            {
                puerta.GetComponent<siguiente_nivel> ().abierta=true;
                Destroy(gameObject);
            }
            if (col.gameObject.tag == "Dañador_objeto")
            {
                AudioSource.PlayClipAtPoint(muere, transform.position);
                Destroy(transform.parent.gameObject);
            }
            if (col.gameObject.tag == "Player")
            {
                col.SendMessage("knockback",transform.position.x);
            }
        }

    void pre_invocar(){
        Invoke("invocar",invocacion_delay);
        particulas.SetActive(true);
    }
    void invocar(){
        AudioSource.PlayClipAtPoint(summon_sound, transform.position);
        Instantiate(skeleto_invocado, new Vector3(100,11,0), Quaternion.identity);
        orden_invocar=false;
        particulas.SetActive(false);

    }
}
