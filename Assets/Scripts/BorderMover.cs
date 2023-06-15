using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderMover : MonoBehaviour
{

    public GameObject drill;
    private int startPosition;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = (int)transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if(drill.transform.position.y < startPosition)
        {
            transform.position = new Vector3(transform.position.x, drill.transform.position.y, 0);
        }
    }
}
