using System.Collections.Generic;
using Godot;

public partial class Idle : PlayerState
{
    public override void enter(string previous, Dictionary<object, object> data)
    {
        player.jump_count = 0;
        player.velocity.Y = 0;
    }

    public override void process(float delta)
    {   
        player.velocity = player.velocity.MoveToward(Vector2.Zero, player.decel * (float)delta);
        
        player.Velocity = player.velocity;
        player.MoveAndSlide();
        Falling.jump_check(player);

        if (player.can_jump)
        {
            _change_state(FALLING);
        }

        else if (player.is_moving())
        {
            _change_state(RUNNING);
        }

        else if (!player.IsOnFloor())
        {
            _change_state(FALLING);
        }
    }
}