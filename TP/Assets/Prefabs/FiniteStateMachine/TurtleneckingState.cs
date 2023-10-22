using System.Collections;
using System.Collections.Generic;
using System.Net.Mail;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEditorInternal;
using UnityEngine;

public class TurtleneckingState : State
{
    [Header("Mash")]
    [SerializeField, Range(0.0f, 1.0f), Tooltip("How much poop is required before mashing commences")] private float MashThreshold = 1.0f;
    [SerializeField, Range(0, 50), Tooltip("How many mashes required to save you")] private int MashCounter = 15;
    [SerializeField, Tooltip("The string to display when mashing")] string MashMessage = "ABOUT TO POOP!!!! MASH F";
    public TurtleneckingState()
    {

    }

    public override void Enter(Player agent)
    {
        if (agent.lives <= 0)
        {
            agent.GameOver();
        }
        agent.ui.DisplayMessage(MashMessage);
        agent.ui.ShowTurtleneckingFace();
        MashCounter = Random.Range(MashCounter-5, MashCounter+5);
    }
    public override void Exit(Player agent)
    {
        agent.ui.ClearMessage(MashMessage);
        agent.ui.HideTurtleneckingFace();

        agent.stats.DecreasePoop(agent.lives * 0.25f); //decrease poop by amount based on lives. 50% first time, then 25% 
        agent.lives--;
    }
    public override void Update(Player agent)
    {
        if (Input.GetKeyUp(KeyCode.F) && MashCounter > 0)  //mash counter is how many times we need to press the button 
        {
            MashCounter--;
        }
    }
    public override State Check(Player agent)
    {
        if (MashCounter <= 0) //finished mashing
        {
            //If we're running
            if (agent.controller.IsRunning())
            {
                return new RunState();
            }
            //if not
            else
            {
                return new WalkState();
            }
        }
        return this;
    }
}
