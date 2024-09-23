using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragJawaban : MonoBehaviour
{
    public Vector2 posisiAwal;             // Menyimpan posisi awal dari objek jawaban
    private bool isPosisiJawaban;          // Menandai apakah objek berada di posisi jawaban yang benar
    private Transform posisiJawaban;       // Menyimpan transform dari posisi jawaban
    public int ID;                         // ID unik untuk mencocokkan jawaban dengan tempat jawaban
    private TebakGambarManager tebakGambarManager; // Referensi ke TebakGambarManager untuk mengelola status jawaban

    void Start()
    {
        posisiAwal = transform.position;
        tebakGambarManager = GameObject.Find("GameManager").GetComponent<TebakGambarManager>();
    }

    private void OnMouseDrag()
    {
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = pos;
    }

    private void OnMouseUp()
    {
        if (isPosisiJawaban)
        {
            int idTempatJawaban = posisiJawaban.GetComponent<TempatJawaban>().ID;

            if (ID == idTempatJawaban)
            {
                Debug.Log("Jawaban Benar");
                tebakGambarManager.JawabanBenar = true;
            }
            else
            {
                Debug.Log("Jawaban Salah");
                tebakGambarManager.JawabanBenar = false;
            }

            SetJawabanPosisi();
            DisableJawaban();
        }
        else
        {
            transform.position = posisiAwal;
        }
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.CompareTag("Drop"))
        {
            isPosisiJawaban = true;
            posisiJawaban = collider.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Drop"))
        {
            isPosisiJawaban = false;
            posisiJawaban = null;
        }
    }

    private void SetJawabanPosisi()
    {
        transform.SetParent(posisiJawaban);
        transform.localPosition = Vector3.zero;
        transform.localScale = new Vector2(0.45f, 0.6f);
    }

    private void DisableJawaban()
    {
        if (posisiJawaban != null)
        {
            posisiJawaban.GetComponent<SpriteRenderer>().enabled = false;
            posisiJawaban.GetComponent<Rigidbody2D>().simulated = false;
            posisiJawaban.GetComponent<BoxCollider2D>().enabled = false;
        }

        gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }
}
