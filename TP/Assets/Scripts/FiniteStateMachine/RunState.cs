using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEditorInternal;
using UnityEngine;

public class RunState : State
{
    public RunState()
    {

    }

    public override void Enter(Player agent)
    {
        agent.ui.ShowRunningFace();
    }
    public override void Exit(Player agent)
    {
        agent.ui.HideRunningFace();
    }
    public override void Update(Player agent)
    {
        agent.ui.UpdateFace(agent.stats.TickPoop(agent.stats.runningPoopSpeed));
    }
    public override State Check(Player agent)
    {
        //If poop is full
        if (agent.stats.GetPoop() >= 1.0f)
        {
            return new TurtleneckingState();
        }
        else if (!agent.controller.IsRunning())
        {
            return new WalkState();
        }
        return this;
    }
}
