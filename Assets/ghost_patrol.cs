using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghost_patrol : MonoBehaviour
{
    public Vector2 mincampos,maxcampos;
    

    public float velocidad=2f;
    public Transform objetivo;
    public bool Aleatorio=true;
    private float posx,posy;
    private bool unavez = false;


    private  Vector2 puntoA;
    private  Vector2 puntoB;
    private Vector2 posactual;



    private bool objetivo_alcanzado=true;

    



    void FixedUpdate()
    {
        //tomas las posiciones x,y reales del mundo, no las del padre ni la suya
        //usar al heroe para determinar el campo de x , y maximo y minimo
    	if(unavez==false){
    		puntoA = new Vector2(transform.position.x,transform.position.y);
    		puntoB = new Vector2(objetivo.position.x,objetivo.position.y);
    		unavez = true;

    	}



        if (objetivo_alcanzado==true)
        {
        	if (Aleatorio == true){
        		posx=Random.Range(mincampos.x,maxcampos.x);
            	posy=Random.Range(mincampos.y,maxcampos.y);
            	objetivo_alcanzado=false;
	        	objetivo.transform.position = new Vector2(posx,posy);
	            
	        }else{
	        	posactual = new Vector2(transform.position.x,transform.position.y);
	        	if(posactual == puntoA){
	        		objetivo.transform.position = puntoB;


	        	}else{
	        		objetivo.transform.position = puntoA;
	        		
	        	}
	        	objetivo_alcanzado=false;
					        	
	        }



            if(transform.position.x>objetivo.transform.position.x){
                transform.localScale = new Vector3(-1f,1f,1f);
            }
            if(transform.position.x<objetivo.transform.position.x){
                transform.localScale = new Vector3(1f,1f,1f);
            }
        }
        if (transform.position == objetivo.position){
            objetivo_alcanzado=true;
        }
        float fixedspeed = velocidad * Time.deltaTime;
        
        transform.position = Vector2.MoveTowards(transform.position,objetivo.position, fixedspeed);

        //Debug.Log(transform.position);
        //Debug.Log(objetivo.position);

    }
    void OnTriggerEnter2D(Collider2D col){
        if (col.gameObject.tag == "Player")
        {
            col.SendMessage("knockback",transform.position.x);
        }
    }

}

