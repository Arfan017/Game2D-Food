// using System;
// using JetBrains.Annotations;
// using Unity.VisualScripting;
// using UnityEngine;
// using UnityEngine.UI;

// [Serializable]
// public class Food1 : MonoBehaviour, IDataPersistence
// {
//     public GameObject ObjectFood;
//     public Sprite ImageFood;
//     public String NameFood;
//     public String DeskFood;
//     public int  PointFood = 1;
//     public bool FoodStatus = false;
    

//     public void LoadData(GameData data)
//     {
//         data.DataStatusMateri.TryGetValue(NameFood, out FoodStatus);
//         if (FoodStatus)
//         {
//             Image imagefood = gameObject.GetComponent<Image>();
//             if (imagefood != null)
//             {
//                 imagefood.color = Color.white;
//             }
//         }
//         else if (!FoodStatus)
//         {
//             gameObject.SetActive(true);
//         }

//         data.DataPointMateri.TryGetValue(NameFood, out PointFood);
//         if (PointFood == 1)
//         {
//             PointFood = 1;
//         } else
//         {
//             PointFood = 0;
//         }

//     }

//     public void SaveData(GameData data)
//     {
//         if (data.DataStatusMateri.ContainsKey(NameFood))
//         {
//             data.DataStatusMateri.Remove(NameFood);
//         }
//         data.DataStatusMateri.Add(NameFood, FoodStatus);

//         if (data.DataPointMateri.ContainsKey(NameFood))
//         {
//             data.DataPointMateri.Remove(NameFood);
//         }
//         data.DataPointMateri.Add(NameFood, PointFood);
//     }
// }