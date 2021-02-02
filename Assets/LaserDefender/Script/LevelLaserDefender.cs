using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLaserDefender : MonoBehaviour
{
    [SerializeField] float timeBeforeLoad = 1;

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
        StartCoroutine(LoadGameOver());
    }

    private IEnumerator LoadGameOver()
    {
        yield return new WaitForSeconds(timeBeforeLoad);
        SceneManager.LoadScene("Game Over");
    }

}
