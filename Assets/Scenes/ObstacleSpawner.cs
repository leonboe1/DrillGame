using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject boxPrefab;
    public float spawnRate = 1f;
    public float spawnRadius = 5f;

    private float nextSpawnTime = 0f;

    private float boxHeight;

    void Start() {
        boxHeight = gameObject.GetComponent<Renderer>().bounds.size.y;
        Debug.Log(boxHeight);
    }

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            Vector3 spawnPosition = Camera.main.ViewportToWorldPoint(new Vector3(Random.Range(0.1f, 0.9f), 0, 10f));
            spawnPosition.y -= boxHeight;

            GameObject box = Instantiate(boxPrefab, spawnPosition, Quaternion.identity);

            if (Random.value > 0.5f)
            {
                box.GetComponent<SpriteRenderer>().color = Color.green;
            }
            
            nextSpawnTime = Time.time + 1f / spawnRate;
        }
    }
}
