using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class calcular_vida : MonoBehaviour
{
    public GameObject corazon1,corazon2,corazon3,corazon4,corazon5;
    void FixedUpdate()
    {
        switch (player_controller.vida)
        {
            case 0:
                corazon1.SetActive(false);
                corazon2.SetActive(false);
                corazon3.SetActive(false);
                corazon4.SetActive(false);
                corazon5.SetActive(false);
                break;
            case 1:
                corazon1.SetActive(true);
                corazon2.SetActive(false);
                corazon3.SetActive(false);
                corazon4.SetActive(false);
                corazon5.SetActive(false);
                break;
            case 2:
                corazon1.SetActive(true);
                corazon2.SetActive(true);
                corazon3.SetActive(false);
                corazon4.SetActive(false);
                corazon5.SetActive(false);
                break;
            case 3:
                corazon1.SetActive(true);
                corazon2.SetActive(true);
                corazon3.SetActive(true);
                corazon4.SetActive(false);
                corazon5.SetActive(false);
                break;
            case 4:
                corazon1.SetActive(true);
                corazon2.SetActive(true);
                corazon3.SetActive(true);
                corazon4.SetActive(true);
                corazon5.SetActive(false);
                break;
            case 5:
                corazon1.SetActive(true);
                corazon2.SetActive(true);
                corazon3.SetActive(true);
                corazon4.SetActive(true);
                corazon5.SetActive(true);
                break;
        }
    }
}


