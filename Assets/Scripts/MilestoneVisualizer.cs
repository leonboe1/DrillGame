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
    public int[] mileStones = new int[10];
    public String[] mileStonesText = new String[10]; 
    public AudioClip[] audioClipArray;
    public AudioSource audioSource;
    
    private Text milestoneText;
    private Animator animator;
    private int currentMilestone = 0;
    private bool shown = false;

    // Start is called before the first frame update
    void Start()
    {
        milestoneText = this.gameObject.GetComponentInChildren<Text>();
        animator = GetComponent<Animator>();
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
        }
    }

    private void FixedUpdate()
    {
        shown = animator.GetCurrentAnimatorStateInfo(0).IsName("Shown");
    }

    void HandleMilestone()
    {
        //pick text and set
        milestoneText.text = mileStonesText[currentMilestone];

        //display textboard by playing the animation
        animator.SetTrigger("ShowZarkMessengerBoard");

        //play audio commentary
        audioSource.PlayOneShot(audioClipArray[currentMilestone]);
    }
}
