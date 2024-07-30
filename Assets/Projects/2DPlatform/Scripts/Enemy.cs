using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

    public float knockbackForce = 5;
    public float kbStunTime = 2;
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
            GetComponent<RandomWalker>().enabled = false;
            //disabling the walker means the enemy won't get stuck trying to execute the chasse and stay on the designated path at the same time
        }

        if (enemyDetect.aggression == false)
        {
            GetComponent<RandomWalker>().enabled = true;
        }
    }


    private void Awake()
    {
        maxHealth = health;

        target = GameObject.FindWithTag("Player").transform;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (Input.GetMouseButtonDown(0)) //0 = left click
        {

            health--;

            //method1
            /* Vector2 difference = (transform.position).normalized;
             Vector2 force = difference * knockbackForce;
             rb.AddForce(force, ForceMode2D.Impulse); //if you don't want to take into consideration enemy's mass then use ForceMode.VelocityChange */

            //method2
            /*Vector2 dir = transform.position - collision.gameObject.transform.position;
           // rb.constraints = RigidbodyConstraints2D.FreezeAll;
            rb.AddForce(dir * knockbackForce, ForceMode2D.Impulse);
            StartCoroutine(KnockbackStunTime(kbStunTime));

            if (health < 1)
            {
                Destroy(gameObject);
            }*/
        }
    }

   /* IEnumerator KnockbackStunTime(float cooldown)
    {
        yield return new WaitForSeconds(cooldown);
        //canMove = true;
    } */
} 
        
    


