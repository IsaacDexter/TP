using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    public State()
    {

    }

    public abstract void Enter(Player agent);
    public abstract void Exit(Player agent);
    public abstract void Update(Player agent);
    public abstract State Check(Player agent);
}
