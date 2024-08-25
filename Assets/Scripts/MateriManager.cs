using CarterGames.Assets.SaveManager;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MateriManager : MonoBehaviour
{
    public GameObject panelMateri;
    public GameObject panelFood;
    public GameObject Pointer;
    public Image imageFood;
    public TextMeshProUGUI nameFood;
    public TextMeshProUGUI descriptionFood;
    public TextMeshProUGUI TextStar;
    private int PointStar = 0;
    public Food[] Objectfood;
    int? ObjectFoodPosition = null;
    bool MateriIsClick = false;
    private DataParsistenceManager dataParsistenceManager;

    public static DataParsistenceManager instance { get; private set; }

    // private void OnEnable()
    // {
    //     SaveFoodManager = SaveManager.GetSaveObject<DataFoodSaveObject>();
    //     LoadFood();
    // }


    public void Start()
    {
        dataParsistenceManager = FindAnyObjectByType<DataParsistenceManager>();
        DataParsistenceManager.instance.SaveGame();
    }

    public void Update()
    {
        for (int i = 0; i < Objectfood.Length; i++)
        {
            if (Objectfood[i].FoodStatus == false)
            {
                Image imagefood = Objectfood[i].GetComponent<Image>();
                imagefood.color = Color.black;
                BoxCollider boxColliderFoo = Objectfood[i].GetComponent<BoxCollider>();
                boxColliderFoo.enabled = false;
            }
            else
            {
                Image imagefood = Objectfood[i].GetComponent<Image>();
                imagefood.color = Color.white;
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

                            // panelFoodIsActive(Objectfood[i].ImageFood, Objectfood[i].NameFood, Objectfood[i].DeskFood);
                            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                            touchPosition.z = 0f;
                            Pointer.transform.position = touchPosition;

                            // Instantiate(Pointer, touchPosition, Quaternion.identity);

                            // Misalnya, Anda bisa memanggil fungsi lain atau melakukan manipulasi lainnya di sini
                            // Image imagefood = Objectfood[i + 1].ImageFood.GetComponent<Image>();
                            // if (imagefood != null)
                            // {
                            //     imagefood.color = Color.white;
                            // }

                            // break;
                        }

                        // Image imagefood = Objectfood[i].ImageFood.GetComponent<Image>();
                        // if (imagefood != null)
                        // {
                        //     imagefood.color = Color.white;
                        // }
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

        PointStar = PointFood;
        TextStar.text = PointStar.ToString();

        // PointFood = ;

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
    }
}