using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ObstacleCollision : MonoBehaviour
{

    public float blinkTime = 0.1f;
    public Color blinkColor = Color.red;

    private SpriteRenderer drillRenderer;
    private Color originalColor;

    private int hits = 0;
    private int life = 3;

    private List<GameObject> collidedObjects = new List<GameObject>();
    
    private bool ignoresHits = false;

    // Start is called before the first frame update
    void Start()
    {
        drillRenderer = GetComponent<SpriteRenderer>();
        originalColor = drillRenderer.color;
    }

    void OnCollisionEnter2D(Collision2D collision) {

        if (collidedObjects.Contains(collision.gameObject) || ignoresHits)
        {
            return;
        }
        
        ignoresHits = true; // invincible for blinking time

        if(collision.gameObject.CompareTag("Obstacle")) {
            collidedObjects.Add(collision.gameObject);
        }
            
        GameObject heart = GameObject.FindWithTag("Heart"+(3-hits));

        Material material = heart.GetComponent<Renderer>().material;

        // Ändere die Transparenz des Materials
        Color color = material.color;
        color.a = 0.3f;
        material.color = color;

        hits++;

        StartCoroutine(Blink(hits == life));
    }

    IEnumerator Blink(bool isDone)
    {
    
        if(isDone) {
            DrillMover.gameOver = true;
            GameObject.FindWithTag("WinLostText").GetComponent<Text>().text = "Verloren!";
        }
        
        drillRenderer.color = blinkColor;
        yield return new WaitForSeconds(blinkTime / 2);
        drillRenderer.color = originalColor;
        yield return new WaitForSeconds(blinkTime / 2);
        drillRenderer.color = blinkColor;
        yield return new WaitForSeconds(blinkTime / 2);
        drillRenderer.color = originalColor;
        
        ignoresHits = false;

        if(isDone) {
        
            // Finde das GameObject mit dem Tag "Score" und hole dessen Text-Komponente
            Text scoreText = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();
        
            int currentScore = int.Parse(scoreText.text);
            
            if(currentScore > PlayerPrefs.GetInt("Score", 0)) {
                // Speichere den aktuellen Score persistent ab
                PlayerPrefs.SetInt("Score", currentScore);
            }
        
            yield return new WaitForSeconds(1);
            DrillMover.gameOver = false;
            SceneManager.LoadScene("MainMenu");
        }
    }
}
