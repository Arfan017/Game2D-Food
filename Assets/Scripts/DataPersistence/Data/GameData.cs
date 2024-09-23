using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int Keys;
    public SerializableDictionary<string, bool> StatusMateri;
    public SerializableDictionary<string, bool> StatusGame;

    public GameData()
    {
        this.Keys = 0;
        this.StatusMateri = new SerializableDictionary<string, bool>();
        this.StatusGame = new SerializableDictionary<string, bool>();
    }
}