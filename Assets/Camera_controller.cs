using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_controller : MonoBehaviour {

    public GameObject jugador;        //Public variable to store a reference to the jugador game object

    public float smoothtime=0f;
    public Vector2 mincampos,maxcampos;
    private Vector2 velocity;

    void FixedUpdate(){
        float posx=Mathf.SmoothDamp(transform.position.x,
        jugador.transform.position.x, ref velocity.x,smoothtime);

        float posy=Mathf.SmoothDamp(transform.position.y,
        jugador.transform.position.y, ref velocity.y,smoothtime);

        transform.position = new Vector3(
            Mathf.Clamp(posx,mincampos.x,maxcampos.x),
            Mathf.Clamp(posy,mincampos.y,maxcampos.y),
            transform.position.z);
    }
}


