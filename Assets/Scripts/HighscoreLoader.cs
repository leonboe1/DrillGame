using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreLoader : MonoBehaviour
{

    public Text scoreText;
    
    int startDifficulty = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        startDifficulty = DifficultyButton.difficultyLevel;
        // Lade den gespeicherten Wert und setze ihn als aktuellen Score
        scoreText.text = "Highscore: " + PlayerPrefs.GetInt("Score" + DifficultyButton.difficultyLevel, 0).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(DifficultyButton.difficultyLevel != startDifficulty) {
            startDifficulty = DifficultyButton.difficultyLevel;
                    scoreText.text = "Highscore: " + PlayerPrefs.GetInt("Score" + DifficultyButton.difficultyLevel, 0).ToString();
        }
    }
}
