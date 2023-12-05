using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatScript : MonoBehaviour
{
    public float hiz = 5.0f; // Engel hýzý
    public Vector3 hareketYonu = Vector3.left; // Engel hareket yönü
    public float ekrandanCikincaSilmeZamani = 2.0f; // Engel ekrandan çýktýðýnda silinme süresi
    public float yon;


    void Start()
    {
        Destroy(gameObject, ekrandanCikincaSilmeZamani);
    }

    void Update()
    {
        transform.Translate((hareketYonu * yon) * hiz * Time.deltaTime);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bunny"))
        {
            collision.transform.SetParent(this.transform);
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Bunny"))
        {
            collision.transform.SetParent(null);
        }
    }
}
