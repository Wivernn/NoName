using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Tutorials : MonoBehaviour
{
    //idea: have transform for each tutorial block, and set so that when player enters a specific block, the tip pops up in the corner
    public Transform leftRight;
    public P2DPlayerMoveController moveController;

    private void Update()
    {
        if (moveController.walked == true)
        {
            StartCoroutine(start(4));
        }
    }
   
    IEnumerator start(float Cooldown)
    {
        yield return new WaitForSeconds(4);
        GameObject.Destroy(leftRight.gameObject);
    }

}
