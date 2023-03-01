using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class check_piso : MonoBehaviour
{
	private player_controller jugador;
	private Rigidbody2D rb2d; 


	void Start()
	{
		jugador = GetComponentInParent<player_controller>();
		rb2d=GetComponentInParent<Rigidbody2D>();
	}

	void OnCollsionEnter2dD(Collision2D col){

		if(col.gameObject.tag=="Plataforma"){
			rb2d.velocity = new Vector3(0f,0f,0f);
			jugador.transform.parent = col.transform;
			jugador.tocando_piso = true;
		}
	}
	void OnCollisionStay2D(Collision2D col){
		if(col.gameObject.tag=="Piso"){
			jugador.tocando_piso = true;
		}
		if(col.gameObject.tag=="Plataforma"){
			jugador.transform.parent = col.transform;
			jugador.tocando_piso = true;
		}
	}

	void OnCollisionExit2D(Collision2D col){
		if(col.gameObject.tag=="Piso"){
			jugador.tocando_piso = false;
		}
		if(col.gameObject.tag=="Plataforma"){
			jugador.transform.parent = null;
			jugador.tocando_piso = false;
		}
	}
}
