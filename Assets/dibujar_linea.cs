using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dibujar_linea : MonoBehaviour
{
    public Transform desde;
    public Transform hasta;

    void OnDrawGizmosSelected(){
        if (desde!=null && hasta!=null){
            Gizmos.color =Color.cyan;
            Gizmos.DrawLine(desde.position,hasta.position);
            Gizmos.DrawSphere(desde.position,0.15f);
            Gizmos.DrawSphere(hasta.position,0.15f);
        }
    }
}
