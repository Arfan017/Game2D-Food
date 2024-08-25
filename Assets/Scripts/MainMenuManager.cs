using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    private DataParsistenceManager dataParsistenceManager;

    public static DataParsistenceManager instance { get; private set; }
    public GameObject panelMenu;

    void Start()
    {
        dataParsistenceManager = FindAnyObjectByType<DataParsistenceManager>();
        if (dataParsistenceManager != null)
        {
            dataParsistenceManager.NewGame();
        }
        else
        {
            Debug.Log("DataParsistenceManager not found");
        }
    }

    public void PlayIsClick()
    {
        panelMenu.SetActive(true);
    }

    public void CloseMenuIsClick()
    {
        panelMenu.SetActive(false);
    }

    public void ExitGameIsClick()
    {
        Application.Quit();
    }

    public void ChangeSceneIsClick(int SceneIndex)
    {
        SceneManager.LoadScene(SceneIndex);
    }
}