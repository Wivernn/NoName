using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Tutorials : MonoBehaviour
{
    public AudioSource Victory;
    public GameObject enemy1;
    public GameObject enemy2;

    int runOnce1 = 0;
    int runOnce2 = 0;

    public GameObject Point1, Point2, Point3, Point4;   
    public GameObject one, two, three, four, five;
    public bool One, Two, Three, Four, Five;

    Coroutine coroutine;



    private void Start()
    {
        enemy1 = GameObject.Find("Enemy (1)");
        enemy2 = GameObject.Find("Enemy (2)");


        Point1 = GameObject.Find("Point1");
        Point2 = GameObject.Find("Point2");
        Point3 = GameObject.Find("Point3");
        Point4 = GameObject.Find("Point4");

        

    }

    private void Update()
    {
        if (runOnce1 == 0) {
            if (enemy1 == null)
            {
                runOnce1++;
                Victory.Play();

                if (Five == false)
                {
                    Five = true;
                    coroutine = StartCoroutine(Destroy(1));
                }
            }
        }
        if (runOnce2 == 0)
        {
            if (enemy2 == null)
            {
                runOnce2++;
                Victory.Play();

                if (Five == false)
                {
                    Five = true;
                    coroutine = StartCoroutine(Destroy(1));
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Success")
        {
            Victory.Play();
            coroutine = StartCoroutine(Destroy(1));
        }
        if (collision.gameObject == Point1)
        {
            One = true;
        }
        if (collision.gameObject == Point2)
        {
            Two = true;
        }
        if (collision.gameObject == Point3)
        {
            Three = true;
        }
        if (collision.gameObject == Point4)
        {
            Four = true;
        }

    }

    IEnumerator Destroy(float time)
    {
        yield return new WaitForSeconds(time);

        if (One == true)
        {
            Destroy(one);
        }         
        
        if (Two == true)
        {
            Destroy(two);      
        }         
        
        if (Three == true)
        {
            Destroy(three);      
        }         
        
        if (Four == true)
        {
            Destroy(four);      
        }

        if (Five == true)
        {
            Destroy(five);
        }
    }


}
