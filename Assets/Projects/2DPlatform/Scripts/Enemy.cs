using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

    public Transform detectionRange;
    public BoxCollider2D sightLine;
    public int health = 10;
    public bool aggression;
    public float speed = 2f;

    public Enemy[] test; 


    private Transform target;
    private int maxHealth;
    private Rigidbody2D rb;


    private void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       if (collision.transform == detectionRange) //need to find a way to detect collision from player
        {
            Debug.Log("AAAAA");
            aggression = true; //once the player has entered the enemies detection range box, trigger aggression
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision == sightLine)
        {
            Debug.Log("done");
            aggression = false;
        }
    }

    private void Update()
    {
        if (aggression) 
        {

        }
    }

    private void Awake()
    {
        maxHealth = health;

    }


    private void OnTriggerEnter(Collider other)
    {


    }
}
