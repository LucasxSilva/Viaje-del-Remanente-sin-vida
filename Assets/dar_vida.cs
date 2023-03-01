using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dar_vida : MonoBehaviour
{
    public ParticleSystem ps;
    public player_controller player;
    void OnTriggerEnter2D(Collider2D col){
        if (col.gameObject.tag == "Player")
        {
            if (player==null)
            {
                player = GameObject.Find("hero").GetComponent<player_controller>();
            }
            Instantiate(ps, transform.position, Quaternion.identity);
            player.vida_bonus(1);
            gameObject.SetActive(false);
        }
    }
}