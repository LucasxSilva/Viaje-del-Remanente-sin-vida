using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plataforma_mover : MonoBehaviour
{
    public Transform objetivo;
    public float velocidad,delay_velocidad;
    private Vector3 default_inicial,default_final,inicio,final;
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
            velocidad=velocidad/2;
            Invoke("velocidad_restaurar",delay_velocidad);
        }
    }

    void velocidad_restaurar(){
            velocidad=velocidad*2;
    }


    void OnEnable(){
        player_controller.OnPlayerDied += respawn;
    }
    void OnDisable(){
        player_controller.OnPlayerDied -= respawn;
    }
    void respawn(){
        transform.position=inicio;
        objetivo.position=final;
    }
}
