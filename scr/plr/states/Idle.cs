using Godot;

public partial class Idle : PlayerState
{
    public override void process(float delta)
    {   
        player.velocity = player.velocity.MoveToward(Vector2.Zero, player.decel * (float)delta);
        GD.Print("IDLE");
        
        player.Velocity = player.velocity;
        player.MoveAndSlide();

        if (player.is_moving())
        {
            GD.Print("change");
            _change_state(RUNNING);
        }
    }
}