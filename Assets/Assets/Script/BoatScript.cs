using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatScript : MonoBehaviour
{
    public float hiz = 5.0f; // Engel h�z�
    public Vector3 hareketYonu = Vector3.left; // Engel hareket y�n�
    public float ekrandanCikincaSilmeZamani = 2.0f; // Engel ekrandan ��kt���nda silinme s�resi
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
