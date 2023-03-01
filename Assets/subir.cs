using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class subir : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private Vector3 inicio;
    public float velocidad;

    // Update is called once per frame
    void Start(){
        rb2d=GetComponent<Rigidbody2D>();
        inicio=transform.position;
    }

    void FixedUpdate()
    {
        rb2d.velocity = new Vector2(0, velocidad);
    }

    void OnEnable(){
        player_controller.OnPlayerDied += respawn;
    }
    void OnDisable(){
        player_controller.OnPlayerDied -= respawn;
    }
    void respawn(){
        transform.position=inicio;
    }

}
