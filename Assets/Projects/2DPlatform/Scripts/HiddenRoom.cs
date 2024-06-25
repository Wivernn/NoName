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
            StopCoroutine(cor);
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
            // Debug.Log("Other coroutine complete in... " + (_duration - t));

            Color c = spr.color;
            for (float alpha = 1f; alpha >= 0.2; alpha -= 0.01f)
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
            // Debug.Log("Other coroutine complete in... " + (_duration - t));

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

