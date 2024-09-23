using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLevel : MonoBehaviour, IDataPersistence
{
    public String NamaGame;
    public bool StatusGame;

    public void LoadData(GameData data)
    {
        data.StatusGame.TryGetValue(NamaGame, out bool StatusGame);
        if (StatusGame)
        {
            gameObject.GetComponent<Image>().color = Color.white;
        }
        else if (!StatusGame)
        {
            gameObject.GetComponent<Image>().color = Color.grey;
        }
    }

    public void SaveData(GameData data)
    {
        if (data.StatusGame.ContainsKey(NamaGame))
        {
            data.StatusGame.Remove(NamaGame);
        }
        data.StatusGame.Add(NamaGame, StatusGame);
    }
}
