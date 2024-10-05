using System.Collections;
using System.Collections.Generic;
using UnityEngine.Rendering;
using UnityEngine.UI;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using TMPro;

public class PuzzelManager : MonoBehaviour
{
    public String LevelPuzzle;
    public GameObject SelectedPiece;
    public Sprite newPuzzle;
    public AudioSource myAudioSource;
    public bool timerIsRunning = false;
    public TextMeshProUGUI TextTime;
    [SerializeField] private float timeInSeconds;
    private float currentTime;
    private int RemeaningPlace = 16;
    int OIL = 1;

    public AudioSource audioMenang;
    public AudioSource audioKalah;
    int keys;

    public int RemeaningPlace_
    {
        get
        {
            return RemeaningPlace;
        }
        set
        {
            RemeaningPlace = value;
            if (RemeaningPlace_ == 0)
            {
                ShowPanelWin();
            }
        }
    }

    private void Awake()
    {
        // audioManager = GameObject.FindGameObjectWithTag("audio").GetComponent<AudioManager>();
    }

    private void Start()
    {
        Time.timeScale = 1;
        myAudioSource.volume = PlayerPrefs.GetFloat("musicVolume");
        currentTime = timeInSeconds;
        timerIsRunning = true;
        keys = PlayerPrefs.GetInt("keys", 0);
    }

    void Update()
    {

        if (timerIsRunning)
        {
            currentTime -= Time.deltaTime;
            SetTime(currentTime);
        }

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.transform != null && hit.transform.CompareTag("Puzzle"))
            {
                PieceScript pieceScript = hit.transform.GetComponent<PieceScript>();
                if (pieceScript != null && !pieceScript.InRightPosition)
                {
                    SelectedPiece = hit.transform.gameObject;
                    pieceScript.Selected = true;
                    SelectedPiece.GetComponent<SortingGroup>().sortingOrder = OIL;
                    OIL++;
                }
            }
        }

        if (Input.GetMouseButtonUp(0) && SelectedPiece != null)
        {
            PieceScript pieceScript = SelectedPiece.GetComponent<PieceScript>();
            if (pieceScript != null)
            {
                pieceScript.Selected = false;
            }
            SelectedPiece = null;
        }

        if (SelectedPiece != null)
        {
            Vector3 MousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            SelectedPiece.transform.position = new Vector3(MousePoint.x, MousePoint.y, 0);
        }
    }

    public GameObject StartPanel, PanelMenang, PanelKalah;
    public void SetPuzzlePhoto(Sprite Photo)
    {
        for (int i = 0; i < 36; i++)
        {
            Transform pieceTransform = GameObject.Find("Piece (" + i + ")")?.transform;
            if (pieceTransform != null)
            {
                Transform puzzleTransform = pieceTransform.Find("Puzzle");
                if (puzzleTransform != null)
                {
                    puzzleTransform.GetComponent<SpriteRenderer>().sprite = Photo;
                }
            }
        }
        StartPanel.SetActive(false);
    }

    public void NextPuzzle()
    {
        SceneManager.LoadSceneAsync(6);
    }

    public void ShowPanelWin()
    {
        PanelMenang.SetActive(true);
        audioMenang.Play();
        CekNamaSceneDanSave();
        StopTimer();
    }

    public void ShowPanelLose()
    {
        PanelKalah.SetActive(true);
        audioKalah.Play();
        StopTimer();
    }

    private void StopTimer()
    {
        timerIsRunning = false;
    }

    public void NextGame(int sceneIndex)
    {
        SceneManager.LoadSceneAsync(sceneIndex);
    }

    public void ExitGame(int sceneIndex)
    {
        SceneManager.LoadSceneAsync(sceneIndex);
    }

    public void ReplayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void SetTime(float value)
    {
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        TextTime.text = time.ToString("mm':'ss");

        if (currentTime <= 0)
        {
            Time.timeScale = 0;
            ShowPanelLose();
        }
    }

    private void CekNamaSceneDanSave()
    {
        Scene NamaScene = SceneManager.GetActiveScene();
        string namaGame = NamaScene.name;
        if (namaGame == "GamePuzzle1")
        {
            int PoinPuzzleLvl1 = PlayerPrefs.GetInt("PoinPuzzleLvl1", 1);
            keys += PoinPuzzleLvl1;
            PlayerPrefs.SetInt("keys", keys);
            PlayerPrefs.SetInt("PoinPuzzleLvl1", 0);
            PlayerPrefs.SetInt("Materi8", 1);
            PlayerPrefs.Save();
        }
    }
}