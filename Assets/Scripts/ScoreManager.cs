using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Reached core
        if(transform.position.y < -500) {
            StartCoroutine(Won());
        }
    }

    IEnumerator Won()
    {
        DrillMover.gameOver = true;
        GameObject.FindWithTag("WinLostText").GetComponent<Text>().text = "You Won!";
          
        // Finde das GameObject mit dem Tag "Score" und hole dessen Text-Komponente
        Text scoreText = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();

        int currentScore = int.Parse(scoreText.text);

        if(currentScore > PlayerPrefs.GetInt("Score", 0)) {
            // Speichere den aktuellen Score persistent ab
            PlayerPrefs.SetInt("Score", currentScore);
        }

        yield return new WaitForSeconds(2);
        DrillMover.gameOver = false;
        SceneManager.LoadScene("MainMenu");
    }
}
