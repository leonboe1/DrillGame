using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Reached core
        if(transform.position.y < -500) {
            StartCoroutine(Won());
        }
    }

    IEnumerator Won()
    {
        DrillMover.gameOver = true;
        GameObject.FindWithTag("WinLostText").GetComponent<Text>().text = "You Won!";
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("MainMenu");
    }
}
