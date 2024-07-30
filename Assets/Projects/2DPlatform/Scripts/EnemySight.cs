using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySight : MonoBehaviour
{
    public EnemyDetect enemyDetect;
    public Transform toFollow; //set up the sightline to follow the enemy without making it a child object
    public Enemy enemy;


    private Vector3 offset;


    private void Start()
    {
        offset = toFollow.position - transform.position;

    }

    private void Update()
    {
        transform.position = toFollow.position - offset;
        //transform.rotation = toFollow.rotation;

            if (enemy.health < 1)
            {
                Destroy(gameObject);
            }

    }

    //only have exit enabled as enemy should only be aggresive when the player walks into detection range
    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Enemy passive");
        enemyDetect.aggression = false;
    }
}
