using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dar_vida : MonoBehaviour
{
    public ParticleSystem ps;

    void OnTriggerEnter2D(Collider2D col){
        if (col.gameObject.tag == "Player")
        {

            Instantiate(ps, transform.position, Quaternion.identity);
            col.SendMessage("vida_bonus",1);
            Destroy(gameObject);
        }
    }

}