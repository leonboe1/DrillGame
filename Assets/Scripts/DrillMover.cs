using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrillMover : MonoBehaviour
{

    public float speed = 10f;
    public float curveSpeed = 100f;

    public static bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(Tremble());
    }

    void Update() 
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
         if(gameOver) {
            return;
        }

        // Move forward according to curve direction
        float curveDirection = Input.GetKey(KeyCode.Space) ? 1 : -1;
        transform.Rotate(Vector3.forward * curveDirection * curveSpeed * Time.deltaTime);
        Vector3 transformedPosition = transform.up * -speed * Time.deltaTime;

        // Don't allow to go up
        if(transformedPosition.y > 0) {
            transformedPosition.y = 0;
        }

        transform.position += transformedPosition;


        // Don't allow rotation to point towards top
        float zRotation = transform.rotation.eulerAngles.z;

        if(zRotation > 90 && zRotation < 270) {
            if(Mathf.Abs(zRotation-90) < Mathf.Abs(zRotation-270)) {
                transform.rotation = Quaternion.Euler(0, 0, 90);
            }
            else {
                transform.rotation = Quaternion.Euler(0, 0, 270);
            }
        }
    }
    
    IEnumerator Tremble()
    {
    while (true)
    {
        transform.localPosition += new Vector3(0, 0.05f, 0);
        yield return new WaitForSeconds(0.01f);
        transform.localPosition -= new Vector3(0, 0.05f, 0);
        yield return new WaitForSeconds(0.01f);
    }
}
}
