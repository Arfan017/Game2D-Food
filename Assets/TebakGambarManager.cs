using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TebakGambarManager : MonoBehaviour
{
    public GameObject panelMenang;
    public GameObject panelKalah;

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
        }
        else
        {
            panelMenang.SetActive(false);
            panelKalah.SetActive(true);
        }
    }
}
