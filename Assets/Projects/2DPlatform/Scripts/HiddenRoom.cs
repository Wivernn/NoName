using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class HiddenRoom : MonoBehaviour
{
    SpriteRenderer spr;
    Coroutine cor;

    //---------------------------------------------------------------------------------------------

    private void Awake()
    {
        spr = GetComponent<SpriteRenderer>();
    }

    //---------------------------------------------------------------------------------------------

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (cor != null)
        {
            StopCoroutine(cor); //prevents corountines from being active at same time
        }
        cor = StartCoroutine(Fadeout());
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (cor != null)
        {
            StopCoroutine(cor);
        }
        cor = StartCoroutine(Fadein());

    }

    //---------------------------------------------------------------------------------------------
    //coroutines

    IEnumerator Fadeout()
    {
        float duration = 2.0f; //duration lasts for 2 seconds
        float t = 0;
        if (t < duration)
        {
            t += Time.deltaTime;
            // Debug.Log("Coroutine succefully executed");
            //used to test if coroutine was successful before adding transparency

            Color c = spr.color;
            for (float alpha = 1f; alpha >= 0.2; alpha -= 0.01f)
                //gradually adjusts the alpha (opacity) of the hidden area until space is visible behind the barrier
            {
                c.a = alpha;
                spr.color = c;
                yield return null;
            }
            {

            }
        }
    }

    IEnumerator Fadein()
    {
        float duration = 2.0f;

        float t = 1;
        if (t < duration)
        {
            t += Time.deltaTime;

            Color c = spr.color;
            for (float alpha = 1f; alpha <= 1; alpha += 0.01f)
            {
                c.a = alpha;
                spr.color = c;
                yield return null;
            }
        }
    }
}

