using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public System.String LevelQuiz;

    [SerializeField]
    private Transform[] pictures;

    [SerializeField]
    private GameObject winText;
    public static bool youWin = false;
    [SerializeField]
    private float startTime = 60f; // Waktu mulai dalam detik

    private float currentTime;
    [SerializeField]
    private TextMeshProUGUI timerText;
    [SerializeField]
    private GameObject gameOverText; // UI Text yang muncul saat waktu habis
    private bool isGameOver = false;

    void Awake()
    {
        ShufflePictures();
    }

    void Start()
    {
        currentTime = startTime; // Inisialisasi currentTime dengan startTime
        winText.SetActive(false);
        gameOverText.SetActive(false);
        youWin = false;
        UpdateTimerText();
    }

    void Update()
    {
        if (CheckWinCondition())
        {
            winText.SetActive(true);
            youWin = true;
            StopTimer(); // Menghentikan timer jika menang
        }

        if (!isGameOver)
        {
            currentTime -= Time.deltaTime;
            UpdateTimerText();

            if (currentTime <= 0)
            {
                currentTime = 0;
                isGameOver = true;
                GameOver();
            }
            UpdateTimerText();
        }
    }

    private void ShufflePictures()
    {
        foreach (Transform picture in pictures)
        {
            // Randomly rotate the picture by 0, 90, 180, or 270 degrees
            float randomRotation = 90 * Random.Range(0, 4);
            picture.rotation = Quaternion.Euler(0, 0, randomRotation);
        }
    }

    private bool CheckWinCondition()
    {
        foreach (Transform picture in pictures)
        {
            // Allow for a small tolerance in rotation checking
            if (Mathf.Abs(picture.rotation.eulerAngles.z) > 1.0f)
            {
                return false;
            }
        }
        return true;
    }

    void OnMouseDown()
    {
        // Cast a ray from the mouse position to detect the clicked picture
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            // Rotate the clicked picture by 90 degrees
            Transform clickedPicture = hit.transform;
            clickedPicture.Rotate(0, 0, 90);
        }
    }

    public bool IsGameOver()
    {
        return isGameOver;
    }

    public void StopTimer()
    {
        isGameOver = true;
    }

    private void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private void GameOver()
    {
        gameOverText.SetActive(true);
        // Tambahkan logika game over lainnya di sini, seperti menghentikan permainan atau menampilkan menu
    }
}