using System;
using System.Collections.Generic;
using Godot;


public partial class State : Node
{
    [Export] public State initial_state = null;
    public State state = null;
	public int priority = 1;

    public void _change_state(string name)
    {
        GetParent().Set("new_state", name);
    }

    public void _transition_to_next_state(string target, Dictionary<object, object> data)
    {
        ;
    }

    public virtual void enter(string previous_state, Dictionary<object, object> data)
    {
        ;
    }
    public void exit()
    {
        ;
    }

    public void physic_process(float delta)
    {
        ;
    }

    public void update(float delta)
    {
        ;
    }


    public void _process(float delta)
    {
        ;
    }

    public virtual void process(float delta)
    {
        ;
    }
}