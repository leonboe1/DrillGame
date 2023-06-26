using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyRemover : MonoBehaviour
{
    public GameObject drill;
    public float deleteAboveY = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(0 > drill.transform.position.y + deleteAboveY)
        {
            Destroy(gameObject);
        }
    }


}
