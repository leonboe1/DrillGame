using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundRepeater : MonoBehaviour
{
    public GameObject[] backgroundPrefabs;
    private List<Transform> backgrounds = new List<Transform>();
    private float backgroundHeight;
    private Camera cam;
    private float camHeight;
    private int[] yThresholds = new int[] { -100, -200, -300, -400, -500 };
    public float[] curveSpeeds = new float[6];
    private int currentThresholdIndex = 0;

    private DrillMover drillMover;

    void Start()
    {
        // Get the main camera
        cam = Camera.main;

        // Get the height of the camera's visible area
        camHeight = 2f * cam.orthographicSize;

        // Get the height of the background
        backgroundHeight = backgroundPrefabs[0].GetComponent<SpriteRenderer>().bounds.size.y;

        // Create the initial backgrounds
        for (int i = 0; i < Mathf.Ceil(camHeight / backgroundHeight) + 1; i++)
        {
            CreateBackground(backgroundHeight/2 - (i * backgroundHeight));
        }

        drillMover = gameObject.GetComponent<DrillMover>();
        drillMover.curveSpeed = curveSpeeds[0];
    }

    void Update()
    {

         //update to other rock layer after passing a milestone
        for (int i = 0; i < yThresholds.Length; i++)
        {
            if (transform.position.y <= yThresholds[i])
            {
                drillMover.curveSpeed = curveSpeeds[i + 1];
                break;
            }

        }

        // Check if we need to create a new background
        if (transform.position.y - backgrounds[0].position.y < camHeight / 2)
        {
            float yPos = backgrounds[0].position.y - backgroundHeight;
            if (currentThresholdIndex < yThresholds.Length && yPos <= yThresholds[currentThresholdIndex])
            {
                yPos = yThresholds[currentThresholdIndex] - backgroundHeight/2;
                currentThresholdIndex++;
            }
            CreateBackground(yPos);
        }

        // Check if we need to remove an old background
        if (backgrounds[backgrounds.Count - 1].position.y > transform.position.y + camHeight / 2 + backgroundHeight)
        {
            Destroy(backgrounds[backgrounds.Count - 1].gameObject);
            backgrounds.RemoveAt(backgrounds.Count - 1);
        }
    }

    void CreateBackground(float yPos)
    {
        // Determine which background prefab to use based on the y position

        // Create a new background at the specified y position
        GameObject newBackground = Instantiate(backgroundPrefabs[currentThresholdIndex], new Vector3(0, yPos + 0.1f, 0), Quaternion.identity);
        backgrounds.Insert(0, newBackground.transform);
    }
}