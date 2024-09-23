using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefManager : MonoBehaviour
{
    // Menyimpan skor pemain ketika level selesai
    public void SaveScore(int score)
    {
        PlayerPrefs.SetInt("Materi1", score);
        PlayerPrefs.SetInt("Materi2", score);
        PlayerPrefs.SetInt("Materi3", score);
        PlayerPrefs.SetInt("Materi4", score);
        PlayerPrefs.SetInt("Materi5", score);
        PlayerPrefs.SetInt("Materi6", score);
        PlayerPrefs.SetInt("Materi7", score);
        PlayerPrefs.SetInt("Materi8", score);

        PlayerPrefs.SetInt("GameQuiz1", score);
        PlayerPrefs.SetInt("GameQuiz2", score);
        PlayerPrefs.SetInt("GameQuiz3", score);

        PlayerPrefs.SetInt("GameTebakGambar1", score);
        PlayerPrefs.SetInt("GameTebakGambar2", score);
        PlayerPrefs.SetInt("GameTebakGambar3", score);

        PlayerPrefs.SetInt("GamePuzzle1", score);
        PlayerPrefs.SetInt("GamePuzzle2", score);

        PlayerPrefs.Save();
    }

    // Mengambil skor pemain ketika level dimulai
    public int LoadScore()
    {
        int score = PlayerPrefs.GetInt("PlayerScore", 0); // Nilai default 0 jika belum ada skor tersimpan
        Debug.Log("Skor yang diambil: " + score);
        return score;
    }

    // Reset skor pemain
    public void ResetScore()
    {
        PlayerPrefs.DeleteKey("PlayerScore"); // Menghapus skor yang tersimpan
        Debug.Log("Skor direset.");
    }
}
