using System;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarManager : MonoBehaviour
{
    public Image[] hearts; // Array untuk menyimpan gambar hati
    private int currentHealth; // Health saat ini

    void Start()
    {
        currentHealth = hearts.Length; // Inisialisasi health berdasarkan jumlah gambar hati
        UpdateHealthBar(); // Update tampilan health bar
    }

    // Fungsi untuk mengurangi health apabila menjawab pertanyaan dengan salah
    public void WrongAnswer()
    {
        currentHealth--; // Kurangi health satu
        if (currentHealth < 0)
        {
            currentHealth = 0; // Pastikan health tidak kurang dari 0
        }
        UpdateHealthBar(); // Update tampilan health bar
    }

    // Fungsi untuk mengupdate tampilan health bar
    void UpdateHealthBar()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < currentHealth)
            {
                hearts[i].enabled = true; // Tampilkan gambar hati
            }
            else
            {
                hearts[i].enabled = false; // Sembunyikan gambar hati
            }
        }
    }

    // Fungsi untuk mendapatkan health saat ini
    public int GetCurrentHealth()
    {
        return currentHealth;
    }
}
