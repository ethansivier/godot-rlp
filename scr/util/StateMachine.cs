using Godot;
using System;
using System.Collections.Generic;

public partial class StateMachine : Node
{
    [Export] public State initial_state = null;
    public State state = null;
    public string new_state = null;
    [Signal] public delegate void FinishedEventHandler(string next_state_path);

    public override async void _Ready()
    {
        await ToSignal(GetParent(), SignalName.Ready);
        state = initial_state;
        new_state = initial_state.Name;
        state.enter("", new Dictionary<object, object>());
    }

    public void _process(float delta)
    {

        if (!(new_state == state.Name))
        {
            _transition_to_next_state(new_state);
        }
        
        state.process(delta);
    }

   

    public void physic_process(float delta)
    {
        state.physic_process(delta);
        

    }

    public void _transition_to_next_state(string target, Dictionary<object, object> data = null )
    {
        if (!HasNode(target))
        {
            return;
        }
        GD.Print("changing");
        string previous_state = state.Name;
        state.exit();
        state = (State)GetNode(target);
        state.enter(previous_state, data);
    }

}