using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ataque_colision : MonoBehaviour
{
    public GameObject enemigo1;
    public GameObject enemigo2;
    public GameObject enemigo3;
    void OnTriggerEnter2D(Collider2D col){
        if (col.gameObject.tag == "Daña_enemigos"){
            enemigo1.SetActive(false);
            enemigo2.SetActive(false);
            enemigo3.SetActive(false);
        }
    }
}
