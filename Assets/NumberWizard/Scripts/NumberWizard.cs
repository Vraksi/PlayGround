using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NumberWizard : MonoBehaviour
{
    //needs to be added in the inspector
    [SerializeField] int max;
    [SerializeField] int min;
    [SerializeField] TextMeshProUGUI guessText;

    int secondGuess;
    int firstGuess;

    // Use this for initialization
    void Start()
    {
        NextGuess();
        //StartGame();
    }

    void StartGame()
    {
        //max = max + 1;
        secondGuess = Random.Range(min, max + 1);
        //guess = (max + min) / 2;
        //they seem to do the same
        guessText.text = (secondGuess.ToString());
        //guessText.SetText(guess.ToString());
    }

    public void OnPressHigher()
    {
        min = firstGuess + 1;
        NextGuess();        
    }

    public void OnPressLower()
    {
        max = firstGuess - 1;
        NextGuess();
    }

    void NextGuess()
    {
        firstGuess = Random.Range(min, max + 1);
        /*       
        while (firstGuess == secondGuess)
        {
            secondGuess = Random.Range(min, max + 1);
            if (firstGuess != secondGuess)
            {
                firstGuess = secondGuess;
                break;
            }
        }
        secondGuess = firstGuess;
        */
        //guess = (max + min) / 2;
        guessText.text = (firstGuess.ToString());
        Debug.Log("Is it higher or lower than..." + secondGuess);
    }
}
