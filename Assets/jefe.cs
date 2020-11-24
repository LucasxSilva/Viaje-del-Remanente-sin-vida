using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jefe : MonoBehaviour
{
    public GameObject jugador,canvas;
    public float pre_invocar_delay,invocacion_delay,velocidad;  
    public static int vida=3;
    private bool invulnerable,orden_invocar=false;
    private Rigidbody2D rb2d;
    public GameObject particulas;
    public Transform npc_summons1,npc_summons2,npc_summons3;
    private Animator anim;   
    private Vector3 pos_jugador;
    public AudioClip VICTORIA;

    SpriteRenderer sprite;


    public AudioClip summon_sound,muere;
    // Start is called before the first frame update
    void Start()
    {
        rb2d=GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator> ();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    void Update(){
        //anim.SetBool("idle",vivo);
		//anim.SetBool("atacar",atacando);
		//anim.SetBool("invocar",orden_invocar);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Debug.Log(vida);
        jugador=GameObject.Find("hero");

        rb2d.velocity = new Vector2(0, velocidad);
        //anim.SetBool("invocar",orden_invocar);
        if (orden_invocar==false){
            Invoke("pre_invocar",pre_invocar_delay);
            orden_invocar=true;
        }

        switch (vida)
        {
            case 3:
            {//fase 1
                if (orden_invocar==false){
                    Invoke("pre_invocar",pre_invocar_delay);
                    orden_invocar=true;
                }
                break;
            }
            case 2:
            {//fase 2
                if (orden_invocar==false){
                    Invoke("pre_invocar",pre_invocar_delay);
                    orden_invocar=true;
                }
                //añadir ataques/hechizos extras
                break;
            }
            case 1:
            {//fase 3
                if (orden_invocar==false){
                    Invoke("pre_invocar",pre_invocar_delay);
                    orden_invocar=true;
                }
                
                
                //añadir ataques/hechizos extras
                break;
            }
            case 0:{
                Debug.Log("Ganaste");
                //pos_jugador=GameObject.Find("hero").transform.position;
                //pos_jugador.x=-300;
                //pos_jugador.y=-5;

                //jugador.transform.position=pos_jugador;
                vida=4;
                canvas.SetActive(true);
                Time.timeScale=0;

                AudioSource.PlayClipAtPoint(VICTORIA, jugador.transform.position);
                break;
            }
        }
				//if(Input.GetKeyDown(KeyCode.Space)){
				//	vida-=1;		
				//}
        
    }

    
    void OnTriggerEnter2D(Collider2D col){
        if (col.gameObject.tag == "Player")
        {
            col.SendMessage("knockback",transform.position.x);
        }
        if (col.gameObject.tag == "Daña_Enemigos")
        {
            if (invulnerable==false){
                Debug.Log("jefe recibe daño, vida: "+ vida);

                vida-=1;
                invulnerable=true;
                sprite.color=new Color (1,0,0,1);
                Invoke("desactivar_inmune",2);
                switch (vida)
                    {
                        case 3:
                        {//fase 1
                            break;
                        }
                        case 2:
                        {//fase 2
                            transform.position = new Vector2(-20,transform.position.y);
                            break;
                        }
                        case 1:
                        {//fase 3
                            transform.position = new Vector2(23,transform.position.y);
                            break;
                        }
                    }

            }
        }
    }
    
    void desactivar_inmune(){
        invulnerable=false;
        sprite.color=new Color (1,1,1,1);
    }



    void pre_invocar(){
        Invoke("invocar",invocacion_delay);
        particulas.SetActive(true);
    }

    void invocar(){
        AudioSource.PlayClipAtPoint(summon_sound, transform.position);
        switch (vida)
        {
            case 3:
            {//fase 1
                Instantiate(npc_summons1, transform.position, Quaternion.identity);
                break;
            }
            case 2:
            {//fase 2
                Instantiate(npc_summons2, transform.position, Quaternion.identity);
                //añadir ataques/hechizos extras
                break;
            }
            case 1:
            {//fase 3
                Instantiate(npc_summons3, transform.position, Quaternion.identity);
                //añadir ataques/hechizos extras
                break;
            }
        }

        
        orden_invocar=false;
        particulas.SetActive(false);
    }
}
