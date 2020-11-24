using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class no_destruir : MonoBehaviour
{

    public static no_destruir Instance;
    void Awake ()   
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(this);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy (gameObject);
        }
        //DontDestroyOnLoad(this);
    }
}
