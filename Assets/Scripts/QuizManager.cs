using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    public String LevelQuiz;
    [System.Serializable]
    public class Question
    {
        public string questionText;
        public Sprite imageQuestion;
        public List<string> options;
        public int correctOptionIndex;
    }
    public TextMeshProUGUI questionText;
    public Image imageQuestion;
    public Image newImageHealth;
    public List<Question> questions;
    public List<Button> optionButtons;
    private int currentQuestionIndex;
    private bool isAnswered = false;
    public HealthBarManager healthBarManager;
    public GameObject PanelWin;
    public AudioSource audioMenang;
    public GameObject PanelLose;
    public AudioSource audioKalah;
    int keys;
    DataParsistenceManager dataParsistenceManager;

    void Start()
    {
        currentQuestionIndex = 0;
        isAnswered = false;
        ShowQuestion();
        keys = PlayerPrefs.GetInt("keys", 0);
    }

    private void ShowQuestion()
    {
        if (currentQuestionIndex < questions.Count)
        {
            Question currentQuestion = questions[currentQuestionIndex];
            questionText.text = currentQuestion.questionText;
            imageQuestion.sprite = currentQuestion.imageQuestion;

            for (int i = 0; i < optionButtons.Count; i++)
            {
                if (i < currentQuestion.options.Count)
                {
                    optionButtons[i].gameObject.SetActive(true);
                    optionButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = currentQuestion.options[i];
                }
            }
            isAnswered = false;
        }
    }

    public void OnOptionSelected(int optionIndex)
    {
        if (!isAnswered)
        {
            isAnswered = true;
            Question currentQuestion = questions[currentQuestionIndex];

            if (optionIndex == currentQuestion.correctOptionIndex)
            {
                Debug.Log("Jawaban benar!");
                PanelWin.SetActive(true);
                audioMenang.Play();
                CekNamaSceneDanSave();
            }
            else
            {
                Debug.Log("Jawaban salah!");
                PanelLose.SetActive(true);
                audioKalah.Play();
            }
            NextQuestionWithDelay();
        }
    }

    public void NextQuestionWithDelay()
    {
        currentQuestionIndex++;
        ShowQuestion();
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
        String namaGame = NamaScene.name;

        if (namaGame == "SceneQuiz1")
        {
            int PoinKuisLvl1 = PlayerPrefs.GetInt("PoinKuisLvl1", 1);
            // int Keys = PlayerPrefs.GetInt("keys", 0);
            keys += PoinKuisLvl1;
            PlayerPrefs.SetInt("keys", keys);
            PlayerPrefs.SetInt("PoinKuisLvl1", 0);
            PlayerPrefs.SetInt("Materi2", 1);
            PlayerPrefs.Save();
        }
        else if (namaGame == "SceneQuiz2")
        {
            int PoinKuisLvl2 = PlayerPrefs.GetInt("PoinKuisLvl2", 1);
            // int Keys = PlayerPrefs.GetInt("keys", 0);
            keys += PoinKuisLvl2;
            PlayerPrefs.SetInt("keys", keys);
            PlayerPrefs.SetInt("PoinKuisLvl2", 0);
            PlayerPrefs.SetInt("Materi3", 1);
            PlayerPrefs.Save();
        }

        else if (namaGame == "SceneQuiz3")
        {
            int PoinKuisLvl3 = PlayerPrefs.GetInt("PoinKuisLvl3", 1);
            // int Keys = PlayerPrefs.GetInt("keys", 0);
            keys += PoinKuisLvl3;
            PlayerPrefs.SetInt("keys", keys);
            PlayerPrefs.SetInt("PoinKuisLvl3", 0);
            // PlayerPrefs.SetInt("Materi4", 1);
            PlayerPrefs.Save();
        }


        // else if (namaGame == "SceneTebakGambar1")
        // {
        //     int PoinTebakGambarLvl1 = PlayerPrefs.GetInt("PoinTebakGambarLvl1", 1);
        //     PoinTebakGambarLvl1++;
        //     PlayerPrefs.SetInt("keys", PoinTebakGambarLvl1);
        //     PlayerPrefs.SetInt("PoinTebakGambarLvl1", 0);
        // }
        // else if (namaGame == "SceneTebakGambar2")
        // {
        //     int PoinTebakGambarLvl2 = PlayerPrefs.GetInt("PoinTebakGambarLvl2", 1);
        //     PoinTebakGambarLvl2++;
        //     PlayerPrefs.SetInt("keys", PoinTebakGambarLvl2);
        //     PlayerPrefs.SetInt("PoinTebakGambarLvl2", 0);
        // }
        // else if (namaGame == "SceneTebakGambar3")
        // {
        //     int PoinTebakGambarLvl3 = PlayerPrefs.GetInt("PoinTebakGambarLvl3", 1);
        //     PoinTebakGambarLvl3++;
        //     PlayerPrefs.SetInt("keys", PoinTebakGambarLvl3);
        // }
        // else if (namaGame == "ScenePuzzle1")
        // {
        //     int PoinPuzzleLvl1 = PlayerPrefs.GetInt("PoinPuzzleLvl1", 1);
        //     PoinPuzzleLvl1++;
        //     PlayerPrefs.SetInt("keys", PoinPuzzleLvl1);
        //     PlayerPrefs.SetInt("PoinPuzzleLvl1", 0);
        // }
        // else if (namaGame == "ScenePuzzle2")
        // {
        //     int PoinPuzzleLvl2 = PlayerPrefs.GetInt("PoinPuzzleLvl2", 1);
        //     PoinPuzzleLvl2++;
        //     PlayerPrefs.SetInt("keys", PoinPuzzleLvl2);
        //     PlayerPrefs.SetInt("PoinPuzzleLvl2", 0);
        // }
    }
}