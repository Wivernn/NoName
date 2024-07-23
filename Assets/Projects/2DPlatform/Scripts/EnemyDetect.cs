using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetect : MonoBehaviour
{
    public bool aggression = false;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("Player detected");
            aggression = true; //once the player has entered the enemies detection range box, trigger aggression       
        }
    }

}
