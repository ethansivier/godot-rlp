using System;
using System.Threading.Tasks;
using Godot;

public partial class PlayerState : State
{
    public const string IDLE = "Idle";
    public const string RUNNING = "Run";
    public const string JUMPING = "Jump";
    public const string FALLING = "Falling";
    [Signal] public delegate void FinishedEventHandler(string next_state_path);

    public Player player = null;

    public override void _Ready()
    {
        player = Owner as Player;
    }
}