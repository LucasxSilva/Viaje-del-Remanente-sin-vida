using System.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class reset : MonoBehaviour
{
    public GameObject recuperar_vida_master,necromancer_master,skeleton_master,ghost_master;
    public Transform[] objeto_reset_master;
    void Start()
    {

        if (SceneManager.GetActiveScene () == SceneManager.GetSceneByName ("Nivel 1"))
        {
            List<Transform> objetos_reset = new List<Transform>();
            recuperar_vida_master = GameObject.Find("recuperar_vida_master");
            necromancer_master = GameObject.Find("necromancer master");
            skeleton_master = GameObject.Find("skeleton master");
            ghost_master = GameObject.Find("ghost master");

            if (recuperar_vida_master != null)
            {
                int hijos_cantidad = recuperar_vida_master.transform.childCount;
                for (int i = 0; i < hijos_cantidad; i++)
                {
                    objetos_reset.Add(recuperar_vida_master.transform.GetChild(i));
                }  
            }
            

            if (necromancer_master != null)
            {
                int hijos_cantidad = necromancer_master.transform.childCount;
                for (int i = 0; i < hijos_cantidad; i++)
                {
                    objetos_reset.Add(necromancer_master.transform.GetChild(i));
                }  
            }


            if (skeleton_master != null)
            {
                int hijos_cantidad = skeleton_master.transform.childCount;
                for (int i = 0; i < hijos_cantidad; i++) //cuenta los hijos dentro de skeleton_master
                {
                    int subhijos_cantidad = skeleton_master.transform.GetChild(i).childCount;
                    for (int j = 0; j < subhijos_cantidad; j++)    //accede al script de skeleton, hijo de padre skeleton(carpeta padre)
                    {
                        if (skeleton_master.transform.GetChild(i).GetChild(j).gameObject.tag == "Dañador_matable")
                        {
                            objetos_reset.Add(skeleton_master.transform.GetChild(i));
                        }
                    }
                }   
            }

            if (ghost_master != null)
            {
                int hijos_cantidad = ghost_master.transform.childCount;
                for (int i = 0; i < hijos_cantidad; i++) //cuenta los hijos dentro de ghost_master
                {
                    int subhijos_cantidad = ghost_master.transform.GetChild(i).childCount;
                    for (int j = 0; j < subhijos_cantidad; j++)    //accede al script de ghost, hijo de padre ghost(carpeta padre)
                    {
                        if (ghost_master.transform.GetChild(i).GetChild(j).gameObject.tag == "Dañador")
                        {
                            objetos_reset.Add(ghost_master.transform.GetChild(i));
                        }
                    }
                }   
            }
            objeto_reset_master = objetos_reset.ToArray();
        }


	


		if (SceneManager.GetActiveScene () == SceneManager.GetSceneByName ("Nivel 2"))
        {
            List<Transform> objetos_reset = new List<Transform>();

            try{

                recuperar_vida_master = GameObject.Find("recuperar_vida_master");
                necromancer_master = GameObject.Find("necromancer master");
                skeleton_master = GameObject.Find("skeleton master");
                ghost_master = GameObject.Find("ghost master");

                if (recuperar_vida_master != null)
                {
                    int hijos_cantidad = recuperar_vida_master.transform.childCount;
                    for (int i = 0; i < hijos_cantidad; i++)
                    {
                        objetos_reset.Add(recuperar_vida_master.transform.GetChild(i));
                    }  
                }
                


                if (necromancer_master != null)
                {
                    int hijos_cantidad = necromancer_master.transform.childCount;
                    for (int i = 0; i < hijos_cantidad; i++)
                    {
                        objetos_reset.Add(necromancer_master.transform.GetChild(i));
                    }  
                }

                if (skeleton_master != null)
                {
                    int hijos_cantidad = skeleton_master.transform.childCount;
                    for (int i = 0; i < hijos_cantidad; i++) //cuenta los hijos dentro de skeleton_master
                    {
                        int subhijos_cantidad = skeleton_master.transform.GetChild(i).childCount;
                        for (int j = 0; j < subhijos_cantidad; j++)    //accede al script de skeleton, hijo de padre skeleton(carpeta padre)
                        {
                            if (skeleton_master.transform.GetChild(i).GetChild(j).gameObject.tag == "Dañador_matable")
                            {
                                objetos_reset.Add(skeleton_master.transform.GetChild(i));
                            }
                        }
                    }   
                }

                if (ghost_master != null)
                {
                    int hijos_cantidad = ghost_master.transform.childCount;
                    for (int i = 0; i < hijos_cantidad; i++) //cuenta los hijos dentro de ghost_master
                    {
                        int subhijos_cantidad = ghost_master.transform.GetChild(i).childCount;
                        for (int j = 0; j < subhijos_cantidad; j++)    //accede al script de ghost, hijo de padre ghost(carpeta padre)
                        {
                            if (ghost_master.transform.GetChild(i).GetChild(j).gameObject.tag == "Dañador")
                            {
                                objetos_reset.Add(ghost_master.transform.GetChild(i));
                            }
                        }
                    }   
                }


            }
            catch (NullReferenceException e)
            {
                Debug.LogError("Error: " + e.Message);
            }

            objeto_reset_master = objetos_reset.ToArray();
		}



        if (SceneManager.GetActiveScene () == SceneManager.GetSceneByName ("Nivel 3"))
        {
            List<Transform> objetos_reset = new List<Transform>();
            recuperar_vida_master = GameObject.Find("recuperar_vida_master");
            necromancer_master = GameObject.Find("necromancer master");
            skeleton_master = GameObject.Find("skeleton master");
            ghost_master = GameObject.Find("ghost master");


            
            if (recuperar_vida_master != null)
            {
                int hijos_cantidad = recuperar_vida_master.transform.childCount;
                for (int i = 0; i < hijos_cantidad; i++)
                {
                    objetos_reset.Add(recuperar_vida_master.transform.GetChild(i));
                }  
            }
            
            if (necromancer_master != null)
            {
                int hijos_cantidad = necromancer_master.transform.childCount;
                for (int i = 0; i < hijos_cantidad; i++)
                {
                    objetos_reset.Add(necromancer_master.transform.GetChild(i));
                }  
            }



            if (skeleton_master != null)
            {
                int hijos_cantidad = skeleton_master.transform.childCount;
                for (int i = 0; i < hijos_cantidad; i++) //cuenta los hijos dentro de skeleton_master
                {
                    int subhijos_cantidad = skeleton_master.transform.GetChild(i).childCount;
                    for (int j = 0; j < subhijos_cantidad; j++)    //accede al script de skeleton, hijo de padre skeleton(carpeta padre)
                    {
                        if (skeleton_master.transform.GetChild(i).GetChild(j).gameObject.tag == "Dañador_matable")
                        {
                            objetos_reset.Add(skeleton_master.transform.GetChild(i));
                        }
                    }
                }   
            }

            if (ghost_master != null)
            {
                int hijos_cantidad = ghost_master.transform.childCount;
                for (int i = 0; i < hijos_cantidad; i++) //cuenta los hijos dentro de ghost_master
                {
                    int subhijos_cantidad = ghost_master.transform.GetChild(i).childCount;
                    for (int j = 0; j < subhijos_cantidad; j++)    //accede al script de ghost, hijo de padre ghost(carpeta padre)
                    {
                        if (ghost_master.transform.GetChild(i).GetChild(j).gameObject.tag == "Dañador")
                        {
                            objetos_reset.Add(ghost_master.transform.GetChild(i));
                        }
                    }
                }   
            }

            objeto_reset_master = objetos_reset.ToArray();

		}

    }

    public void reseteo()
    {
        foreach (Transform objeto in objeto_reset_master)
        {
            try{
                objeto.gameObject.SetActive(true);
            }
            catch(Exception){
                objeto_reset_master=objeto_reset_master.Where(t => t != objeto).ToArray();
                //print(objeto);
            }
            /*
            if (!objeto.gameObject.activeInHierarchy)
            {
                objeto.gameObject.SetActive(true);
            }
            else
            {
                objeto.parent.gameObject.SetActive(true);
                MonoBehaviour[] scripts = objeto.gameObject.GetComponents<MonoBehaviour>();
                foreach (MonoBehaviour script in scripts)
                {
                    script.Invoke("respawn", 0f);
                }
                
            }
            */
        }
    }
}
