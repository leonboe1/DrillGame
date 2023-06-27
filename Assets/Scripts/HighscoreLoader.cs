using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreLoader : MonoBehaviour
{

    public Text scoreText;
    
    // Start is called before the first frame update
    void Start()
    {
        // Lade den gespeicherten Wert und setze ihn als aktuellen Score
        scoreText.text = "Highscore: " + PlayerPrefs.GetInt("Score", 0).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
