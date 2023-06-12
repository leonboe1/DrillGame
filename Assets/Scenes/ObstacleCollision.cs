using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;

public class ObstacleCollision : MonoBehaviour
{

    public Grid grid;
    public Tilemap tilemap;

    public float blinkTime = 0.1f;
    public Color blinkColor = Color.red;

    private SpriteRenderer drillRenderer;
    private Color originalColor;

    private int hits = 0;
    private int life = 3;

    // Start is called before the first frame update
    void Start()
    {
        drillRenderer = GetComponent<SpriteRenderer>();
        originalColor = drillRenderer.color;
    }

    // Update is called once per frame
    void Update()
    {

        // Reached corex
        if(transform.position.y < -100) {
            SceneManager.LoadScene("MainMenu");
        }

        Vector3Int position = grid.WorldToCell(transform.position);
        tilemap.SetTile(position, null);
    }

    void OnCollisionEnter2D(Collision2D collision) {
        hits++;

        float percentage = (float)hits/(float)life;

        Color newColor = new Color(1, 1 - percentage, 1 - percentage, 1);
        
        drillRenderer.color = newColor;

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            collision.gameObject.GetComponent<Collider2D>().enabled = false;
        }

        if(hits == life) {
            StartCoroutine(Blink());
        }
    }

    IEnumerator Blink()
    {

        drillRenderer.color = blinkColor;
        yield return new WaitForSeconds(blinkTime / 2);
        drillRenderer.color = originalColor;
        yield return new WaitForSeconds(blinkTime / 2);
        drillRenderer.color = blinkColor;
        yield return new WaitForSeconds(blinkTime / 2);
        drillRenderer.color = originalColor;
        drillRenderer.color = blinkColor;
        yield return new WaitForSeconds(blinkTime / 2);
        drillRenderer.color = originalColor;
        

        SceneManager.LoadScene("MainMenu");
    }
}
