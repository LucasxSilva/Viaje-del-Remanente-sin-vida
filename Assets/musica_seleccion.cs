using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musica_seleccion : MonoBehaviour
{
    private AudioSource audio;
    void FixedUpdate(){
        if (jefe.vida==0){
            Destroy(gameObject);
        }
    }
}
