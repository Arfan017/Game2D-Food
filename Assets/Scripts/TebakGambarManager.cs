using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TebakGambarManager : MonoBehaviour
{
    public string LevelTebakGambar;
    public GameObject panelMenang;
    public AudioSource audioMenang;
    public GameObject panelKalah;
    public AudioSource audioKalah;
    int keys;


    private bool jawabanBenar;
    public bool JawabanBenar
    {
        get => jawabanBenar;
        set
        {
            if (jawabanBenar != value)
            {
                jawabanBenar = value;
                UpdatePanels();
            }
            else
            {
                jawabanBenar = value;
                UpdatePanels();
            }
        }
    }

    void Start()
    {
        // Pastikan kedua panel awalnya tidak aktif
        panelMenang.SetActive(false);
        panelKalah.SetActive(false);
        keys = PlayerPrefs.GetInt("keys", 0);
    }

    void UpdatePanels()
    {
        if (jawabanBenar)
        {
            panelMenang.SetActive(true);
            panelKalah.SetActive(false);
            audioMenang.Play();
        }
        else
        {
            panelMenang.SetActive(false);
            panelKalah.SetActive(true);
            audioKalah.Play();
        }
    }

    public void MainUlang()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ChangeSceneIsClick(int SceneIndex)
    {
        SceneManager.LoadScene(SceneIndex);
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
            PlayerPrefs.SetInt("Materi7", 1);
            PlayerPrefs.Save();
        }
    }
}
