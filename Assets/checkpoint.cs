using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class checkpoint : MonoBehaviour
{
    private Animator anim;
    public bool Activado=false;
    void Start()
    {
		anim = GetComponent<Animator> ();
    }
    void Update()
    {
        anim.SetBool("Activado",Activado);

    }
    void OnTriggerEnter2D(Collider2D col){
        if (col.gameObject.tag == "Player"){
            Activado=true;
        }
    }
}
