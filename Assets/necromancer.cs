using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class necromancer : MonoBehaviour
{
    public GameObject[] particulas;
    public GameObject puerta;
    public Transform skeleto_invocado;
    private Animator anim;   
    public float pre_invocar_delay,invocacion_delay;         
    public AudioClip summon_sound,muere;

    private Vector3 inicio,final;

    private bool orden_invocar;
    public bool llave=false;
    private int childCount;
    private SpriteRenderer spriteRenderer;
    private Color startColor = new Color(1, 1, 1);
    private Color endColor = new Color(1, 0, 0);
	void Start()
	{
		anim = GetComponent<Animator> ();
        inicio=transform.position;
        particulas = new GameObject[transform.childCount];
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = startColor;

        for (int i = 0; i < transform.childCount; i++)
        {
            particulas[i] = transform.GetChild(i).gameObject;
        }

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

    }

    void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.tag == "Daña_Enemigos" || col.gameObject.tag == "Dañador_objeto")
            {
                AudioSource.PlayClipAtPoint(muere, transform.position);
                if (llave){
                puerta.GetComponent<siguiente_nivel>().abierta = true;
                }
                transform.gameObject.SetActive(false);
            }
            if (col.gameObject.tag == "Player")
            {
                col.SendMessage("knockback",transform.position.x);
            }
        }

    void pre_invocar(){
        StartCoroutine(ChangeColor());
        Invoke("invocar",invocacion_delay);
        for (int i = 0; i < particulas.Length; i++)
        {
            particulas[i].SetActive(true);
        }

    }
    void invocar(){
        AudioSource.PlayClipAtPoint(summon_sound, transform.position);
        orden_invocar=false;
        for (int i = 0; i < particulas.Length; i++)
        {
            Instantiate(skeleto_invocado, particulas[i].transform.position, Quaternion.identity);
            particulas[i].SetActive(false);
        }
    }


    private IEnumerator ChangeColor()
    {
        float t = 0;
        while (t <= 1)
        {
            spriteRenderer.color = Color.Lerp(startColor, endColor, t);
            t += Time.deltaTime / pre_invocar_delay;
            yield return null;
        }

        t = 0;
        while (t <= 1)
        {
            spriteRenderer.color = Color.Lerp(endColor, startColor, t);
            t += Time.deltaTime / invocacion_delay;
            yield return null;
        }
    }


    void OnEnable(){
        player_controller.OnPlayerDied += respawn;
    }
    void OnDisable(){
        CancelInvoke("pre_invocar");
        CancelInvoke("invocar");
        transform.position=inicio;
        orden_invocar=false;
        player_controller.OnPlayerDied -= respawn;
    }

    void respawn(){
        CancelInvoke("pre_invocar");
        CancelInvoke("invocar");
        orden_invocar=false;
        transform.position=inicio;
    }
}
