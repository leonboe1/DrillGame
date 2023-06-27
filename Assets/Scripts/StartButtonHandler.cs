using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartButtonHandler : MonoBehaviour
{

    public Button startButton;
    public Text startButtonText;
    
    public AudioClip sound;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        startButton.onClick.AddListener(button_pressed);
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
        audioSource.PlayOneShot(sound);
        startButtonText.text = "Laden...";
        SceneManager.LoadScene("MainGame");
    }
}
