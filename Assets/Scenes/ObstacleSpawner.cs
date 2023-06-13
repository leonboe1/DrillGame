using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject binPrefab;
    public GameObject stonePrefab;

    public float spawnRate = 1f;
    private float nextSpawnTime = 0f;

    private float boxHeight;

    void Start() {
        boxHeight = gameObject.GetComponent<Renderer>().bounds.size.y;
    }

    void Update()
    {
        if (!DrillMover.gameOver && Time.time >= nextSpawnTime)
        {
            Vector3 spawnPosition = Camera.main.ViewportToWorldPoint(new Vector3(Random.Range(0.1f, 0.9f), 0, 10f));
            spawnPosition.y -= boxHeight;

            GameObject box = Instantiate(Random.value > 0.5f ? binPrefab : stonePrefab, spawnPosition, Quaternion.identity);

            box.GetComponent<Collider2D>().enabled = true;
            
            nextSpawnTime = Time.time + 1f / spawnRate;
        }
    }
}
