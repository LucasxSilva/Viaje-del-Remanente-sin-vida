using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musica_seleccion : MonoBehaviour
{
    private AudioSource audioo;
    void FixedUpdate(){
        if (jefe.vida<=0 || jefe.vida==4){
            Destroy(gameObject);
        }
    }
}
