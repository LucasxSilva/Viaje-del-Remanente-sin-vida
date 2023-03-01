using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plataforma_caer : MonoBehaviour
{
    public float falldelay = 0.6f;
    public float respawndelay = 5f;

    private Vector3 inicio;

    private Rigidbody2D rb2D;

    void Start()
    {
        rb2D= GetComponent<Rigidbody2D>();
        inicio= transform.position;
    }

    void OnCollisionEnter2D(Collision2D col){
        if (col.gameObject.CompareTag("Player")){
            Invoke("caer",falldelay);
            Invoke("respawn",falldelay+respawndelay);
        }
    }
    
    void caer(){
        rb2D.isKinematic = false;
    }
    void OnEnable(){
        player_controller.OnPlayerDied += respawn;
    }
    void OnDisable(){
        player_controller.OnPlayerDied -= respawn;
    }
    void respawn(){
        transform.position=inicio;
        rb2D.isKinematic = true;
        rb2D.velocity = Vector3.zero;
    }
}
