using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DragJawaban : MonoBehaviour
{
    public Vector2 posisiAwal;             // Menyimpan posisi awal dari objek jawaban
    private bool isPosisiJawaban;          // Menandai apakah objek berada di posisi jawaban yang benar
    private Transform posisiJawaban;       // Menyimpan transform dari posisi jawaban
    public int ID;                         // ID unik untuk mencocokkan jawaban dengan tempat jawaban
    private TebakGambarManager tebakGambarManager; // Referensi ke TebakGambarManager untuk mengelola status jawaban
    int keys;

    void Start()
    {
        posisiAwal = transform.position;
        tebakGambarManager = GameObject.Find("GameManager").GetComponent<TebakGambarManager>();
        keys = PlayerPrefs.GetInt("keys", 0);
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
                CekNamaSceneDanSave();
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

    private void CekNamaSceneDanSave()
    {
        Scene NamaScene = SceneManager.GetActiveScene();
        string namaGame = NamaScene.name;

        if (namaGame == "SceneTebakGambar1")
        {
            int PoinTebakGambarLvl1 = PlayerPrefs.GetInt("PoinTebakGambarLvl1", 1);
            keys += PoinTebakGambarLvl1;
            PlayerPrefs.SetInt("keys", keys);
            PlayerPrefs.SetInt("PoinTebakGambarLvl1", 0);
            PlayerPrefs.SetInt("Materi5", 1);
            PlayerPrefs.Save();
        }
        else if (namaGame == "SceneTebakGambar2")
        {
            int PoinTebakGambarLvl2 = PlayerPrefs.GetInt("PoinTebakGambarLvl2", 1);
            keys += PoinTebakGambarLvl2;
            PlayerPrefs.SetInt("keys", keys);
            PlayerPrefs.SetInt("PoinTebakGambarLvl2", 0);
            PlayerPrefs.SetInt("Materi6", 1);
            PlayerPrefs.Save();
        }
        else if (namaGame == "SceneTebakGambar3")
        {
            int PoinTebakGambarLvl3 = PlayerPrefs.GetInt("PoinTebakGambarLvl3", 1);
            keys += PoinTebakGambarLvl3;
            PlayerPrefs.SetInt("keys", keys);
            PlayerPrefs.SetInt("PoinTebakGambarLvl3", 0);
            PlayerPrefs.Save();
        }
    }
}
