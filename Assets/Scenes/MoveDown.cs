using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : MonoBehaviour
{

    public float speed = 10f;
    public float curveSpeed = 100f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float curveDirection = Input.GetKey(KeyCode.Space) ? 1 : -1;

        transform.Rotate(Vector3.forward * curveDirection * curveSpeed * Time.deltaTime);
        transform.position += transform.up * -speed * Time.deltaTime;
    }
}
