using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MateriManager : MonoBehaviour
// , IDataPersistence
{
    public GameObject panelMateri;
    public GameObject panelFood;
    public GameObject PanelHadiah;
    public GameObject Pointer;
    public Image imageFood;
    public TextMeshProUGUI nameFood;
    public TextMeshProUGUI descriptionFood;
    public TextMeshProUGUI TextStar;
    public TextMeshProUGUI TextPesan;
    public Button BtnTutupPanel;
    public TextMeshProUGUI TextKeys;
    public static DataParsistenceManager instance { get; private set; }
    public Food[] Objectfood;
    int? ObjectFoodPosition = null;
    bool MateriIsClick = false;
    private DataParsistenceManager dataParsistenceManager;
    private int PointStart;
    int keys;
    int posisiMateri;

    public void Start()
    {
        dataParsistenceManager = FindAnyObjectByType<DataParsistenceManager>();
        if (dataParsistenceManager != null)
        {
            DataParsistenceManager.instance.LoadGame();
        }
        // DataParsistenceManager.instance.LoadGame();
        BtnTutupPanel.onClick.AddListener(TutupPanel);

        int keys = PlayerPrefs.GetInt("keys", 0);
        TextKeys.text = keys.ToString();
        CekStatusMateri();

        if (keys == 3)
        {
            // PanelHadiah.SetActive(true);
        }
    }

    public void Update()
    {
        for (int i = 0; i < Objectfood.Length; i++)
        {
            if (Objectfood[i].FoodStatus == false)
            {
                Image imagefood = Objectfood[i].GetComponent<Image>();
                // imagefood.color = Color.black;
                BoxCollider boxColliderFoo = Objectfood[i].GetComponent<BoxCollider>();
                boxColliderFoo.enabled = false;
            }
            else
            {
                Image imagefood = Objectfood[i].GetComponent<Image>();
                // imagefood.color = Color.white;
                BoxCollider boxColliderFoo = Objectfood[i].GetComponent<BoxCollider>();
                boxColliderFoo.enabled = true;
            }
        }

        // Memeriksa jika ada sentuhan pada layar
        if (Input.touchCount > 0)
        {
            // Mendapatkan sentuhan pertama
            Touch touch = Input.GetTouch(0);

            // Memeriksa jika sentuhan adalah sentuhan awal (bukan drag atau move)
            if (touch.phase == TouchPhase.Began)
            {
                // Mendapatkan posisi sentuhan dalam bentuk ray dari layar
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;

                // Memeriksa jika ray bersentuhan dengan collider game object
                if (Physics.Raycast(ray, out hit))
                {
                    // Memeriksa jika game object yang di-klik adalah salah satu dari Objectfood
                    for (int i = 0; i < Objectfood.Length; i++)
                    {
                        if (hit.transform.gameObject == Objectfood[i].ObjectFood)
                        {
                            ObjectFoodPosition = i;
                            // Lakukan sesuatu dengan game object yang diklik
                            Debug.Log("Anda mengklik game object dengan index: " + i);
                            posisiMateri = i + 1;
                            // panelFoodIsActive(Objectfood[i].ImageFood, Objectfood[i].NameFood, Objectfood[i].DeskFood);
                            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                            touchPosition.z = 0f;
                            Pointer.transform.position = touchPosition;
                        }
                    }
                }
            }
        }

        if (MateriIsClick && ObjectFoodPosition.HasValue)
        {
            panelFoodIsActive(Objectfood[ObjectFoodPosition.Value].ImageFood, Objectfood[ObjectFoodPosition.Value].NameFood,
            Objectfood[ObjectFoodPosition.Value].DeskFood, Objectfood[ObjectFoodPosition.Value].PointFood);
        }
        else
        {
            MateriIsClick = false;
            return;
        }
    }

    public void ChangeSceneIsClick(int SceneIndex)
    {
        SceneManager.LoadScene(SceneIndex);
    }

    public void panelFoodIsActive(Sprite ImageFood, string NameFood, string DeskFood, int PointFood)
    {
        panelMateri.SetActive(true);
        panelFood.SetActive(false);

        // PointStar = PointFood;
        // TextStar.text = PointStar.ToString();

        imageFood.sprite = ImageFood;
        nameFood.text = NameFood;
        descriptionFood.text = DeskFood;
    }

    public void MateriIsClickTrue()
    {
        MateriIsClick = true;
    }

    public void MateriIsClickFalse()
    {
        MateriIsClick = false;
        panelFood.SetActive(true);
        panelMateri.SetActive(false);
        addStart();
    }

    private void addStart()
    {
        PointStart = +1;
        TextStar.text = PointStart.ToString();
    }

    void TutupPanel()
    {
        MateriIsClick = false;
        if (!MateriIsClick)
        {
            PanelHadiah.SetActive(false);
            panelMateri.SetActive(false);
            panelFood.SetActive(true);
        }
    }

    private void panelHadiah()
    {
        PanelHadiah.SetActive(true);
        TextPesan.text = "horeee.... kamu telah selesai membaca materi.\n\nselamat kamu telah membuka game quiz level " + posisiMateri.ToString();
    }

    void CekStatusMateri()
    {
        int Materi2, Materi3, Materi4, Materi5, Materi6, Materi7, Materi8;
        Materi2 = PlayerPrefs.GetInt("Materi2", 0);
        Materi3 = PlayerPrefs.GetInt("Materi3", 0);
        Materi4 = PlayerPrefs.GetInt("Materi4", 0);
        Materi5 = PlayerPrefs.GetInt("Materi5", 0);
        Materi6 = PlayerPrefs.GetInt("Materi6", 0);
        Materi7 = PlayerPrefs.GetInt("Materi7", 0);
        Materi8 = PlayerPrefs.GetInt("Materi8", 0);

        if (Materi2 != 0)
        {
            GameObject imgLock = GameObject.Find("imgLock1").gameObject;
            imgLock.SetActive(false);
            Objectfood[1].FoodStatus = true;
        }

        if (Materi3 != 0)
        {
            GameObject imgLock = GameObject.Find("imgLock2").gameObject;
            imgLock.SetActive(false);
            Objectfood[2].FoodStatus = true;
        }

        if (Materi4 != 0)
        {
            GameObject imgLock = GameObject.Find("imgLock3").gameObject;
            imgLock.SetActive(false);
            Objectfood[3].FoodStatus = true;
        }

        if (Materi5 != 0)
        {
            GameObject imgLock = GameObject.Find("imgLock4").gameObject;
            imgLock.SetActive(false);
            Objectfood[4].FoodStatus = true;
        }

        if (Materi6 != 0)
        {
            GameObject imgLock = GameObject.Find("imgLock5").gameObject;
            imgLock.SetActive(false);
            Objectfood[5].FoodStatus = true;
        }

        if (Materi7 != 0)
        {
            GameObject imgLock = GameObject.Find("imgLock6").gameObject;
            imgLock.SetActive(false);
            Objectfood[6].FoodStatus = true;
        }

        if (Materi8 != 0)
        {
            GameObject imgLock = GameObject.Find("imgLock7").gameObject;
            imgLock.SetActive(false);
            Objectfood[7].FoodStatus = true;
        }
    }
}