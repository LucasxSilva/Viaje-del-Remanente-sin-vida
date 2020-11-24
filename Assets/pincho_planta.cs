﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pincho_planta : MonoBehaviour
{

        
	public Transform objetivo;
    public float velocidad1, velocidad2,delay_mover;
    private bool moverse = true; 
    private bool arriba = true;
    private Vector3 inicio,final;
    private float fixedspeed;
    



    // Start is called before the first frame update
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
            if (arriba == true){
        		fixedspeed = velocidad1 * Time.deltaTime;

                }else{
        			fixedspeed = velocidad2 * Time.deltaTime;

                }
            if (moverse == true){
                transform.position = Vector3.MoveTowards(transform.position, objetivo.position, fixedspeed);
            }
            
        }
        if (transform.position == objetivo.position)
        {
            objetivo.position = (objetivo.position == inicio ) ? final : inicio;
            if (arriba == true){
                arriba = false;

            }else{
                Invoke("delay",delay_mover);
                moverse = false;
                arriba = true;
            }
        } 
    }
        void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.SendMessage("knockback",transform.position.x);
        }
    }
    
    void delay(){
        moverse = true;
    }
}
