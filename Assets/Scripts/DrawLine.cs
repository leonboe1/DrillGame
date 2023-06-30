using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    public GameObject drill;
    public float lineWidth = 2f;
    private LineRenderer lineRenderer;
    private List<Vector3> linePositions = new List<Vector3>();
    private Color darkBrown = new Color(0.15f, 0.15f, 0.15f);
    private Camera mainCamera;

    void Start()
    {
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.startWidth = lineWidth;
        lineRenderer.endWidth = lineWidth;
        lineRenderer.startColor = darkBrown;
        lineRenderer.endColor = darkBrown;
        lineRenderer.sortingOrder = -1;
        mainCamera = Camera.main;
    }

    void Update()
    {
        linePositions.Add(drill.transform.position);
        RemoveOffscreenPositions();
        lineRenderer.positionCount = linePositions.Count;
        lineRenderer.SetPositions(linePositions.ToArray());
    }
    
        void RemoveOffscreenPositions()
    {
        for (int i = linePositions.Count - 1; i >= 0; i--)
        {
            Vector3 screenPos = mainCamera.WorldToScreenPoint(linePositions[i]);
            if (screenPos.y - (Screen.height * 0.2) > Screen.height)
            {
                linePositions.RemoveAt(i);
            }
        }
    }
}