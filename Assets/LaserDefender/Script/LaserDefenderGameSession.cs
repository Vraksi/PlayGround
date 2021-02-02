using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LaserDefenderGameSession : MonoBehaviour
{
    [SerializeField] int startScore = 0;
    [SerializeField] TextMeshProUGUI scoreText;

    private void Awake()
    {
        int gameSession = FindObjectsOfType<LaserDefenderGameSession>().Length;
        if (gameSession > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        scoreText.SetText(startScore.ToString());
    }

    public void AddToScore(int scoreToAdd)
    {
        startScore += scoreToAdd;
        scoreText.SetText(startScore.ToString());
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }
}
