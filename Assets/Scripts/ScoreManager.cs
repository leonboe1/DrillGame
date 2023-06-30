using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    public AudioClip sound;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Reached core
        if(transform.position.y <= -500) {
            audioSource.PlayOneShot(sound);
        
            StartCoroutine(Tremble());
            StartCoroutine(Won());
        }
    }

    IEnumerator Won()
    {
        DrillMover.gameOver = true;
        GameObject.FindWithTag("WinLostText").GetComponent<Text>().text = "Gewonnen!";
          
        // Finde das GameObject mit dem Tag "Score" und hole dessen Text-Komponente
        Text scoreText = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();

        int currentScore = int.Parse(scoreText.text);

        if(currentScore > PlayerPrefs.GetInt("Score" + DifficultyButton.difficultyLevel, 0)) {
            // Speichere den aktuellen Score persistent ab
            PlayerPrefs.SetInt("Score" + DifficultyButton.difficultyLevel, currentScore);
        }

        yield return new WaitForSeconds(4);
        DrillMover.gameOver = false;
        SceneManager.LoadScene("MainMenu");
    }
    
    IEnumerator Tremble()
    {
    
    while (true)
    {
        transform.localPosition += new Vector3(0, 0.01f, 0);
        yield return new WaitForSeconds(0.05f);
        transform.localPosition -= new Vector3(0, 0.01f, 0);
        yield return new WaitForSeconds(0.05f);
    }
}
}
