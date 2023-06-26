using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Moves objects to the drill's position, like border and background
public class ObjectsMover : MonoBehaviour
{

    public GameObject drill;
    
    private float startPositionZ;
    private float startPositionY;

    // Start is called before the first frame update
    void Start()
    {
        startPositionY = transform.position.y;
        startPositionZ = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        if(drill.transform.position.y < startPositionY)
        {
            transform.position = new Vector3(transform.position.x, drill.transform.position.y, startPositionZ);
        }
    }
}
