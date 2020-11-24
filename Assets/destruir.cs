using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destruir : MonoBehaviour
{
    public void FixedUpdate() 
    {
        Invoke("destruirr",2);
    }

    public void destruirr()
    {
        Destroy(gameObject);
    }

}
