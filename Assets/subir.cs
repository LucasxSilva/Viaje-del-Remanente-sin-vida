using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class subir : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public float velocidad;

    // Update is called once per frame
    void Start(){
        rb2d=GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb2d.velocity = new Vector2(0, velocidad);
    }

    //void OnTriggerEnter2D(Collider2D col)
	//{
        //if(col.gameObject.tag != "Player"){
        //    col.gameObject.SetActive(false);
       //     Destroy(col.gameObject, 6.0f);
      //  }
    //}
}
