using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TebakGambarManager : MonoBehaviour
{
    public System.String LevelTebakGambar;
    public GameObject panelMenang;
    public AudioSource audioMenang;
    public GameObject panelKalah;
    public AudioSource audioKalah;

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
            } else
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

}
