using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    public Button difficultyButton;
    public Text difficultyButtonText;
    
    // 0 = easy
    // 1 = normal
    // 2 = hard
    public static int difficultyLevel = 1;

    // Start is called before the first frame update
    void Start()
    {
        LoadDifficultyString();
        difficultyButton.onClick.AddListener(button_pressed);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space)) {
            button_pressed();
        }
    }

    public void button_pressed()
    {
        difficultyLevel = (difficultyLevel + 1) % 3;
        LoadDifficultyString();
    }
    
    void LoadDifficultyString()
    {
        var label = "Schwierigkeit: ";
        
        switch(difficultyLevel) {
            case 0:
                label = label + " Einfach";
                break;
            case 1:
                label = label + " Normal";
                break;
            case 2:
                label = label + " Schwer";
                break;
        }
        
        difficultyButtonText.text = label;
    }
}
