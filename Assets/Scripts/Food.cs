using System;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class Food : MonoBehaviour
// , IDataPersistence
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

    public void LoadData(GameData data)
    {
        data.StatusMateri.TryGetValue(NameFood, out bool FoodStatus);
        if (FoodStatus)
        {
            GameObject parentGameObjek = this.GetComponent<GameObject>().gameObject;
            if (parentGameObjek != null)
            {
                GameObject imgLock = parentGameObjek.transform.Find("imgLock").gameObject;
                imgLock.SetActive(false);
            }
        }
        else
        {
            return;
        }
    }

    public void SaveData(GameData data)
    {
        if (data.StatusMateri.ContainsKey(NameFood))
        {
            data.StatusMateri.Remove(NameFood);
        }
        data.StatusMateri.Add(NameFood, FoodStatus);
    }
}