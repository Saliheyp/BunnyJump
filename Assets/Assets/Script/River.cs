using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class River : MonoBehaviour
{
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bunny"))
        {
            move tavsanOlum = collision.gameObject.GetComponent<move>();
            tavsanOlum.Death();
        }
    }

}
