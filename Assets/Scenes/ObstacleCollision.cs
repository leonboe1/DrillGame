using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{

    public float blinkTime = 0.1f;
    public Color blinkColor = Color.red;

    private SpriteRenderer renderer;
    private Color originalColor;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        originalColor = renderer.color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision) {
        StartCoroutine(Blink());
    }

    IEnumerator Blink()
    {
        renderer.color = blinkColor;
        yield return new WaitForSeconds(blinkTime / 2);
        renderer.color = originalColor;
        yield return new WaitForSeconds(blinkTime / 2);
        renderer.color = blinkColor;
        yield return new WaitForSeconds(blinkTime / 2);
        renderer.color = originalColor;
    }
}