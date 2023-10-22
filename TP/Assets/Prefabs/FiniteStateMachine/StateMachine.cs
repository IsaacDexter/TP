using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
	protected Player agent;
	protected State state;
    public StateMachine(Player player)
	{
		//Store the agent
		this.agent = player;
		this.state = null;
	}
    public virtual void Update()
	{
		//So long as we have a state
		if (state != null)
		{
			state.Update(agent);
			//If it's trying to transition, it'll call its own cleanup
			SetState(state.Check(agent));
		}
	}
	public virtual void SetState(State newState)
	{
		//If changing state
		if (newState != state)
		{
			//If we can exit, do so
			if(state != null) 
			{
				state.Exit(agent);
			}
			state = newState;
			//if we can enter, do so
			if (state != null)
			{
				state.Enter(agent);
			}
		}
	}
	public virtual bool HasState() 
	{ 
		return state != null; 
	}
}
