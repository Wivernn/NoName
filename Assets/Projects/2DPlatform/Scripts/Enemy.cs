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
    public int health = 5;
    public float speed = 4f;
    public EnemyDetect enemyDetect;
    public P2DPlayerMoveController moveController;

    private bool kb;
    private Transform target;
    //private int maxHealth;
    private Rigidbody2D rb;


    private void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();

       
    }


    private void Awake()
    {
        //maxHealth = health;

        target = GameObject.FindWithTag("Player").transform;
    }


    //---------------------------------------------------------------------------------------------


    private void Update()
    {
        if (enemyDetect.aggression == true)
        {
            if (kb == true)
            {
                return; //freezes the enemy for 2 seconds when hit
            }
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            GetComponent<RandomWalker>().enabled = false;
            //disabling the walker means the enemy won't get stuck trying to execute the chase and stay on the designated path at the same time
        }

        if (enemyDetect.aggression == false)
        {
            GetComponent<RandomWalker>().enabled = true;
            //enemy returns to their normal path
        }

        if (target)
        {
            float dist = Vector3.Distance(target.position, transform.position);
            //Debug.Log("Distance to other: " + dist);


            //need to add in code so enemy can't get too close, otherwise the knockback doesn't work


            if (dist < 1.5)
            {
                if (Input.GetMouseButtonDown(0)) //0 = left click
                {

                    health--;

                    //method1
                    /*  */

                    //method2
                    Vector2 dir = transform.position - target.transform.position;
                    rb.AddForce(dir * knockbackForce, ForceMode2D.Impulse);
                    StartCoroutine(KnockbackStunTime(kbStunTime));
                    kb = true;

                    if (health < 1)
                    {
                        Destroy(transform.parent.gameObject);

                    }
                }
            }
        }

    }


    IEnumerator KnockbackStunTime(float cooldown)
    {
        Vector2 difference = (transform.position).normalized;
        Vector2 force = difference * knockbackForce;
        rb.AddForce(force, ForceMode2D.Impulse); //if you don't want to take into consideration enemy's mass then use ForceMode.VelocityChange


        yield return new WaitForSeconds(cooldown);
        kb= false;        
        //maybe detect which way player is facing and create knockback based on that?
    } 
} 
        
    


