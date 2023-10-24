using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
//using UnityEditorInternal;
using UnityEngine;

public class WalkState : State
{
    public WalkState()
    {

    }

    public override void Enter(Player agent)
    {
    }
    public override void Exit(Player agent)
    {

    }
    public override void Update(Player agent)
    {
        agent.ui.UpdateFace(agent.stats.TickPoop(agent.stats.walkingPoopSpeed));
    }
    public override State Check(Player agent)
    {
        //If poop is full
        if (agent.stats.GetPoop() >= 1.0f)
        {
            return new TurtleneckingState();
        }
        else if (agent.controller.IsRunning())
        {
            return new RunState();
        }
        return this;
    }
}
