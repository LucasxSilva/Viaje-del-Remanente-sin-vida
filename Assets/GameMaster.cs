using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public static GameMaster Instance;
    public GameObject pos_checkpoint;
    public GameObject jugador;
    //public Transform jugador=GameObject.FindGameObjectsWithTag("Respawn");
    public Vector3 pos;

    void FixedUpdate(){
        jugador=GameObject.Find("hero");
    }
	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Checkpoint")
		{
            pos=jugador.transform.position;
			pos_checkpoint.transform.position=jugador.transform.position;
            Debug.Log("yey");
        }
        
	}
}
