using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MateriManager : MonoBehaviour
{
    public GameObject panelMateri;
    public GameObject panelFood;
    public GameObject PanelHadiah;
    public GameObject PanelBukaMateri;
    public GameObject PanelBukaSemuaMateri;
    public TextMeshProUGUI TextPesanBukaMateri;
    public TextMeshProUGUI TextPointKeys;
    public GameObject Pointer;
    public Image imageFood;
    public TextMeshProUGUI nameFood;
    public TextMeshProUGUI descriptionFood;
    public TextMeshProUGUI TextStar;
    public TextMeshProUGUI TextPesan;
    public Button BtnTutupPanel;
    public Button BtnBukaMateri;
    public TextMeshProUGUI TextKeys;
    public static DataParsistenceManager instance { get; private set; }
    public Food[] Objectfood;
    int? ObjectFoodPosition = null;
    bool MateriIsClick = false;
    private DataParsistenceManager dataParsistenceManager;
    private int PointStart;
    int keys;
    int posisiMateri;
    int Materi2, Materi3, Materi4, Materi5, Materi6, Materi7, Materi8;
    int TampilkanPanelBukaSemuaMateri;

    public void Start()
    {
        dataParsistenceManager = FindAnyObjectByType<DataParsistenceManager>();
        if (dataParsistenceManager != null)
        {
            DataParsistenceManager.instance.LoadGame();
        }

        TampilkanPanelBukaSemuaMateri = PlayerPrefs.GetInt("TampilkanPanelBukaSemuaMateri", 1);

        // DataParsistenceManager.instance.LoadGame();
        BtnTutupPanel.onClick.AddListener(TutupPanel);

        int keys = PlayerPrefs.GetInt("keys", 0);
        TextKeys.text = keys.ToString();

        CekStatusMateri();

        if (keys == 3 && Materi4 == 0)
        {
            PanelBukaMateri.SetActive(true);
            TextPesanBukaMateri.text = "Yeee... Kunci Kamu Telah mencapai 3! \n\nyuk buka materi 4!";
            TextPointKeys.text = keys.ToString();
            BtnBukaMateri.onClick.AddListener(() => BukaMateri("Materi4", "imgLock3", 3));

        }

        if (keys == 6 && Materi7 == 0)
        {
            PanelBukaMateri.SetActive(true);
            TextPesanBukaMateri.text = "Yeee... Kunci Kamu Telah mencapai 6! \n\nyuk buka materi 7!";
            TextPointKeys.text = keys.ToString();
            BtnBukaMateri.onClick.AddListener(() => BukaMateri("Materi7", "imgLock6", 6));
        }

    }

    private void BukaMateri(string materi, string _imgLock, int ObjectFood)
    {
        PlayerPrefs.SetInt(materi, 1);
        PlayerPrefs.Save();
        PanelBukaMateri.SetActive(false);
        GameObject imgLock = GameObject.Find(_imgLock).gameObject;
        imgLock.SetActive(false);
        Objectfood[ObjectFood].FoodStatus = true;
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
            BukaGame(posisiMateri.ToString());
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

        imageFood.sprite = ImageFood;
        nameFood.text = NameFood;
        descriptionFood.text = DeskFood;
    }

    private void BukaGame(string Game)
    {
        if (Game == "1")
        {
            PlayerPrefs.SetInt("GameQuiz1", 1);
            PlayerPrefs.Save();
        }

        if (Game == "2")
        {
            PlayerPrefs.SetInt("GameQuiz2", 1);
            PlayerPrefs.Save();
        }

        if (Game == "3")
        {
            PlayerPrefs.SetInt("GameQuiz3", 1);
            PlayerPrefs.Save();
        }

        if (Game == "4")
        {
            PlayerPrefs.SetInt("GameTebakGambar1", 1);
            PlayerPrefs.Save();
        }

        if (Game == "5")
        {
            PlayerPrefs.SetInt("GameTebakGambar2", 1);
            PlayerPrefs.Save();
        }

        if (Game == "6")
        {
            PlayerPrefs.SetInt("GameTebakGambar3", 1);
            PlayerPrefs.Save();
        }

        if (Game == "7")
        {
            PlayerPrefs.SetInt("GamePuzzle1", 1);
            PlayerPrefs.Save();
        }

        if (Game == "8")
        {
            PlayerPrefs.SetInt("GamePuzzle2", 1);
            PlayerPrefs.Save();
        }
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
        if (posisiMateri == 1)
        {
            TextPesan.text = "horeee.... kamu telah selesai membaca materi.\n\nselamat kamu telah membuka game quiz level 1";
        }
        else if (posisiMateri == 2)
        {
            TextPesan.text = "horeee.... kamu telah selesai membaca materi.\n\nselamat kamu telah membuka game quiz level 2";
        }
        else if (posisiMateri == 3)
        {
            TextPesan.text = "horeee.... kamu telah selesai membaca materi.\n\nselamat kamu telah membuka game quiz level 3";
        }
        else if (posisiMateri == 4)
        {
            TextPesan.text = "horeee.... kamu telah selesai membaca materi.\n\nselamat kamu telah membuka game tebak gambar level 1";
        }
        else if (posisiMateri == 5)
        {
            TextPesan.text = "horeee.... kamu telah selesai membaca materi.\n\nselamat kamu telah membuka game tebak gambar level 2";
        }
        else if (posisiMateri == 6)
        {
            TextPesan.text = "horeee.... kamu telah selesai membaca materi.\n\nselamat kamu telah membuka game tebak gambar level 3";
        }
        else if (posisiMateri == 7)
        {
            TextPesan.text = "horeee.... kamu telah selesai membaca materi.\n\nselamat kamu telah membuka game puzzle level 1";
        }
        else if (posisiMateri == 8)
        {
            TextPesan.text = "horeee.... kamu telah selesai membaca materi.\n\nselamat kamu telah membuka game puzzle level 2";
        }
    }

    void CekStatusMateri()
    {
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

        if (Materi2 == 1 && Materi3 == 1 && Materi4 == 1 && Materi5 == 1 && Materi6 == 1 && Materi7 == 1 && Materi8 == 1 && TampilkanPanelBukaSemuaMateri == 1)
        {
            PanelBukaSemuaMateri.SetActive(true);
            TampilkanPanelBukaSemuaMateri = 0;
            PlayerPrefs.SetInt("TampilkanPanelBukaSemuaMateri", 0);
            PlayerPrefs.Save();
        }
    }
}