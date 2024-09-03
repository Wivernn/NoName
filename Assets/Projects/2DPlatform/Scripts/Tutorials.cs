using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Tutorials : MonoBehaviour
{
    //idea: have transform for each tutorial block, and set so that when player enters a specific block, the tip pops up in the corner
    public GameObject leftRight;
    public P2DPlayerMoveController moveController;

    private void Update()
    {
        if (moveController.walked == true)
        {
            StartCoroutine(start(3));
        }

        if (moveController.jumped == true)
        {
            StartCoroutine(start(3));
        }
    }
   
    IEnumerator start(float Cooldown)
    {
        yield return new WaitForSeconds(3);
        GameObject.Destroy(leftRight);
    }

}
