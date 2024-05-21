﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject Pause;

    public void Start()
    {
        Pause.SetActive(false);
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Pause.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void Continue()
    {
        Pause.SetActive(false);
        Time.timeScale = 1;
    }

    public void QuitToMenu()
    {
        SceneManager.LoadScene("Alina");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        SceneManager.LoadScene("GameplayScene");
    }
}