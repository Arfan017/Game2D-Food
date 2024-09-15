using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
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

    void Start()
    {
        currentQuestionIndex = 0;
        isAnswered = false;
        ShowQuestion();
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
        // else
        // {
        //     if (healthBarManager.GetCurrentHealth() <= 0)
        //     {
        //         PanelLose.SetActive(true);
        //     }
        //     else
        //     {
        //         PanelWin.SetActive(true);
        //     }
        // }
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

            }
            else
            {
                Debug.Log("Jawaban salah!");
                PanelLose.SetActive(true);
                audioKalah.Play();
                // healthBarManager.WrongAnswer();
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

}