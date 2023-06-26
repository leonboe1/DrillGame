using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.UI;

public class MilestoneVisualizer : MonoBehaviour
{
    public GameObject drill;
    //TODO retrieve milestone var from a common source
    //public TileManager tileManager;
    public int[] mileStones = new int[10];
    public String[] mileStonesText = new String[10]; 
    public AudioClip[] audioClipArray;
    public AudioSource audioSource;
    public float displayDuration;
    public float animationSpeed;
    
    private Text milestoneText;
    private int currentMilestone = 0;
    private bool shown = false;
    private float remainingDisplayDuration = 0;
    private float hidingOffset = 600;

    // Start is called before the first frame update
    void Start()
    {
        milestoneText = this.gameObject.GetComponentInChildren<Text>();
        //move out of screen
        gameObject.transform.Translate(-hidingOffset, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(!shown) //only update if not shown
        {
            if (currentMilestone < mileStones.Length && -drill.transform.position.y >= mileStones[currentMilestone])
            {
                HandleMilestone();
                currentMilestone++;
            }
        } else
        {
            //update timer
            remainingDisplayDuration -= Time.deltaTime;

            //hide if timer ran out
            if(remainingDisplayDuration <= 0)
            {
                HideMilestone();
            }
        }
    }

    private void FixedUpdate()
    {
        //TODO animation
        //gameObject.transform.Translate(1, 0, 0);
    }

    void HandleMilestone()
    {
        //pick text and set
        // use Time.fixedTime && drill.transform.position.y Random.value
        milestoneText.text = mileStonesText[currentMilestone];
        audioSource.PlayOneShot(audioClipArray[currentMilestone]);

        //reset time
        remainingDisplayDuration = displayDuration;

        //display
        ShowMilestone();
    }

    void ShowMilestone()
    {
        shown = true;
        gameObject.transform.Translate(hidingOffset, 0, 0);
    }
    void HideMilestone()
    {
        shown = false;
        gameObject.transform.Translate(-hidingOffset, 0, 0);
    }
}
