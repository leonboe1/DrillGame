using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StorylineContinuer : MonoBehaviour
{

    bool pressedBefore = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space)) {
            pressedBefore = true;
        }
        else {
            if(pressedBefore){
                button_pressed();
            }
        }
    }

    public void button_pressed()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
