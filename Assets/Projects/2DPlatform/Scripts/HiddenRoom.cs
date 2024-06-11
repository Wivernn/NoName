using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class HiddenRoom : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        //gameObject.SetActive(true);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Hidden")
        {
            Debug.Log("test");
            gameObject.SetActive(false);
        }
    }
}
