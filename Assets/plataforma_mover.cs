using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plataforma_mover : MonoBehaviour
{

    public Transform objetivo;
    public float velocidad;

    private Vector3 inicio,final;
    void Start()
    {
        if (objetivo!=null){
            objetivo.parent = null;
            inicio=transform.position;
            final=objetivo.position;
        }
    }
        void FixedUpdate()
    {
        if (objetivo!=null){
            float fixedspeed = velocidad * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, objetivo.position, fixedspeed);
        }

        if (transform.position == objetivo.position){
            objetivo.position = (objetivo.position == inicio ) ? final : inicio;
        }
        
    }
}
