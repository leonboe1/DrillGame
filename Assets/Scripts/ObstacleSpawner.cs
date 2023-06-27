using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;
using UnityEngine.Tilemaps;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject binPrefab;
    public GameObject stonePrefab;
    List<GameObject> obstacles = new List<GameObject>();

    public float spawnRate = 1f;
    private float nextSpawnDepth = 0f; // When drill passes this depth, spawn a new obstacle

    public int deleteAboveY = 10;


    private float boxHeight;

    void Start() {
        boxHeight = gameObject.GetComponent<Renderer>().bounds.size.y;
    }

    void Update()
    {
        if (!DrillMover.gameOver && transform.position.y <= nextSpawnDepth)
        {
            spawnObjectBelow();
        }

        DeleteObstaclesAbove();
    }


    //deletes all obstacles above the player, that are not seen by the camera
    private void DeleteObstaclesAbove()
    {
        float upperY = transform.position.y + deleteAboveY;

        // Find all obstacles above the player
        List<GameObject> removeObjects = new List<GameObject>();
        foreach(GameObject obstacle in obstacles)
        {
            if (obstacle.transform.position.y > upperY)
            {
                removeObjects.Add(obstacle);
            }
        }

        // Remove them from the list and destroy them (two steps to avoid modifying the list while iterating over it)
        foreach(GameObject obstacle in removeObjects)
        {
            obstacles.Remove(obstacle);
            Destroy(obstacle);
        }
    }

    private void spawnObjectBelow()
    {
        Vector3 spawnPosition = Camera.main.ViewportToWorldPoint(new Vector3(Random.Range(0.1f, 0.9f), 0, 10f));
        spawnPosition.y -= boxHeight;

        GameObject box = Instantiate(Random.value > 0.5f ? binPrefab : stonePrefab, spawnPosition, Quaternion.identity);

        box.GetComponent<Collider2D>().enabled = true;

        // Add to list of obstacles
        obstacles.Add(box);

        nextSpawnDepth -= 10f / spawnRate;
    }


}


