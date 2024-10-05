using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMenuManager : MonoBehaviour
{

    public Button[] ButtonGame;

    void Start()
    {
        BukaGame();
    }

    public void ChangeSceneIsClick(int SceneIndex)
    {
        SceneManager.LoadScene(SceneIndex);
    }

    private void BukaGame()
    {
        int GameQuiz1, GameQuiz2, GameQuiz3, GameTebakGambar1, GameTebakGambar2, GameTebakGambar3, GamePuzzle1, GamePuzzle2;

        GameQuiz1 = PlayerPrefs.GetInt("GameQuiz1", 0);
        GameQuiz2 = PlayerPrefs.GetInt("GameQuiz2", 0);
        GameQuiz3 = PlayerPrefs.GetInt("GameQuiz3", 0);
        GameTebakGambar1 = PlayerPrefs.GetInt("GameTebakGambar1", 0);
        GameTebakGambar2 = PlayerPrefs.GetInt("GameTebakGambar2", 0);
        GameTebakGambar3 = PlayerPrefs.GetInt("GameTebakGambar3", 0);
        GamePuzzle1 = PlayerPrefs.GetInt("GamePuzzle1", 0);
        GamePuzzle2 = PlayerPrefs.GetInt("GamePuzzle2", 0);

        // QUIZ
        if (GameQuiz1 == 1)
        {
            ButtonGame[0].interactable = true;
            ButtonGame[0].GetComponent<Image>().color = Color.white;
        }
        else
        {
            ButtonGame[0].interactable = false;
            ButtonGame[0].GetComponent<Image>().color = Color.gray;
        }

        if (GameQuiz2 == 1)
        {
            ButtonGame[1].interactable = true;
            ButtonGame[1].GetComponent<Image>().color = Color.white;
        }
        else
        {
            ButtonGame[1].interactable = false;
            ButtonGame[1].GetComponent<Image>().color = Color.gray;
        }

        if (GameQuiz3 == 1)
        {
            ButtonGame[2].interactable = true;
            ButtonGame[2].GetComponent<Image>().color = Color.white;
        }
        else
        {
            ButtonGame[2].interactable = false;
            ButtonGame[2].GetComponent<Image>().color = Color.gray;
        }

        // TEBAK GAMBAR
        if (GameTebakGambar1 == 1)
        {
            ButtonGame[3].interactable = true;
            ButtonGame[3].GetComponent<Image>().color = Color.white;
        }
        else
        {
            ButtonGame[3].interactable = false;
            ButtonGame[3].GetComponent<Image>().color = Color.gray;
        }

        if (GameTebakGambar2 == 1)
        {
            ButtonGame[4].interactable = true;
            ButtonGame[4].GetComponent<Image>().color = Color.white;
        }
        else
        {
            ButtonGame[4].interactable = false;
            ButtonGame[4].GetComponent<Image>().color = Color.gray;
        }

        if (GameTebakGambar3 == 1)
        {
            ButtonGame[5].interactable = true;
            ButtonGame[5].GetComponent<Image>().color = Color.white;
        }
        else
        {
            ButtonGame[5].interactable = false;
            ButtonGame[5].GetComponent<Image>().color = Color.gray;
        }

        // PUZZLE
        if (GamePuzzle1 == 1)
        {
            ButtonGame[6].interactable = true;
            ButtonGame[6].GetComponent<Image>().color = Color.white;
        }
        else
        {
            ButtonGame[6].interactable = false;
            ButtonGame[6].GetComponent<Image>().color = Color.gray;
        }

        if (GamePuzzle2 == 1)
        {
            ButtonGame[7].interactable = true;
            ButtonGame[7].GetComponent<Image>().color = Color.white;
        }
        else
        {
            ButtonGame[7].interactable = false;
            ButtonGame[7].GetComponent<Image>().color = Color.gray;
        }
    }
}
