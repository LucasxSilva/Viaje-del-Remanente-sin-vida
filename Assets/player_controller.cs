using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class player_controller : MonoBehaviour {
	public delegate void PlayerDied();
	public static event PlayerDied OnPlayerDied;

	public static player_controller Instance;
	public float velocidad = 100f;
	public float impulso_salto = 450f;
	public bool tocando_piso;
	public bool vivo=true;
	public bool stun=false;
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
	public SpriteRenderer sprite;

	private float h;
    public reset resett;

	public float original_anim_Speed;

	void Start()
	{
		rb2d = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		sprite = GetComponentInChildren<SpriteRenderer>();

		pos_checkpoint=GameObject.Find("pos_checkpoint");
		attack_effect=GameObject.Find("attack_effect");
		attack_effect.SetActive(false);
		resett = GetComponent<reset>();
		original_anim_Speed = anim.speed;

	}
	void Update()
	{
		anim.SetFloat("velocidad",Mathf.Abs(rb2d.velocity.x));
		anim.SetBool("tocando_piso",tocando_piso);
		anim.SetBool("vivo",vivo);
		anim.SetBool("stun",stun);
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
		Scene currentScene = SceneManager.GetActiveScene ();
        string sceneName = currentScene.name;
	}		

	//FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
	void FixedUpdate()
	{
		if (vivo==true && stun==false)
		{
			//velocidad limite
			if (rb2d.velocity.x>new Vector2(8f,0f).x)
			{
				rb2d.velocity *= new Vector2(0.909f,1f);
				anim.speed= 1.1f+rb2d.velocity.x/20;
			}
			else{
				anim.speed= original_anim_Speed;
				rb2d.velocity *= new Vector2(0.9f,1f);
			}

			//Store the current horizontal input in the float h.
			h = Input.GetAxis ("Horizontal");
			if (tocando_piso==false){
				rb2d.AddForce(Vector2.up * -1/2, ForceMode2D.Impulse);
			}
			rb2d.AddForce(Vector2.right * velocidad * h);

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
				rb2d.velocity*= new Vector2(0.8f,1f);
				attack_effect.SetActive(true);
				ataque_listo=false;
				Invoke("stop_atack",atackdelay);
			}
		}
		pos_jugador=GameObject.Find("hero").transform.position;
	}
	
	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag=="Dañador_objeto"){
			vida=0;
			vivo=false;
			sprite.color = new Color (1,0,0,1);

			AudioSource.PlayClipAtPoint(muerte_pinchos, transform.position);
			if (reviviendo==false){
				reviviendo=true;
				Invoke("respawn",respawndelay);	
			}
		}

		if (col.gameObject.tag == "Checkpoint")
		{
			pos_checkpoint.transform.position=col.transform.position;
		}
	}
		


	void stop_atack(){
		atacando=false;
		Invoke("delaay_atack",0.5f);
		attack_effect.SetActive(false);
	}
		void delaay_atack(){
			ataque_listo=true;
	}
	public void knockback(float enemyposx){
		stun=true;
		float side = Mathf.Sign(enemyposx-transform.position.x); //devuelve positivo o negativo
		rb2d.AddForce(Vector2.left * side * impulso_salto /2, ForceMode2D.Impulse);
		if (siendo_atacado_inmune==false){
			vida-=1;
			AudioSource.PlayClipAtPoint(recibe_daño, transform.position);
			
			siendo_atacado_inmune=true;
			sprite.color = new Color (1,0,0,1);
			Invoke("desactivar_inmune",0.6f);

			if (vida<=0){//revivir
				vivo=false;
				//siendo_atacado_inmune=true;
				sprite.color = new Color (1,0,0,1);
				AudioSource.PlayClipAtPoint(muere1, transform.position);
				if (reviviendo==false){
					reviviendo=true;
					Invoke("respawn",respawndelay);
				}
			}
		}

	}
	void desactivar_inmune(){
		siendo_atacado_inmune=false;
		stun=false;
		if (vida==3){
			sprite.color=new Color (1,1,1,1);
		}else if (vida==2){
			sprite.color=new Color (1,0.7f,0.7f,1);
		}else if (vida==1){
			sprite.color=new Color (1,0.4f,0.4f,1);
		}
	}
	public void vida_bonus(int puntos){
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
    }

	void respawn(){
		resett.reseteo();
		if (OnPlayerDied != null)
		{
			OnPlayerDied();
		}
		//SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
		pos_checkpoint=GameObject.Find("pos_checkpoint");
		this.transform.position=pos_checkpoint.transform.position;
		Invoke("revivir_particulas",0.5f);
		vivo=true;
		stun=false;
		vida=3;
		siendo_atacado_inmune=false;
		sprite.color = new Color (1,1,1,1);
		reviviendo=false;
    }

	void revivir_particulas(){
		Instantiate(particulas_respawn, transform.position, Quaternion.identity);
	}
}