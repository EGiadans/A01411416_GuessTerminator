using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Seer : MonoBehaviour
{
    private int min;
    private int max;
    private int guess;
    private LevelManager levelManager;

    public int attempts = 5;
    public Text guessLabel;

    // Use this for initialization
    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
        StartGame();
        ShowGuess();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void StartGame()
    {
        min = 1;
        max = 1001;
        guess = Random.Range(min, max);
        //ShowGuess();
        NextGuess();
    }

    void NextGuess()
    {
        /*
        if (attempts == 0)
        {
            SceneManager.LoadScene("Win");
        }
        guess = UnityEngine.Random.Range(min, max);
        attempts--;
        ShowGuess();
        */
        /*
        guess = Random.Range(min, max);
        attempts--;
        */
        int inicio, centro, fin;
        inicio = min;
        fin = max;
        
        while (inicio <= fin)
        {
            centro = (inicio + fin) / 2;
            if (centro == guess)
            {
                SceneManager.LoadScene("Lost");
            }
            else
            {
                if (guess < fin)
                {
                    fin = centro;
                } else
                {
                    inicio = centro + 1; 
                }
            }
        }
        attempts--;

    }

    void ShowGuess()
    {
        if (attempts >= 0)
        {
            guessLabel.text = "Is your number " + guess + "?";
        }
        else
        {
            //levelManager.LoadLevel("Win");
            SceneManager.LoadScene("Win");
        }
    }


    public void GuessHigher()
    {
        min = guess + 1;
        NextGuess();
        ShowGuess();
    }

    public void GuessLower()
    {
        max = guess;
        NextGuess();
        ShowGuess();
    }

    public void CorrectGuess()
    {
        //levelManager.LoadLevel("Lost");
        SceneManager.LoadScene("Lost");
    }


}
