using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLaserDefender : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(SceneManager.GetActiveScene().name);
    }


    public void LoadGameScene()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void LoadStartMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadGameOverScene()
    {
        SceneManager.LoadScene("Game Over");
    }


}
