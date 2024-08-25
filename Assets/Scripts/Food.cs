using System;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class Food : MonoBehaviour
{
    public GameObject ObjectFood;
    public Sprite ImageFood;
    public GameObject ImageStart;
    public String NameFood;
    public String DeskFood;
    [SerializeField]
    private int pointFood = 1;
    [SerializeField]
    public bool foodStatus;

    public bool FoodStatus { get => foodStatus; set => foodStatus = value; }
    public int PointFood { get => pointFood; set => pointFood = value; }

    // public void LoadData(GameData data)
    // {
    //     data.DataStatusMateri.TryGetValue(NameFood, out bool FoodStatus);
    //     if (FoodStatus)
    //     {
    //         Image imagefood = gameObject.GetComponent<Image>();
    //         if (imagefood != null)
    //         {
    //             imagefood.color = Color.white;
    //             ImageStart.SetActive(false);
    //         }
    //     }
    //     else if (!FoodStatus)
    //     {
    //         gameObject.SetActive(true);
    //     }

    //     data.DataPointMateri.TryGetValue(NameFood, out int PointFood);
    //     if (PointFood == 1)
    //     {
    //         PointFood = 1;
    //     }
    //     else
    //     {
    //         PointFood = 0;
    //     }
    // }

    // public void SaveData(GameData data)
    // {
    //     if (data.DataStatusMateri.ContainsKey(NameFood))
    //     {
    //         data.DataStatusMateri.Remove(NameFood);
    //     }
    //     data.DataStatusMateri.Add(NameFood, FoodStatus);

    //     if (data.DataPointMateri.ContainsKey(NameFood))
    //     {
    //         data.DataPointMateri.Remove(NameFood);
    //     }
    //     data.DataPointMateri.Add(NameFood, PointFood);
    // }
}