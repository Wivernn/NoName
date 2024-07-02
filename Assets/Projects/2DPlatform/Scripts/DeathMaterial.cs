using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathMaterial : MonoBehaviour
{
    public GameObject startPoint;
    public GameObject Player;


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //relocate player to the start of the level
            Player.transform.position = startPoint.transform.position;
        }
    }
}
