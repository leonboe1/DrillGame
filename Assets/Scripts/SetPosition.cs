using UnityEngine;

public class SetPosition : MonoBehaviour
{
    public GameObject drill;

    void Update()
    {
        // Get the position and rotation of the drill
        Vector3 drillPosition = drill.transform.position;
        Quaternion drillRotation = drill.transform.rotation;

        // Set the position of the current GameObject to the bottom center of the drill
        transform.position = drillPosition + (drillRotation * Vector3.down * drill.transform.localScale.y * 1.5f);
    }
}