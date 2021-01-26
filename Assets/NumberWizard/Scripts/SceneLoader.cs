﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    GameStatus gameStatus;

    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadStartScene()
    {
        FindObjectOfType<GameStatus>().GameOver();       
        SceneManager.LoadScene(0);
    }

    public void QuitApplication()
    {
        
        Application.Quit();
    }
}
