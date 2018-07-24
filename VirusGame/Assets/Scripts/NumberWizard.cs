using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberWizard : MonoBehaviour {

    int max;
    int min;
    int guess;

    int maxGuessesAllowed = 10;

	// Use this for initialization
	void Start () {

        StartGame();

	}

    void StartGame()
    {
        max = 1000;
        min = 1;
        guess = 500;

        max = max + 1;
    }

    void NextGuess()
    {
        guess = (max + min) / 2;
    }

    public void GuessLower() {
        max = guess;
        NextGuess();
    }

    public void GuessHigher() {
        min = guess;
        NextGuess();
        maxGuessesAllowed = maxGuessesAllowed - 1;
        if (maxGuessesAllowed <= 0) {
            Application.LoadLevel("Win");
        }
    }
}
