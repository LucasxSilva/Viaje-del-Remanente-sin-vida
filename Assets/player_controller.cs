using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class player_controller : MonoBehaviour {

	public static player_controller Instance;
	public float velocidad = 100f;
	public float impulso_salto = 450f;
	public float limite_velocidad = 20f;
	public bool tocando_piso;
	public bool vivo=true;
	public bool atacando=false;
	public bool ataque_listo=true;
	private bool siendo_atacado_inmune=false;
	public float respawndelay = 1.5f;
	public float atackdelay = 0.75f;
	public AudioClip recibe_daño,muere1,muerte_pinchos;
	public ParticleSystem particulas_respawn;


	private bool reviviendo=false;
	private Animator anim;                
	private Rigidbody2D rb2d;        //Store a reference to the Rigidbody2D component required to use 2D Physics.
	private bool saltar;
	public Vector3 pos_jugador;
	public GameObject pos_checkpoint,attack_effect;
	public static int vida = 3;
	SpriteRenderer sprite;

	private float h;


	void Start()
	{
		rb2d = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		sprite = GetComponentInChildren<SpriteRenderer>();

		pos_checkpoint=GameObject.Find("pos_checkpoint");
		attack_effect=GameObject.Find("attack_effect");
		attack_effect.SetActive(false);
	}
	void Update()
	{
		anim.SetFloat("velocidad",Mathf.Abs(rb2d.velocity.x));
		anim.SetBool("tocando_piso",tocando_piso);
		anim.SetBool("vivo",vivo);
		anim.SetBool("atacando",atacando);
		anim.SetBool("saltar",saltar);

		if (Input.GetKeyDown(KeyCode.UpArrow) && tocando_piso || Input.GetKeyDown(KeyCode.W) && tocando_piso){
			saltar = true;
		}
		if (Input.GetKeyDown(KeyCode.DownArrow) && tocando_piso==false || Input.GetKeyDown(KeyCode.S) && tocando_piso==false){
			rb2d.AddForce(Vector2.up * -15, ForceMode2D.Impulse);
		}
		if (Input.GetKeyDown(KeyCode.Space) && ataque_listo==true){
			atacando=true;
		}
		if (Input.GetKeyDown(KeyCode.R)){
			Invoke("respawn",0.5f);
		}
	}		

	//FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
	void FixedUpdate()
	{
        

		if (vivo==true)
		{
			Vector3 fixedvelocity = rb2d.velocity;
			fixedvelocity.x *= 0.9f;

			rb2d.velocity = fixedvelocity;

			//Store the current horizontal input in the float h.
			h = Input.GetAxis ("Horizontal");
			if (tocando_piso==false){
				rb2d.AddForce(Vector2.up * -1/2, ForceMode2D.Impulse);
			}

			//velocidad limite
			float limitspeed = Mathf.Clamp(rb2d.velocity.x,-limite_velocidad,limite_velocidad);
			rb2d.AddForce(Vector2.right * velocidad * h);
			rb2d.velocity = new Vector2(limitspeed,rb2d.velocity.y);

			//revisa si esta avanzando hacia izquierda o derecha y rota al personaje
			if (h > 0.1f){
				transform.localScale = new Vector3(1f,1f,1f);

			}
			if (h < -0.1f){
				transform.localScale = new Vector3(-1f,1f,1f);
			}

			if (saltar==true)
			{
				//fuerza de salto
				rb2d.velocity = new Vector2(rb2d.velocity.x,0);
				rb2d.AddForce(Vector2.up * impulso_salto, ForceMode2D.Impulse);
				saltar=false;
			}
			if (atacando==true)
			{
				//attack_effect.transform.position=ataque_visible;
				fixedvelocity.x*=0.8f;
				rb2d.velocity=fixedvelocity;
				attack_effect.SetActive(true);
				ataque_listo=false;
				Invoke("stop_atack",atackdelay);
			}
		}
		pos_jugador=GameObject.Find("hero").transform.position;


        Scene currentScene = SceneManager.GetActiveScene ();
        string sceneName = currentScene.name;
	}
	
	void OnTriggerEnter2D(Collider2D col)
	{
        if (col.gameObject.tag == "Dañador")
		{
			if (vida==0){
				vivo=false;
				sprite.color = new Color (1,0,0,1);
				AudioSource.PlayClipAtPoint(muere1, transform.position);
				Invoke("respawn",respawndelay);
			}
			Debug.Log("Colisiona con Dañador, vida: "+ vida);
        }

		if (col.gameObject.tag=="Dañador_matable")
		{
			//añadir mensaje enviando metodo+posenemigo desde el script enemigo
			if (vida==0){
				vida=0;
				vivo=false;
				sprite.color = new Color (1,0,0,1);
				AudioSource.PlayClipAtPoint(muere1, transform.position);
				Invoke("respawn",respawndelay);
			}
			Debug.Log("Colisiona con Dañador_matable, vida: "+ vida);
        }

		if (col.gameObject.tag=="Dañador_objeto"){
			vida=0;
			vivo=false;
			sprite.color = new Color (1,0,0,1);

			AudioSource.PlayClipAtPoint(muerte_pinchos, transform.position);
			Invoke("respawn",respawndelay);	
			Debug.Log("Colisiona con Dañador_objeto, vida: "+ vida);
		}

		if (col.gameObject.tag == "Checkpoint")
		{
			pos_checkpoint.transform.position=col.transform.position;
        }
	}
		
	void respawn(){
		if (reviviendo==false){
			if (SceneManager.GetActiveScene () == SceneManager.GetSceneByName ("Nivel 3")){
				jefe.vida=3;
			}
			SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
			pos_checkpoint=GameObject.Find("pos_checkpoint");
			this.transform.position=pos_checkpoint.transform.position;
			Invoke("revivir_particulas",0.5f);
			vivo=true;
			vida=3;
			sprite.color = new Color (1,1,1,1);
			reviviendo=true;
			Invoke("respawn_true",0);
		}	
    }

	void respawn_true(){
		reviviendo=false;
	}

	void stop_atack(){
		atacando=false;
		Invoke("delaay_atack",0.5f);
		attack_effect.SetActive(false);
	}
		void delaay_atack(){
			ataque_listo=true;
	}
	void knockback(float enemyposx){
		vivo=false;
		float side = Mathf.Sign(enemyposx-transform.position.x); //devuelve positivo o negativo
		rb2d.AddForce(Vector2.left * side * impulso_salto /2, ForceMode2D.Impulse);
		if (siendo_atacado_inmune==false){
			vida-=1;
			AudioSource.PlayClipAtPoint(recibe_daño, transform.position);
			Debug.Log("Daño recibido, vida: "+ vida);
		}
		siendo_atacado_inmune=true;
		sprite.color = new Color (1,0,0,1);
		Invoke("desactivar_inmune",0.7f);
	}
	void desactivar_inmune(){
		siendo_atacado_inmune=false;
		vivo=true;
		if (vida==3){
			sprite.color=new Color (1,1,1,1);
		}else if (vida==2){
			sprite.color=new Color (1,0.7f,0.7f,1);
		}else if (vida==1){
			sprite.color=new Color (1,0.4f,0.4f,1);
		}
	}
	void vida_bonus(int puntos){
		if (vida<5){
			vida+=puntos;
		}
        if (vida==3){
            sprite.color=new Color (1,1,1,1);
        }else if (vida==2){
            sprite.color=new Color (1,0.7f,0.7f,1);
        }else if (vida==1){
            sprite.color=new Color (1,0.4f,0.4f,1);
        }
        Debug.Log(vida);
    }
	void revivir_particulas(){
		Instantiate(particulas_respawn, transform.position, Quaternion.identity);
	}
}