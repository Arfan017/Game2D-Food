using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int DataStar;
    public SerializableDictionary<string, bool> DataStatusMateri;
    public SerializableDictionary<string, int> DataPointMateri;
    public SerializableDictionary<string, bool> DataStatusGame;

    public GameData()
    {
        this.DataStar = 0;
        DataStatusMateri = new SerializableDictionary<string, bool>();
        DataPointMateri = new SerializableDictionary<string, int>();
        DataStatusGame = new SerializableDictionary<string, bool>();
    }
}