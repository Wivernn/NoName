using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{


    public int health = 10;
    public float speed = 4f;
    public EnemyDetect enemyDetect;



    private Transform target;
    private int maxHealth;
    private Rigidbody2D rb;


    private void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();

    }

    private void Update()
    {
        if (enemyDetect.aggression == true) 
        {

            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            GetComponent <RandomWalker> ().enabled = false;
            //disabling the walker means the enemy won't get stuck trying to execute the chasse and stay on the designated path at the same time
        }
        
        if (enemyDetect.aggression == false)
        {
            GetComponent <RandomWalker> ().enabled = true;
        }
    }

    private void Awake()
    {
        maxHealth = health;

        target = GameObject.FindWithTag("Player").transform;
    }

}
